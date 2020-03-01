using System.Collections.Generic;
using System.Linq;
using BarberShop.Models;
using BarberShop.Repositories;

namespace BarberShop.Services
{
    public class ReservationService: IReservationService
    {
        IBarberService _barberService;
        IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository, IBarberService barberService)
        {
            _barberService = barberService;
            _reservationRepository = reservationRepository;
        }

        public int CreateReservation(Reservation r)
        {
            return _reservationRepository.CreateReservation(r);
        }

        public List<Reservation> GetReservations()
        {
            return _reservationRepository.GetReservations();
        }

        public void AssignReservation(int reservationId, int barberId)
        {
            var reservationToUpdate = _reservationRepository
                .GetReservation(reservationId);

            var activeBarbers = _barberService.GetActiveBarbers();

            Guards
                .Require(reservationToUpdate, $"No reservation found with id {reservationId}")
                .ThrowIf(barberId > 0 && !activeBarbers.Any(b => b.Id == barberId), $"No active barber found with id {barberId}");

            reservationToUpdate.BarberId = barberId;

            _reservationRepository.SaveReservation(reservationToUpdate);
        }
    }

    public interface IReservationService
    {
        List<Reservation> GetReservations();
        int CreateReservation(Reservation r);
        void AssignReservation(int reservationId, int barberId);
    }
}
