﻿using Factorio;
using Factorio.Entities;
using FactorioWpf.ViewModels;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FactorioWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Get path to AppData
            string itemListPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            // Get path to ItemList.xml
            itemListPath = Path.Combine(itemListPath, @"FactorioCalculator");

            this.DataContext = new MainWindowViewModell(new FactorioLogic(itemListPath));
        }

        /// <summary>
        /// Close every window from this application if this window is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
