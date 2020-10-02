using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Models
{
    public class ReservationResponse : Reservation
    {
        public string ServiceType { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
