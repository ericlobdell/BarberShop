using System.Collections.Generic;
using BarberShop.Models;

namespace BarberShop.Repositories
{
    public class BarberRepository: IBarberRepository
    {
        public List<Barber> GetActiveBarbers()
        {
            return new List<Barber>
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
        }
    }

    public interface IBarberRepository
    {
        List<Barber> GetActiveBarbers();
    }
}
