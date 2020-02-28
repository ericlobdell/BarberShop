using System;
using System.Collections.Generic;
using BarberShop.Models;
using BarberShop.Repositories;

namespace BarberShop.Services
{
    public class BarberService: IBarberService
    {
        IBarberRepository _barberRepository;

        public BarberService(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }

        public int CreateReservation(Reservation r)
        {
            return _barberRepository.CreateReservation(r);
        }

        public ActiveBarberList GetActiveBarbers()
        {
            return _barberRepository.GetActiveBarbers();
        }

        public List<Reservation> GetReservations()
        {
            return _barberRepository.GetReservations();
        }
    }

    public interface IBarberService
    {
        ActiveBarberList GetActiveBarbers();
        List<Reservation> GetReservations();
        int CreateReservation(Reservation r);
    }
}
