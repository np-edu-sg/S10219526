﻿// <auto-generated />
using System;
using Assignment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211130073947_RemovePrice")]
    partial class RemovePrice
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Assignment.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DurationSeconds")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Assignment.Models.ActivityBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ActivitySlotActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ActivitySlotDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PassengerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("ActivitySlotActivityId", "ActivitySlotDateTime");

                    b.ToTable("ActivityBookings");
                });

            modelBuilder.Entity("Assignment.Models.ActivitySlot", b =>
                {
                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActivityId", "DateTime");

                    b.ToTable("ActivitySlots");
                });

            modelBuilder.Entity("Assignment.Models.CabinService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ServeBy")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("CabinServices");
                });

            modelBuilder.Entity("Assignment.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IntervalMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Venue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Assignment.Models.ClassBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("PassengerId");

                    b.ToTable("ClassBookings");
                });

            modelBuilder.Entity("Assignment.Models.DiningLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DiningLocations");
                });

            modelBuilder.Entity("Assignment.Models.Dish", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DiningLocationId")
                        .HasColumnType("int");

                    b.Property<string>("Allergens")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsHalal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("bit");

                    b.HasKey("Name", "DiningLocationId");

                    b.HasIndex("DiningLocationId");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("Assignment.Models.DishOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CabinServiceId")
                        .HasColumnType("int");

                    b.Property<int>("DishDiningLocationId")
                        .HasColumnType("int");

                    b.Property<string>("DishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CabinServiceId");

                    b.HasIndex("DishName", "DishDiningLocationId");

                    b.ToTable("DishOrders");
                });

            modelBuilder.Entity("Assignment.Models.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CabinNo")
                        .HasColumnType("int");

                    b.Property<string>("ContactNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("Assignment.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiningLocationId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<int>("TableNo")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PassengerId");

                    b.HasIndex("TableNo", "DiningLocationId")
                        .IsUnique();

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Assignment.Models.Table", b =>
                {
                    b.Property<int>("No")
                        .HasColumnType("int");

                    b.Property<int>("DiningLocationId")
                        .HasColumnType("int");

                    b.HasKey("No", "DiningLocationId");

                    b.HasIndex("DiningLocationId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Assignment.Models.ActivityBooking", b =>
                {
                    b.HasOne("Assignment.Models.Passenger", null)
                        .WithMany("ActivityBookings")
                        .HasForeignKey("PassengerId");

                    b.HasOne("Assignment.Models.ActivitySlot", "ActivitySlot")
                        .WithMany("ActivityBookings")
                        .HasForeignKey("ActivitySlotActivityId", "ActivitySlotDateTime")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ActivitySlot");
                });

            modelBuilder.Entity("Assignment.Models.ActivitySlot", b =>
                {
                    b.HasOne("Assignment.Models.Activity", "Activity")
                        .WithMany("ActivitySlots")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });

            modelBuilder.Entity("Assignment.Models.ClassBooking", b =>
                {
                    b.HasOne("Assignment.Models.Class", "Class")
                        .WithMany("ClassBookings")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Models.Passenger", "Passenger")
                        .WithMany("ClassBookings")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("Assignment.Models.Dish", b =>
                {
                    b.HasOne("Assignment.Models.DiningLocation", "DiningLocation")
                        .WithMany("Dishes")
                        .HasForeignKey("DiningLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiningLocation");
                });

            modelBuilder.Entity("Assignment.Models.DishOrder", b =>
                {
                    b.HasOne("Assignment.Models.CabinService", "CabinService")
                        .WithMany("DishOrders")
                        .HasForeignKey("CabinServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Models.Dish", "Dish")
                        .WithMany("DishOrders")
                        .HasForeignKey("DishName", "DishDiningLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CabinService");

                    b.Navigation("Dish");
                });

            modelBuilder.Entity("Assignment.Models.Reservation", b =>
                {
                    b.HasOne("Assignment.Models.Passenger", "Passenger")
                        .WithMany("Reservations")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment.Models.Table", "Table")
                        .WithOne("Reservation")
                        .HasForeignKey("Assignment.Models.Reservation", "TableNo", "DiningLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Passenger");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Assignment.Models.Table", b =>
                {
                    b.HasOne("Assignment.Models.DiningLocation", "DiningLocation")
                        .WithMany("Tables")
                        .HasForeignKey("DiningLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DiningLocation");
                });

            modelBuilder.Entity("Assignment.Models.Activity", b =>
                {
                    b.Navigation("ActivitySlots");
                });

            modelBuilder.Entity("Assignment.Models.ActivitySlot", b =>
                {
                    b.Navigation("ActivityBookings");
                });

            modelBuilder.Entity("Assignment.Models.CabinService", b =>
                {
                    b.Navigation("DishOrders");
                });

            modelBuilder.Entity("Assignment.Models.Class", b =>
                {
                    b.Navigation("ClassBookings");
                });

            modelBuilder.Entity("Assignment.Models.DiningLocation", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Assignment.Models.Dish", b =>
                {
                    b.Navigation("DishOrders");
                });

            modelBuilder.Entity("Assignment.Models.Passenger", b =>
                {
                    b.Navigation("ActivityBookings");

                    b.Navigation("ClassBookings");

                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Assignment.Models.Table", b =>
                {
                    b.Navigation("Reservation");
                });
#pragma warning restore 612, 618
        }
    }
}
