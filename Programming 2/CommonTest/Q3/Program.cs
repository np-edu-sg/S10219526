// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

var customerList = new List<Customer>();

Console.Write("Please enter purchase amount: ");
var purchaseAmount = int.Parse(Console.ReadLine() ?? "0");

Console.WriteLine($"Entitled Discount per ${purchaseAmount:F0}");
Console.WriteLine($"{"Cust Id",-10}{"Cust Name",-15}Discount amt ($)");
foreach (var customer in customerList)
{
    Console.WriteLine($"{customer.CustId,-10}{customer.Name,-15}{customer.ApplyDiscount(purchaseAmount):F2}");
}

var unsuccessfulMembers = new List<Member>();
foreach (var customer in customerList)
{
    // Inline cast customer to member with Member type
    if (customer is Member member)
    {
        // var member = (Member)customer;
        if (!member.RedeemPoints(100)) unsuccessfulMembers.Add(member);
    }
}

if (unsuccessfulMembers.Count == 0)
    Console.WriteLine("There is no member with unsuccessful deduction of membership fee.");
else
{
    Console.WriteLine("Members with unsuccessful deduction of membership fee: ");
    Console.WriteLine($"{"Cust Id",-10}{"Cust Name",-15}Points");
    foreach (var member in unsuccessfulMembers)
    {
        Console.WriteLine($"{member.CustId,-10}{member.Name,-15}{member.Points}");
    }
}

public interface IPayable
{
    int X();
}

public class Customer : IPayable
{
    public int CustId { get; set; }
    public string Name { get; set; }
    public int ApplicableDiscount { get; set; }

    public Customer()
    {
    }

    public Customer(int custId, string name, int applicableDiscount)
    {
        CustId = custId;
        Name = name;
        ApplicableDiscount = applicableDiscount;
    }

    public virtual double ApplyDiscount(double purchase)
    {
        return purchase * (1 - ApplicableDiscount);
    }

    public int X()
    {
        throw new NotImplementedException();
    }
}

public class Member : Customer, IPayable
{
    public int MembershipNo { get; set; }
    public int Points { get; set; }

    public Member()
    {
    }

    public Member(int custId, string name, int applicableDiscount, int membershipNo, int points) : base(custId, name,
        applicableDiscount)
    {
        MembershipNo = membershipNo;
        Points = points;
    }

    public bool RedeemPoints(int points)
    {
        return false;
    }

    public override double ApplyDiscount(double purchase)
    {
        return purchase * (1 - ApplicableDiscount - 0.05);
    }

    public override string ToString()
    {
        return "";
    }
}