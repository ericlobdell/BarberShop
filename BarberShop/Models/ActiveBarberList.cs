using System;
using System.Collections.Generic;
using BarberShop.Services;

namespace BarberShop.Models
{
    public class ActiveBarberList
    {
        List<Barber> _barbers;

        public ActiveBarberList(List<Barber> barbers)
        {
            Guards
                .Require(barbers, "Active barber list cannot be null or empty")
                .ThrowIf(barbers.Count > 3, "There can only be up to three active barbers");

            _barbers = barbers;
        }
    }
}
