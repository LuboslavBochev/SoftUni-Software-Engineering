using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get => this.residenceDuration;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => this.adultsCount;
            private set
            {
                if(value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => this.childrenCount;
            private set
            {
                if(value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            StringBuilder str = new StringBuilder();

            str.AppendLine($"Booking number: {this.BookingNumber}");
            str.AppendLine($"Room type: {this.Room.GetType().Name}");
            str.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            str.AppendLine($"Total amount paid: {TotalPaid():F2}$");

            return str.ToString().TrimEnd();
        }

        private double TotalPaid()
        {
            return Math.Round(this.ResidenceDuration * this.Room.PricePerNight, 2);
        }
    }
}
