﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Models
{
    public class Service
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
