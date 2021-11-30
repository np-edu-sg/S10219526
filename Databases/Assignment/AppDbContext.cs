using Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment
{
    public class AppDbContext : DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ActivityBooking> ActivityBookings { get; set; }
        public DbSet<ActivitySlot> ActivitySlots { get; set; }
        public DbSet<CabinService> CabinServices { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<ClassBooking> ClassBookings { get; set; }
        public DbSet<DiningLocation> DiningLocations { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishOrder> DishOrders { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Table> Tables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost; Database=Assignment; User Id=SA; Password=Password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>().HasMany(r => r.Tables).WithOne(t => t.Reservation).IsRequired(false);
        }
    }
}