using System.Collections.Generic;
using System.Linq;

namespace BarberShop.Models
{
    public class HomePageViewModel
    {
        public List<BarberViewModel> Barbers { get; }
        public List<ReservationViewModel> WaitingReservations { get; }
        public List<ReservationViewModel> CompleteReservations { get; }

        public HomePageViewModel(List<Barber> barbers, List<Reservation> reservations)
        {
            WaitingReservations = reservations
                .Where(r => !r.InChairTime.HasValue)
                .Select((r, i) => new ReservationViewModel(r, i, barbers))
                .OrderBy(vm => vm.Position)
                .ToList();

            CompleteReservations = reservations
                .Where(r => r.InChairTime.HasValue)
                .Select((r, i) => new ReservationViewModel(r, int.MaxValue, barbers))
                .ToList();

            Barbers = barbers
                .Select(b => new BarberViewModel(b, WaitingReservations))
                .ToList();
        }
    }
}
