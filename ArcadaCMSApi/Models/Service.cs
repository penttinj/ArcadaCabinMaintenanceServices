﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Models
{
    public class Service
    {
#pragma warning disable IDE1006 // Naming Styles
        public int id { get; set; }
#pragma warning restore IDE1006 // Naming Styles
        public string Type { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
