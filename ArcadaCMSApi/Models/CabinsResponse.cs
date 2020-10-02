using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Models
{
    public class CabinsResponse
    {
#pragma warning disable IDE1006 // Naming Styles
        public bool success { get; set; }
        public string message { get; set; }
        public Cabin[] cabins { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
