using ConsoleApp5.figures;
using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle();
            Ellipse ellipse = new Ellipse(1.0, 2.0, 3.0, 4.0);
            Square square = new Square(10.0, 10.0, 5.0);
            Rectangle rectangle = new Rectangle(3.0, 3.5, 7.0, 6.0);
            Triangle triangle = new Triangle();

            Console.WriteLine("Circle: " + circle.GetDistance() + " | " + circle.GetArea() + " | " + circle.GetPerimeter());
            Console.WriteLine("Ellipse: " + ellipse.GetDistance() + " | " + ellipse.GetArea() + " | " + ellipse.GetPerimeter());
            Console.WriteLine("Square: " + square.GetDistance() + " | " + square.GetArea() + " | " + square.GetPerimeter());
            Console.WriteLine("Rectangle: " + rectangle.GetDistance() + " | " + rectangle.GetArea() + " | " + rectangle.GetPerimeter());
            Console.WriteLine("Triangle: " + triangle.GetDistance() + " | " + triangle.GetArea() + " | " + triangle.GetPerimeter());
            Console.ReadKey();
        }
    }
}
