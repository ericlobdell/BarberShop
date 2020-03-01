using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BarberShop.Models;
using BarberShop.Services;

namespace BarberShop.Controllers
{
    public class HomeController : Controller
    {
        IReservationService _reservationService;
        IBarberService _barberService;

        public HomeController(IReservationService reservationService, IBarberService barberService)
        {
            _reservationService = reservationService;
            _barberService = barberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        private HomePageViewModel GetViewModel()
        {
            var activeBarbers = _barberService.GetActiveBarbers();
            var reservations = _reservationService.GetReservations();

            return new HomePageViewModel(activeBarbers, reservations);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
