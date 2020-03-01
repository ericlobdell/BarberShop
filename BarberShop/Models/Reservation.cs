using System;
namespace BarberShop.Models
{
    public class Reservation: DbEntity
    {
        public DateTime? InChairTime { get; set; }
        public int BarberId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
