using System;
using System.Collections.Generic;
using System.Linq;
using BarberShop.Models;

namespace BarberShop.Repositories
{
    public class ReservationRepository: IReservationRepository
    {
        List<Reservation> _reservations;


        public ReservationRepository()
        {
            var firstReservationTime = DateTime.Now;

            _reservations = new List<Reservation>
            {
                new Reservation
                {
                    Id = 1,
                    ReservationTime = firstReservationTime,
                    BarberId = 1,
                    Name = "Eric",
                    PhoneNumber = "555-1234"
                },
                new Reservation
                {
                    Id = 2,
                    ReservationTime = firstReservationTime.AddMinutes(5),
                    BarberId = 2,
                    Name = "Bill",
                    PhoneNumber = "555-1235"
                },
                new Reservation
                {
                    Id = 3,
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


        public List<Reservation> GetReservations()
        {
            return _reservations;
        }

        public void SaveReservation(Reservation reservation)
        { 
            var toUpdate = _reservations.Find(r => r.Id == reservation.Id);
            toUpdate = reservation;
        }
    }

    public interface IReservationRepository
    {
        List<Reservation> GetReservations();
        int CreateReservation(Reservation reservation);
        void SaveReservation(Reservation reservation);
    }
}
