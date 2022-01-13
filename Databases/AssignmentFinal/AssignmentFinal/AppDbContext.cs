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
        modelBuilder.Entity<Order>().HasKey(o => new { o.PassengerId, o.DateTime, o.DishId });
        modelBuilder.Entity<CsDish>().HasKey(p => new { p.DishId, p.Price });

        var bob = new Passenger
        {
            Id = 1,
            Name = "Bob",
            Email = "bob@gmail.com",
            DOB = new DateOnly(2000, 01, 01),
            Gender = 'M',
        };

        var chicken = new Ingredient
        {
            Id = 1,
            Name = "Chicken",
        };

        var rice = new Ingredient
        {
            Id = 2,
            Name = "Rice"
        };

        var chinese = new Cuisine
        {
            Id = 1,
            CuisineName = "Chinese"
        };

        var halal = new FoodCategory
        {
            Id = 1,
            Name = "Halal",
            Description = "Halal food for Muslims"
        };

        modelBuilder.Entity<Passenger>().HasData(bob);
        modelBuilder.Entity<Ingredient>().HasData(chicken, rice);
        modelBuilder.Entity<Cuisine>().HasData(chinese);
        modelBuilder.Entity<FoodCategory>().HasData(halal);

        // chickenRice.Contains.Add(new Contain
        // {
        //     DishId = chickenRice.Id,
        //     IngredientId = chicken.Id
        // });
        //
        // chickenRice.Contains.Add(new Contain
        // {
        //     DishId = chickenRice.Id,
        //     IngredientId = rice.Id
        // });

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost; Database=AssignmentFinal; User Id=SA; Password=QinGuan12345!");
    }
}