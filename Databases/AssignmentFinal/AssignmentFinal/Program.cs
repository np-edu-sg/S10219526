// See https://aka.ms/new-console-template for more information

using AssignmentFinal;
using AssignmentFinal.Models;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();
Console.WriteLine(context.Database.EnsureDeleted());
Console.WriteLine(context.Database.EnsureCreated());

// Seed

var bob = new Passenger
{
    Name = "Bob",
    Email = "bob@gmail.com",
    DOB = new DateOnly(2000, 01, 01),
    Gender = 'M',
};

context.Passenger.Add(bob);

context.SaveChanges();