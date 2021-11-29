using System;

namespace S10219526_ShapeApp
{
    public class Circle : Shape, IComparable<Circle>
    {
        public double Radius { get; set; }

        public Circle()
        {
        }

        public Circle(string color, double radius)
        {
            Type = "Circle";
            Color = color;
            Radius = radius;
        }

        public override double FindArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double FindPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public int CompareTo(Circle other)
        {
            if (Math.Abs(Radius - other.Radius) < 0.01) return 0;
            if (Radius > other.Radius) return 1;
            return -1;
        }

        public override string ToString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Radius: {Radius}";
        }

        public string ToDetailedAreaString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Radius: {Radius, -10}Area: {FindArea():N2}";
        }

        public string ToDetailedPerimeterString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Radius: {Radius, -10}Perimeter: {FindPerimeter():N2}";
        }
    }
}