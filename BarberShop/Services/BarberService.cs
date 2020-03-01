using System.Collections.Generic;
using BarberShop.Models;
using BarberShop.Repositories;

namespace BarberShop.Services
{
    public class BarberService : IBarberService
    {
        IBarberRepository _barberRepository;

        public BarberService(IBarberRepository barberRepository)
        {
            _barberRepository = barberRepository;
        }


        public List<Barber> GetActiveBarbers()
        {
            var activeBarbers = _barberRepository.GetActiveBarbers();

            Guards
                .Require(activeBarbers, "Active barbers null")
                .ThrowIf(
                    (activeBarbers.Count == 0, "Active barber list cannot be null or empty"),
                    (activeBarbers.Count > 3, "There can only be up to three active barbers"));

            return activeBarbers;
        }
    }

    public interface IBarberService
    {
        List<Barber> GetActiveBarbers();
    }
}
