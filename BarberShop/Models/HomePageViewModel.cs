using System.Collections.Generic;
using System.Linq;

namespace BarberShop.Models
{
    public class HomePageViewModel
    {
        public List<BarberViewModel> Barbers { get; }
        public List<ReservationViewModel> Reservations { get; }

        public HomePageViewModel(List<Barber> barbers, List<Reservation> reservations)
        {
            Reservations = reservations
                .Select((r, i) => new ReservationViewModel(r, i))
                .ToList();

            Barbers = barbers
                .Select(b => new BarberViewModel(b, Reservations))
                .ToList();
        }
    }
}
