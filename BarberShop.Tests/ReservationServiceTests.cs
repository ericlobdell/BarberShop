using System;
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

        [Fact]
        public void AssignReservation_throws_if_reservation_not_found_with_id()
        {
            int reservationId = _testReservation.Id;
            int barberId = _testBarber.Id;

            _mockReservationRepository.Setup(r => r.GetReservations())
                .Returns(new List<Reservation>());

            var sut = GetSut();

            var ex = Assert.Throws<ArgumentException>(() => sut.AssignReservation(reservationId, barberId));

            Assert.Contains($"{_testReservation.Id}", ex.Message);
        }

        [Fact]
        public void AssignReservation_throws_if_assigning_to_unknown_barber_id()
        {
            int reservationId = _testReservation.Id;
            int unknownBarberId = _testBarber.Id + 1;

            var sut = GetSut();

            var ex = Assert.Throws<ArgumentException>(() => sut.AssignReservation(reservationId, unknownBarberId));

            Assert.Contains($"{unknownBarberId}", ex.Message);
        }

        [Fact]
        public void AssignReservation_does_not_update_repo_when_unknown_barber_id()
        {
            int reservationId = _testReservation.Id;
            int unknownBarberId = _testBarber.Id + 1;

            var sut = GetSut();

            Assert.Throws<ArgumentException>(() => sut.AssignReservation(reservationId, unknownBarberId));

            _mockReservationRepository.Verify(r => r.SaveReservation(It.IsAny<Reservation>()), Times.Never);
        }

        [Fact]
        public void AssignReservation_assigns_barber_id_when_known_barber_id()
        {
            int reservationId = _testReservation.Id;
            int knownBarberId = _testBarber.Id;

            var sut = GetSut();

            sut.AssignReservation(reservationId, knownBarberId);

            _mockReservationRepository.Verify(r => 
                r.SaveReservation(It.Is<Reservation>(r => r.BarberId == knownBarberId)), Times.Once);
        }

        [Fact]
        public void AssignReservation_removes_barber_id_when_zero()
        {
            int reservationId = _testReservation.Id;
            int knownBarberId = _testBarber.Id;

            _testReservation.BarberId = knownBarberId;

            var sut = GetSut();

            sut.AssignReservation(reservationId, 0);

            _mockReservationRepository.Verify(r =>
                r.SaveReservation(It.Is<Reservation>(r => r.BarberId == 0)), Times.Once);
        }
    }
}
