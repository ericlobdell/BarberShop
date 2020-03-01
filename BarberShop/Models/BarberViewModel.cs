using System.Collections.Generic;
using System.Linq;

namespace BarberShop.Models
{
    public class BarberViewModel
    {
        public int Id { get; }
        public string Name { get; }
        public List<ReservationViewModel> Reservations { get; }
        public int CustomerCount => Reservations.Count;

        public BarberViewModel(Barber barber, List<ReservationViewModel> reservations)
        {
            Id = barber.Id;
            Name = barber.Name;
            Reservations = reservations
                .Where(r => r.BarberId == Id)
                .ToList();
        }
    }
}
