// See https://aka.ms/new-console-template for more information

using System;

Console.Write("Enter the values of a,b,c of line 1 equation ax+by=c: ");
// Assume this will always be valid
var input = Console.ReadLine() ?? "";
var split = input.Split(",");
var one = new Line(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));

Console.Write("Enter the values of a,b,c of line 2 equation ax+by=c: ");
// Assume this will always be valid
var input2 = Console.ReadLine() ?? "";
var split2 = input2.Split(",");
var two = new Line(int.Parse(split2[0]), int.Parse(split2[1]), int.Parse(split2[2]));

var x = two.FindIntersectionX(one);
var y = two.FindIntersectionY(one);

Console.WriteLine($"The intersection point (x, y): ({x}, {y})");


class Line
{
    public int A { get; set; }
    public int B { get; set; }
    public int C { get; set; }

    public Line()
    {
    }

    public Line(int a, int b, int c)
    {
        A = a;
        B = b;
        C = c;
    }

    public double FindIntersectionX(Line two)
    {
        return (double) (B * two.C - two.B * C) / (A * two.B - two.A * B);
    }

    public double FindIntersectionY(Line two)
    {
        return (double) (C * two.A - two.C * A) / (A * two.B - two.A * B);
    }

    public override string ToString()
    {
        return "empty";
    }
}