using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BarberShop.Models;
using BarberShop.Services;
using System;

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
            var vm = GetViewModel();
            return View(vm);
        }

        [Route("InChair/{reservationId}")]
        public IActionResult InChair(int reservationId)
        {
            _reservationService.CompleteReservation(reservationId);

            return ReloadPage();
        }

        [Route("RemovePreferredBarber/{reservationId}")]
        public IActionResult RemovePreferredBarber(int reservationId)
        {
            _reservationService.AssignReservation(reservationId, 0);

            return ReloadPage();
        }

        private HomePageViewModel GetViewModel()
        {
            var activeBarbers = _barberService.GetActiveBarbers();
            var reservations = _reservationService.GetReservations();

            return new HomePageViewModel(activeBarbers, reservations);
        }

        [HttpPost]
        public IActionResult Create(CreateReservation createReservation)
        {
            var newReservation = new Reservation
            {
                Name = createReservation.Name,
                PhoneNumber = createReservation.PhoneNumber,
                BarberId = createReservation.BarberId,
                ReservationTime = DateTime.Now
            };

            _reservationService.CreateReservation(newReservation);

            return ReloadPage();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private IActionResult ReloadPage()
        {
            return Redirect("/");
        }
    }
}
