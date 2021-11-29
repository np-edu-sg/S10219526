namespace S10219526_ShapeApp
{
    public abstract class Shape
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
    }
    
}