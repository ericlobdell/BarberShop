using System.Collections.Generic;

namespace BarberShop.Models
{
    public class HomePageViewModel
    {
        double _averageCutTimeMinutes = 16.5;

        public List<Barber> Barbers { get; }
        public List<Reservation> Reservations { get; }

        public HomePageViewModel(List<Barber> barbers, List<Reservation> reservations)
        {
            Barbers = barbers;
            Reservations = reservations;
        }
    }
}
