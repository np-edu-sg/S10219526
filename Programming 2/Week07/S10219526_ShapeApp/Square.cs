using System;

namespace S10219526_ShapeApp
{
    public class Square : Shape
    {
        public double Length { get; set; }

        public Square()
        {
        }

        public Square(string color, double length) : base("Square", color)
        {
            Length = length;
        }

        public override double FindArea()
        {
            return Length * Length;
        }

        public override double FindPerimeter()
        {
            return Length * 4;
        }

        public override string ToString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Length: {Length}";
        }

        public override string ToDetailedAreaString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Length: {Length,-10}Area: {FindArea():N2}";
        }

        public override string ToDetailedPerimeterString()
        {
            return $"Type: {Type,-15}Color: {Color,-10}Length: {Length,-10}Perimeter: {FindPerimeter():N2}";
        }
    }
}