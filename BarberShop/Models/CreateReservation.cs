using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberShop.Models
{
    public class CreateReservation
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public int BarberId { get; set; }
    }
}
