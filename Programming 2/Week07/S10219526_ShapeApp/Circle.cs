using System;

namespace S10219526_ShapeApp
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle()
        {
        }

        public Circle(string color, double radius) : base("Circle", color)
        {
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

        public override string ToString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Radius: {Radius}";
        }

        public override string ToDetailedAreaString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Radius: {Radius,-10}Area: {FindArea():N2}";
        }

        public override string ToDetailedPerimeterString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Radius: {Radius,-10}Perimeter: {FindPerimeter():N2}";
        }
    }
}