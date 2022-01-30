using AssignmentFinal.Models;
using Microsoft.EntityFrameworkCore;

namespace AssignmentFinal
{
    public partial class AssignmentFinalContext : DbContext
    {
        public AssignmentFinalContext()
        {
        }

        public AssignmentFinalContext(DbContextOptions<AssignmentFinalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<CsDish> CsDishes { get; set; } = null!;
        public virtual DbSet<Cuisine> Cuisines { get; set; } = null!;
        public virtual DbSet<Dish> Dishes { get; set; } = null!;
        public virtual DbSet<Eatery> Eateries { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventSession> EventSessions { get; set; } = null!;
        public virtual DbSet<EventType> EventTypes { get; set; } = null!;
        public virtual DbSet<FoodCategory> FoodCategories { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Passenger> Passengers { get; set; } = null!;
        public virtual DbSet<PassengerContactNo> PassengerContactNos { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(
                    "Server=localhost; Database=AssignmentFinal; User Id=SA; Password=XnSvZs26acf7rh");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("BookingID");

                entity.Property(e => e.BookStatus).HasMaxLength(1);

                entity.Property(e => e.EventSessionEventId).HasColumnName("EventSessionEventID");

                entity.Property(e => e.PgrId).HasColumnName("PgrID");

                entity.HasOne(d => d.Pgr)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.PgrId);

                entity.HasOne(d => d.EventSession)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => new {d.EventSessionSessionNo, d.EventSessionEventId});
            });

            modelBuilder.Entity<CsDish>(entity =>
            {
                entity.HasKey(e => new {e.DishId, e.Price});

                entity.ToTable("CsDish");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.CsDishes)
                    .HasForeignKey(d => d.DishId);
            });

            modelBuilder.Entity<Cuisine>(entity =>
            {
                entity.ToTable("Cuisine");

                entity.Property(e => e.CuisineId).HasColumnName("CuisineID");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.ToTable("Dish");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.Property(e => e.CuisineId).HasColumnName("CuisineID");

                entity.Property(e => e.EatyId).HasColumnName("EatyID");

                entity.HasOne(d => d.Cuisine)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.CuisineId);

                entity.HasOne(d => d.Eaty)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.EatyId);

                entity.HasMany(d => d.Fcs)
                    .WithMany(p => p.Dishes)
                    .UsingEntity<Dictionary<string, object>>(
                        "CategorisedIn",
                        l => l.HasOne<FoodCategory>().WithMany().HasForeignKey("FcId"),
                        r => r.HasOne<Dish>().WithMany().HasForeignKey("DishId"),
                        j =>
                        {
                            j.HasKey("DishId", "FcId");

                            j.ToTable("CategorisedIn");

                            j.IndexerProperty<int>("DishId").HasColumnName("DishID");

                            j.IndexerProperty<int>("FcId").HasColumnName("FcID");
                        });

                entity.HasMany(d => d.Ingreds)
                    .WithMany(p => p.Dishes)
                    .UsingEntity<Dictionary<string, object>>(
                        "Contain",
                        l => l.HasOne<Ingredient>().WithMany().HasForeignKey("IngredId"),
                        r => r.HasOne<Dish>().WithMany().HasForeignKey("DishId"),
                        j =>
                        {
                            j.HasKey("DishId", "IngredId");

                            j.ToTable("Contains");

                            j.IndexerProperty<int>("DishId").HasColumnName("DishID");

                            j.IndexerProperty<int>("IngredId").HasColumnName("IngredID");
                        });
            });

            modelBuilder.Entity<Eatery>(entity =>
            {
                entity.HasKey(e => e.EatyId);

                entity.ToTable("Eatery");

                entity.Property(e => e.EatyId).HasColumnName("EatyID");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.Etid).HasColumnName("ETID");

                entity.HasOne(d => d.Et)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.Etid);
            });

            modelBuilder.Entity<EventSession>(entity =>
            {
                entity.HasKey(e => new {e.SessionNo, e.EventId});

                entity.ToTable("EventSession");

                entity.Property(e => e.SessionNo).ValueGeneratedOnAdd();

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventSessions)
                    .HasForeignKey(d => d.EventId);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.Etid);

                entity.ToTable("EventType");

                entity.Property(e => e.Etid).HasColumnName("ETID");

                entity.Property(e => e.Etname).HasColumnName("ETName");
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.HasKey(e => e.FcId);

                entity.ToTable("FoodCategory");

                entity.Property(e => e.FcId).HasColumnName("FcID");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.IngredId);

                entity.ToTable("Ingredient");

                entity.Property(e => e.IngredId).HasColumnName("IngredID");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => new {e.PgrId, e.OrderDateTime, e.DishId})
                    .HasName("PK_Order");

                entity.Property(e => e.PgrId).HasColumnName("PgrID");

                entity.Property(e => e.DishId).HasColumnName("DishID");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DishId);

                entity.HasOne(d => d.Pgr)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PgrId);
            });

            modelBuilder.Entity<Passenger>(entity =>
            {
                entity.HasKey(e => e.PgrId);

                entity.ToTable("Passenger");

                entity.Property(e => e.PgrId).HasColumnName("PgrID");

                entity.Property(e => e.PgrDob)
                    .HasColumnType("date")
                    .HasColumnName("PgrDOB");

                entity.Property(e => e.PgrGender).HasMaxLength(1);
            });

            modelBuilder.Entity<PassengerContactNo>(entity =>
            {
                entity.HasKey(e => new {e.PgrId, e.ContactNo});

                entity.ToTable("PassengerContactNo");

                entity.Property(e => e.PgrId).HasColumnName("PgrID");

                entity.HasOne(d => d.Pgr)
                    .WithMany(p => p.PassengerContactNos)
                    .HasForeignKey(d => d.PgrId);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.ReservId);

                entity.ToTable("Reservation");

                entity.Property(e => e.ReservId).HasColumnName("ReservID");

                entity.Property(e => e.EatyId).HasColumnName("EatyID");

                entity.Property(e => e.PgrId).HasColumnName("PgrID");

                entity.HasOne(d => d.Eaty)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.EatyId);

                entity.HasOne(d => d.Pgr)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.PgrId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
        }
    }
}