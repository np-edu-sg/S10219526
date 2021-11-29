using System;
using System.Collections.Generic;

namespace S10219526_ShapeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var circleList = new List<Circle>();
            InitCircleList(circleList);

            Console.WriteLine("---------------- M E N U --------------------");
            Console.WriteLine("[1] List all the circles");
            Console.WriteLine("[2] Display the areas of the circles");
            Console.WriteLine("[3] Display the perimeters of the circles");
            Console.WriteLine("[4] Change the size of a circle");
            Console.WriteLine("[5] Add a new circle");
            Console.WriteLine("[6] Delete a circle");
            Console.WriteLine("[7] Display circles sorted by area");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("---------------------------------------------");

            while (true)
            {
                Console.Write("Enter your option: ");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        return;
                    case "1":
                        for (var idx = 0; idx < circleList.Count; idx++)
                        {
                            Console.WriteLine($"[{idx + 1}] {circleList[idx]}");
                        }

                        break;
                    case "2":
                        foreach (var circle in circleList)
                        {
                            Console.WriteLine(circle.ToDetailedAreaString());
                        }

                        break;
                    case "3":
                        foreach (var circle in circleList)
                        {
                            Console.WriteLine(circle.ToDetailedPerimeterString());
                        }

                        break;
                    case "4":
                        for (var idx = 0; idx < circleList.Count; idx++)
                        {
                            Console.WriteLine($"[{idx + 1}] {circleList[idx]}");
                        }

                        int circleNo;
                        while (true)
                        {
                            Console.Write("Enter circle number: ");
                            if (int.TryParse(Console.ReadLine(), out circleNo) &&
                                (circleNo > 0 && circleNo <= circleList.Count)) break;
                            Console.WriteLine("Please enter a valid circle number.");
                        }

                        double radius;
                        while (true)
                        {
                            Console.Write("Enter new radius: ");
                            if (double.TryParse(Console.ReadLine(), out radius)) break;
                            Console.WriteLine("Please enter a valid radius value.");
                        }

                        circleList[circleNo - 1].Radius = radius;

                        Console.WriteLine("Radius successfully changed.");
                        break;
                    case "5":
                        Console.Write("Circle color: ");
                        var color = Console.ReadLine();

                        double radius2;
                        while (true)
                        {
                            Console.Write("Circle radius: ");
                            if (double.TryParse(Console.ReadLine(), out radius2)) break;
                        }

                        circleList.Add(new Circle(color, radius2));

                        Console.WriteLine($"New {color} circle with radius {radius2}cm added.");
                        break;
                    case "6":
                        for (var idx = 0; idx < circleList.Count; idx++)
                        {
                            Console.WriteLine($"[{idx + 1}] {circleList[idx]}");
                        }

                        int circleNo2;
                        while (true)
                        {
                            Console.Write("Enter circle number: ");
                            if (int.TryParse(Console.ReadLine(), out circleNo2) &&
                                (circleNo2 > 0 && circleNo2 <= circleList.Count)) break;
                            Console.WriteLine("Please enter a valid circle number.");
                        }

                        circleList.RemoveAt(circleNo2 - 1);
                        Console.WriteLine("Circle removed.");
                        break;
                    case "7":
                        var sorted = new List<Circle>(circleList);

                        sorted.Sort();
                        sorted.Reverse();
                        
                        foreach (var circle in sorted)
                        {
                            Console.WriteLine(circle.ToDetailedAreaString());
                        }

                        break;
                    default: continue;
                }
            }
        }

        public static void InitCircleList(List<Circle> cList)
        {
            var circle1 = new Circle("Red", 20);
            var circle2 = new Circle("Green", 10);
            var circle3 = new Circle("Blue", 30);
            cList.Add(circle1);
            cList.Add(circle2);
            cList.Add(circle3);
        }
    }
}