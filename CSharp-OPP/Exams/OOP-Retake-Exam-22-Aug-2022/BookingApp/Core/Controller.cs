using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly HotelRepository hotels;

        public Controller()
        {
            this.hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            this.hotels.AddNew(new Hotel(hotelName, category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            IHotel checkHotel = this.hotels.All().Where(h => h.Category == category).FirstOrDefault();

            if (checkHotel == null) return $"{category} star hotel is not available in our platform.";

            List<IHotel> orderedHotels = this.hotels.All().OrderBy(h => h.FullName).ToList();
            List<IRoom> orderedRooms = new List<IRoom>();
            foreach (var hotel in orderedHotels)
            {
                foreach (var room in hotel.Rooms.All())
                {
                    if (room.PricePerNight > 0) orderedRooms.Add(room);
                }
            }
            orderedRooms = orderedRooms.OrderBy(r => r.BedCapacity).ToList();

            IRoom chosedRoom = orderedRooms.Where(r => r.BedCapacity >= (adults + children)).FirstOrDefault();

            if (chosedRoom == null) return "We cannot offer appropriate room for your request.";

            IBooking booking = new Booking(chosedRoom, duration, adults, children, checkHotel.Bookings.All().Count + 1);

            checkHotel.Bookings.AddNew(booking);
            return $"Booking number {booking.BookingNumber} for {checkHotel.FullName} hotel is successful!";
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder str = new StringBuilder();

            str.AppendLine($"Hotel name: {hotelName}");
            str.AppendLine($"--{hotel.Category} star hotel");
            str.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            str.AppendLine("--Bookings:");
            if (hotel.Bookings.All().Count == 0)
            {
                str.AppendLine("none");
                return str.ToString().TrimEnd();
            }
            foreach (var book in hotel.Bookings.All())
            {
                str.AppendLine(book.BookingSummary());
            }
            return str.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != "Apartment" && roomTypeName != "DoubleBed" && roomTypeName != "Studio")
                throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room == null)
            {
                return "Room type is not created yet!";
            }

            if (room.PricePerNight != 0) throw new InvalidOperationException(string.Format("Price is already set!"));

            room.SetPrice(price);
            return $"Price of {room.GetType().Name} room type in {hotelName} hotel is set!";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = this.hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return "Room type is already created!";
            }

            IRoom room = null;

            switch (roomTypeName)
            {
                case "Apartment":
                    room = new Apartment();
                    break;

                case "DoubleBed":
                    room = new DoubleBed();
                    break;

                case "Studio":
                    room = new Studio();
                    break;

                default:
                    throw new ArgumentException(string.Format(ExceptionMessages.RoomTypeIncorrect));
            }
            hotel.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
