﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Factorio.DAL
{
    public class FactorioItemJsonDal
    {
        public string Path { get; set; }

        public FactorioItemJsonDal(string _path)
        {
            Path = _path;
        }

        
    }
}
