using System;
using System.Collections.Generic;
using System.Linq;

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
        public string BarberName { get; set; }
        public bool HasPreferredBarber => BarberId > 0;
        public string Name { get; }
        public string PhoneNumber { get; }
        public int Position { get; }
        public TimeSpan WaitTime => IsInChair 
            ? TimeSpan.Zero 
            : TimeSpan.FromMinutes(Position * _averageCutTimeMinutes);
        public string WaitTimeDisplay => IsInChair 
            ? string.Empty 
            : $"approx {WaitTime.TotalMinutes} min - {DateTime.Now.AddMinutes(WaitTime.TotalMinutes).ToShortTimeString()}";

        public ReservationViewModel(Reservation reservation, int position, List<Barber> barbers)
        {
            Id = reservation.Id;
            ReservationTime = reservation.ReservationTime;
            InChairTime = reservation.InChairTime;
            BarberId = reservation.BarberId;
            BarberName = BarberId > 0 ? barbers.First(b => b.Id == BarberId).Name : string.Empty;
            Name = reservation.Name;
            PhoneNumber = reservation.PhoneNumber;
            Position = position;
        }
    }
}
