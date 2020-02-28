using System;
using System.Collections.Generic;
using BarberShop.Models;

namespace BarberShop.Repositories
{
    public class BarberRepository: IBarberRepository
    {
        List<Reservation> _reservations;

        public BarberRepository()
        {
            var firstReservationTime = DateTime.Now;

            _reservations = new List<Reservation>
            {
                new Reservation
                {
                    ReservationTime = firstReservationTime,
                    BarberId = 1,
                    Name = "Eric",
                    PhoneNumber = "555-1234"
                },
                new Reservation
                {
                    ReservationTime = firstReservationTime.AddMinutes(5),
                    BarberId = 2,
                    Name = "Bill",
                    PhoneNumber = "555-1235"
                },
                new Reservation
                {
                    ReservationTime = firstReservationTime.AddMinutes(15),
                    BarberId = 0,
                    Name = "Jen",
                    PhoneNumber = "555-1236"
                },
            };
        }

        public int CreateReservation(Reservation r)
        {
            _reservations.Add(r);
            return _reservations.Count;
        }

        public ActiveBarberList GetActiveBarbers()
        {
            var activeBarbers = new List<Barber>
            {
                new Barber
                {
                    Id = 1,
                    Name = "Joe"
                },
                new Barber
                {
                    Id = 2,
                    Name = "Gary"
                }
            };

            return new ActiveBarberList(activeBarbers);
        }

        public List<Reservation> GetReservations()
        {
            return _reservations;
        }
    }

    public interface IBarberRepository
    {
        ActiveBarberList GetActiveBarbers();
        List<Reservation> GetReservations();
        int CreateReservation(Reservation r);
    }
}
