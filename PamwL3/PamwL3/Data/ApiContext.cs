using Microsoft.EntityFrameworkCore;
using PamwL3.Models;

namespace PamwL3.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HotelBooking> Bookings { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }
    }
}
