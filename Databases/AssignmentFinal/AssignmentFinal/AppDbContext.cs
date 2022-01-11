using AssignmentFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssignmentFinal;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
        dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
        dateTime => DateOnly.FromDateTime(dateTime))
    {
    }
}

public class DateOnlyComparer : ValueComparer<DateOnly>
{
    public DateOnlyComparer() : base(
        (d1, d2) => d1.DayNumber == d2.DayNumber,
        d => d.GetHashCode())
    {
    }
}

public class TimeOnlyConverter : ValueConverter<TimeOnly, TimeSpan>
{
    public TimeOnlyConverter() : base(
        timeOnly => timeOnly.ToTimeSpan(),
        timeSpan => TimeOnly.FromTimeSpan(timeSpan))
    {
    }
}

public class TimeOnlyComparer : ValueComparer<TimeOnly>
{
    public TimeOnlyComparer() : base(
        (t1, t2) => t1.Ticks == t2.Ticks,
        t => t.GetHashCode())
    {
    }
}

public class AppDbContext : DbContext
{
    public DbSet<Booking> Booking { get; set; }
    public DbSet<CategorisedIn> CategorisedIn { get; set; }
    public DbSet<Contain> Contains { get; set; }
    public DbSet<CsDish> CsDish { get; set; }
    public DbSet<Cuisine> Cuisine { get; set; }
    public DbSet<Dish> Dish { get; set; }
    public DbSet<Eatery> Eatery { get; set; }
    public DbSet<Event> Event { get; set; }
    public DbSet<EventSession> EventSession { get; set; }
    public DbSet<EventType> EventType { get; set; }
    public DbSet<FoodCategory> FoodCategory { get; set; }
    public DbSet<Ingredient> Ingredient { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<Passenger> Passenger { get; set; }
    public DbSet<PassengerContactNo> PassengerContactNo { get; set; }
    public DbSet<Reservation> Reservation { get; set; }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<DateOnly>().HaveConversion<DateOnlyConverter, DateOnlyComparer>()
            .HaveColumnType("date");
        configurationBuilder.Properties<TimeOnly>().HaveConversion<TimeOnlyConverter, TimeOnlyComparer>()
            .HaveColumnType("time");
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Passenger>().HasCheckConstraint("CK_Passenger_Gender", "[PgrGender] IN ('M', 'F')");

        modelBuilder.Entity<PassengerContactNo>().HasKey(p => new { p.PassengerId, p.ContactNo });
        modelBuilder.Entity<EventSession>().HasKey(e => new { e.SessionNo, e.EventId });
        modelBuilder.Entity<Contain>().HasKey(c => new { c.DishId, c.IngredientId });
        modelBuilder.Entity<CategorisedIn>().HasKey(c => new { c.DishId, c.FoodCategoryId });
        modelBuilder.Entity<Order>().HasKey(o => new { o.PassengerId, o.CsDishDishId, o.CsDishPrice, o.DateTime });
        modelBuilder.Entity<CsDish>().HasKey(p => new { p.DishId, p.Price });
        modelBuilder.Entity<CsDish>().HasMany(c => c.Orders).WithOne(o => o.CsDish)
            .HasForeignKey(o => new { o.CsDishDishId, o.CsDishPrice });

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost; Database=AssignmentFinal; User Id=SA; Password=QinGuan12345!");
    }
}