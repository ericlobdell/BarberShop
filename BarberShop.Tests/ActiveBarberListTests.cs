using System;
using System.Collections.Generic;
using BarberShop.Models;
using Xunit;

namespace BarberShop.Tests
{
    public class ActiveBarberListTests
    {
        [Fact]
        public void Throws_when_list_null()
        {
            List<Barber> barbers = null;

            Assert.Throws<ArgumentException>(() => new ActiveBarberList(barbers));
        }

        [Fact]
        public void Throws_when_list_empty()
        {
            List<Barber> barbers = new List<Barber>();

            Assert.Throws<ArgumentException>(() => new ActiveBarberList(barbers));
        }

        [Fact]
        public void Throws_when_more_than_three_barbers_in_list()
        {
            List<Barber> barbers = new List<Barber>
            {
                new Barber(),
                new Barber(),
                new Barber(),
                new Barber()
            };

            Assert.Throws<ArgumentException>(() => new ActiveBarberList(barbers));
        }
    }
}
