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

        public int CreateReservation(Reservation reservation)
        {
            reservation.Id = _reservations.Max(r => r.Id) + 1;

            _reservations.Add(reservation);

            return _reservations.Count;
        }

        public Reservation GetReservation(int reservationId) => 
            _reservations.FirstOrDefault(r => r.Id == reservationId);

        public List<Reservation> GetReservations() => _reservations;

        public void SaveReservation(Reservation reservation)
        { 
            var toUpdate = _reservations.Find(r => r.Id == reservation.Id);
            toUpdate = reservation;
        }
    }

    public interface IReservationRepository
    {
        List<Reservation> GetReservations();
        Reservation GetReservation(int reservationId);
        int CreateReservation(Reservation reservation);
        void SaveReservation(Reservation reservation);
    }
}
