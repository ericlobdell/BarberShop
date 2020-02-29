using System;
using System.Collections.Generic;
using BarberShop.Models;
using BarberShop.Repositories;
using BarberShop.Services;
using Moq;
using Xunit;

namespace BarberShop.Tests
{
    public class BarberServiceTests
    {
        Mock<IBarberRepository> _mockBarberRepository;

        public BarberServiceTests()
        {
            _mockBarberRepository = new Mock<IBarberRepository>();
        }

        BarberService GetSut() =>
            new BarberService(_mockBarberRepository.Object);

        [Fact]
        public void GetActiveBarbers_throws_when_repo_returns_null()
        {
            List<Barber> barbers = null;

            _mockBarberRepository.Setup(r => r.GetActiveBarbers())
                .Returns(barbers);

            var sut = GetSut();

            Assert.Throws<ArgumentException>(() => sut.GetActiveBarbers());
        }

        [Fact]
        public void GetActiveBarbers_throws_when_repo_returns_empty_list()
        {
            List<Barber> barbers = new List<Barber>();

            _mockBarberRepository.Setup(r => r.GetActiveBarbers())
                .Returns(barbers);

            var sut = GetSut();

            Assert.Throws<ArgumentException>(() => sut.GetActiveBarbers());
        }

        [Fact]
        public void GetActiveBarbers_throws_when_repo_returns_more_than_threee_active_barbers()
        {
            List<Barber> barbers = new List<Barber>
            {
                new Barber(),
                new Barber(),
                new Barber(),
                new Barber()
            };

            _mockBarberRepository.Setup(r => r.GetActiveBarbers())
                .Returns(barbers);

            var sut = GetSut();

            Assert.Throws<ArgumentException>(() => sut.GetActiveBarbers());
        }
    }
}
