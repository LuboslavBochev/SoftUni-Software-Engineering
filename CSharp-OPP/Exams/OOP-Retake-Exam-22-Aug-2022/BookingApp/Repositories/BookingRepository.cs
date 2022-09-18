﻿using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model) => this.bookings.Add(model);

        public IReadOnlyCollection<IBooking> All() => this.bookings;

        public IBooking Select(string criteria) => this.bookings.FirstOrDefault(b => b.BookingNumber.ToString() == criteria);
    }
}
