// See https://aka.ms/new-console-template for more information

using AssignmentFinal;
using AssignmentFinal.Models;
using Microsoft.EntityFrameworkCore;

using var context = new AppDbContext();
Console.WriteLine(context.Database.EnsureDeleted());
Console.WriteLine(context.Database.EnsureCreated());

// Seed


context.SaveChanges();