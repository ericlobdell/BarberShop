using System;

namespace BarberShop.Models
{
    public class ReservationViewModel
    {
        double _averageCutTimeMinutes = 16.5;

        public int Id { get; }
        public DateTime ReservationTime { get; }
        public DateTime? InChairTime { get; }
        public bool IsInChair => InChairTime.HasValue;
        public int BarberId { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
        public TimeSpan WaitTime { get; }

        public ReservationViewModel(Reservation reservation, int position)
        {
            Id = reservation.Id;
            ReservationTime = reservation.ReservationTime;
            InChairTime = reservation.InChairTime;
            BarberId = reservation.BarberId;
            Name = reservation.Name;
            PhoneNumber = reservation.PhoneNumber;
            WaitTime = TimeSpan.FromMinutes(position * _averageCutTimeMinutes);
        }
    }
}
