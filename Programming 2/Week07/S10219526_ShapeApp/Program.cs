using System;
using System.Collections.Generic;
using S10219526_ShapeApp;

Console.WriteLine("---------------- M E N U --------------------");
Console.WriteLine("[1] List all the shapes");
Console.WriteLine("[2] Display the areas of the shapes");
Console.WriteLine("[3] Display the perimeters of the shapes");
Console.WriteLine("[4] Change the size of all the shapes");
Console.WriteLine("[5] Add a new circle");
Console.WriteLine("[6] Delete a circle");
Console.WriteLine("[7] Display shapes sorted by area");
Console.WriteLine("[0] Exit");
Console.WriteLine("---------------------------------------------");

var shapeList = new List<Shape>();
InitShapeList(shapeList);

while (true)
{
    Console.Write("Enter your option: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "0": return;
        case "1":
            for (var idx = 0; idx < shapeList.Count; idx++)
            {
                Console.WriteLine($"[{idx + 1}] {shapeList[idx]}");
            }

            break;
        case "2":
            foreach (var shape in shapeList)
            {
                Console.WriteLine(shape.ToDetailedAreaString());
            }

            break;
        case "3":
            foreach (var shape in shapeList)
            {
                Console.WriteLine(shape.ToDetailedPerimeterString());
            }

            break;
        case "4":
            foreach (var shape in shapeList)
            {
                switch (shape)
                {
                    case Circle circle:
                        circle.Radius += 5;
                        Console.WriteLine(circle);
                        break;
                    case Square square:
                        square.Length += 5;
                        Console.WriteLine(square);
                        break;
                }
            }

            break;
        case "5":
            string color;
            while (true)
            {
                Console.Write("Circle color: ");
                var input2 = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input2))
                {
                    color = input2;
                    break;
                }
            }

            double radius;
            while (true)
            {
                Console.Write("Circle radius: ");
                if (double.TryParse(Console.ReadLine(), out radius)) break;
            }

            shapeList.Add(new Circle(color, radius));
            break;
        case "6":
            if (shapeList.Count == 0)
            {
                Console.WriteLine("No circle object in list.");
                break;
            }

            var found = false;
            for (var idx = shapeList.Count - 1; idx >= 0; idx--)
            {
                if (shapeList[idx] is Circle)
                {
                    shapeList.RemoveAt(idx);
                    Console.WriteLine("Circle removed.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Circle not found.");
            }

            break;
        case "7":
            var sorted = new List<Shape>(shapeList);

            sorted.Sort();

            foreach (var shape in sorted)
            {
                Console.WriteLine(shape.ToDetailedAreaString());
            }

            break;
    }
}

static void InitShapeList(List<Shape> sList)
{
    var shape1 = new Circle("Red", 10.0);
    var shape2 = new Square("Red", 10.0);
    var shape3 = new Circle("Green", 20.0);
    var shape4 = new Square("Green", 20.0);
    var shape5 = new Circle("Blue", 30.0);
    var shape6 = new Square("Blue", 30.0);

    sList.Add(shape1);
    sList.Add(shape2);
    sList.Add(shape3);
    sList.Add(shape4);
    sList.Add(shape5);
    sList.Add(shape6);
}