﻿using Factorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using static System.Console;
using Factorio.Entities;
using Factorio.DAL;

namespace FactorioTest
{
    class Program
    {
        static string path = "ItemList.xml";

        static List<FactorioItem> items;

        static void Main(string[] args)
        {

            bool isRunning = true;

            items = FactorioXmlDal.ReadItems(path);

            while(isRunning)
            {
                MainMenu();

                switch (ReadLine())
                {
                    case "1":
                        AddItem();
                        break;
                    case "2":
                        AddRecipe();
                        break;
                    case "3":
                        CreateProduction();
                        break;
                    case "4":
                        ViewItems();
                        break;
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        
        }

        #region Menus
        static void MainMenu()
        {
            Clear();
            WriteLine("Factorio calculator v0.1");
            WriteLine();
            WriteLine("1) Add new item");
            WriteLine("2) Add recipe to item");
            WriteLine("3) Create production");
            WriteLine("4) View items");
            WriteLine("5) Exit");
            Write(">");
        }

        static void ViewItems()
        {
            Clear();
            WriteLine("View items");
            WriteLine();

            foreach (var i in items)
            {
                WriteLine(i.Name);
            }

            WriteLine();

            Write("View item details?(y/n)");


            if(ReadKey(true).KeyChar == 'y')
            {
                WriteLine();
                WriteLine();
                Write("Item: ");

                string itemName = ReadLine();

                FactorioItem item = items.Find(x => x.Name == itemName);

                WriteLine();
                WriteLine($"Name: {item.Name}");
                WriteLine($"Productivity: {item.Productivity}");
                WriteLine();
                if(item.Recipe != null)
                {
                    WriteLine("Recipe:");

                    foreach (var craft in item.Recipe)
                    {
                        WriteLine($"\t{craft.Value}x {craft.Key.Name}");
                    }
                }
                else
                {
                    WriteLine("This item has no recipe");
                }

                WriteLine();
                Write("Press any key...");
                ReadKey();

            }
        }

        static void CreateProduction()
        {
            Clear();
            WriteLine("Create a new production");
            WriteLine();
            Write("Item: ");

            string itemName = ReadLine();

            Assembly assembly = new Assembly(items.Find(x => x.Name == itemName));

            Write("Quantity: ");         

            assembly.Print(Convert.ToInt32(ReadLine()));

            ReadKey();
        }

        static void AddRecipe()
        {
            Clear();
            WriteLine("Add recipe to item");
            WriteLine();

            foreach(var i in items)
            {
                WriteLine(i.Name);
            }

            WriteLine();

            Write("Item: ");

            string recipeItem = ReadLine();

            FactorioItem item = items.Find(x => x.Name == recipeItem);

            do
            {
                string itemName;
                int quantity;

                Clear();
                WriteLine($"Add recipe to {item.Name}");
                WriteLine();

                foreach (var i in items)
                {
                    if(i.Name != item.Name)                 
                        WriteLine(i.Name);
                }

                WriteLine();
                Write("Item name: ");
                itemName = ReadLine();
                Write("Item quantity: ");
                quantity = Convert.ToInt32(ReadLine());

                item.AddRecipeItem(items.Find(x => x.Name == itemName), quantity);

                WriteLine();
                Write("Do you want to add another item to the recipe?(y/n)");

            } while (ReadKey(true).KeyChar == 'y');

            FactorioXmlDal.SaveItems(items, path);
            
        }

        static void AddItem()
        {
            string name;
            int quantity;
            double crafttime;

            Clear();
            WriteLine("Add new item");
            WriteLine();
            Write("Name: ");
            name = ReadLine();

            if(items.Find(x => x.Name == name) != null)
            {
                WriteLine("Error: Item already exists!");
                ReadKey();
                return;
            }

            Write("Quantity: ");
            quantity = Convert.ToInt32(ReadLine());
            Write("Crafttime: ");
            crafttime = Convert.ToDouble(ReadLine());

            items.Add(new FactorioItem(name, quantity, crafttime));

            FactorioXmlDal.SaveItems(items, path);

        }
        #endregion
    }
}