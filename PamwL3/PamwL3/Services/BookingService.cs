using PamwL3.Data;
using PamwL3.Models;
using System.Collections.Generic;

namespace PamwL3.Services
{
    public class BookingService
    {
        private readonly ApiContext _context;

        public BookingService(ApiContext context)
        {
            _context = context;
        }

        public List<HotelBooking> GetAllBookings()
        {
            return _context.Bookings.ToList();
        }

        public HotelBooking GetBooking(int id)
        {
            return _context.Bookings.Find(id);
        }

        public void CreateBooking(HotelBooking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public void UpdateBooking(int id, HotelBooking booking)
        {
            var bookingInDb = _context.Bookings.Find(id);

            if (bookingInDb == null)
            {
                return;
            }

            bookingInDb = booking;
            _context.SaveChanges();
        }

        public void DeleteBooking(int id)
        {
            var bookingInDb = _context.Bookings.Find(id);

            if (bookingInDb == null)
            {
                return;
            }

            _context.Bookings.Remove(bookingInDb);
            _context.SaveChanges();
        }
    }

    
}
