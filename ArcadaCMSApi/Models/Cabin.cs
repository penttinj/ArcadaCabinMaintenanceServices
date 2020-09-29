using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Models
{
    public class Cabin
    {
#pragma warning disable IDE1006 // Naming Styles
        public string _id { get; set; }
        public string ownerName { get; set; }
        public string address { get; set; }
        public int squarageProperty { get; set; }
        public int squarageCabin { get; set; }
        public Boolean sauna { get; set; }
        public Boolean beachfront { get; set; }
        public Owner owner { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }
}
