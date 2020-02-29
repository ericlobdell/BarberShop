using System.Collections.Generic;
using BarberShop.Models;
using BarberShop.Repositories;
using BarberShop.Services;
using Moq;
using Xunit;

namespace BarberShop.Tests
{
    public class ReservationServiceTests
    {
        Mock<IReservationRepository> _mockReservationRepository;
        Mock<IBarberService> _mockBarberService;

        Reservation _testReservation = new Reservation
        {
            Id = 1
        };
        Barber _testBarber = new Barber
        {
            Id = 2
        };

        public ReservationServiceTests()
        {
            _mockBarberService = new Mock<IBarberService>();
            _mockBarberService.Setup(s => s.GetActiveBarbers())
                .Returns(new List<Barber> { _testBarber });

            _mockReservationRepository = new Mock<IReservationRepository>();
            _mockReservationRepository.Setup(r => r.GetReservations())
                .Returns(new List<Reservation>{ _testReservation });
        }

        ReservationService GetSut() =>
            new ReservationService(_mockReservationRepository.Object, _mockBarberService.Object);

        [Fact]
        public void AssignReservation_gets_barbers_from_service()
        {
            int reservationId = _testReservation.Id;
            int barberId = _testBarber.Id;

            var sut = GetSut();

            sut.AssignReservation(reservationId, barberId);

            _mockBarberService.Verify(s => s.GetActiveBarbers(), Times.Once);
        }
    }
}
