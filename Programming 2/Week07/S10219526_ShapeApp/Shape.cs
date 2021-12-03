using System;

namespace S10219526_ShapeApp
{
    public abstract class Shape : IComparable<Shape>
    {
        public string Type { get; set; }
        public string Color { get; set; }

        public Shape()
        {
        }

        public Shape(string type, string color)
        {
            Type = type;
            Color = color;
        }

        public abstract double FindArea();

        public abstract double FindPerimeter();

        public abstract string ToDetailedAreaString();

        public abstract string ToDetailedPerimeterString();

        public int CompareTo(Shape? other)
        {
            if (other == null) return -1;

            if (Math.Abs(FindArea() - other.FindArea()) < 0.01) return 0;
            if (FindArea() > other.FindArea()) return 1;
            return -1;
        }
    }
}