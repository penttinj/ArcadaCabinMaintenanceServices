using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Models
{
    public class Reservation
    {
        public int id { get; set; }
        public int ServiceId { get; set; }
        public string CabinId { get; set; }
        public string CabinOwnerName { get; set; }
        public string CabinEmail { get; set; }
        public string CabinAddress { get; set; }
        public string ScheduledDate { get; set; }
    }
}
