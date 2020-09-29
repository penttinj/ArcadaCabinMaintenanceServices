using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Models
{
    public class CabinsResponse
    {
        public bool success { get; set; }
        public string message{ get; set; }
        public Cabin[] cabins { get; set; }
    }
}
