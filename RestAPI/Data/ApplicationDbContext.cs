using Microsoft.EntityFrameworkCore;
using RestAPI.Models;

namespace RestAPI.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public DbSet<HotelBooking> Bookings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
