// See https://aka.ms/new-console-template for more information

using System;

Console.Write("Enter name: ");
// Assume this will always be valid
var name = Console.ReadLine() ?? "";

Console.Write("Enter address: ");
// Assume this will always be valid
var address = Console.ReadLine() ?? "";

Console.Write("Enter distance (to nearest km): ");
// Assume this will always be valid
var distance = Console.ReadLine() ?? "0";

Console.Write("Enter base fee: ");
// Assume this will always be valid
var baseFee = Console.ReadLine() ?? "0";

var delivery = new InstantDelivery(name, address, int.Parse(distance), double.Parse(baseFee));
Console.WriteLine($"The cost is {delivery.CalculateCost():C2}");

public class StandardDelivery
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int Distance { get; set; }

    public StandardDelivery()
    {
    }

    public StandardDelivery(string name, string address, int distance)
    {
        Name = name;
        Address = address;
        Distance = distance;
    }

    public virtual double CalculateCost()
    {
        return 0;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}

public class InstantDelivery : StandardDelivery
{
    public double BaseFee { get; set; }

    public InstantDelivery()
    {
    }

    public InstantDelivery(string name, string address, int distance, double baseFee) : base(name, address, distance)
    {
        BaseFee = baseFee;
    }

    public override double CalculateCost()
    {
        if (Distance <= 5) return Distance + BaseFee;
        return 5 + (Distance - 5) * 0.7 + BaseFee;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}