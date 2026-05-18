using System;
using System.Drawing;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter Width: ");
        double w1 = double.Parse(Console.ReadLine());
        Console.Write("Enter Height: ");
        double h1 = double.Parse(Console.ReadLine());
        ShapeDL.addShape(new Rectangle(w1, h1));

        Console.Write("Enter radius: ");
        double r1 = double.Parse(Console.ReadLine());
        ShapeDL.addShape(new Circle(r1));

        Console.Write("Enter Side: ");
        double s1 = double.Parse(Console.ReadLine());
        ShapeDL.addShape(new Square(s1));

        Console.Write("Enter Width: ");
        double w2 = double.Parse(Console.ReadLine());
        Console.Write("Enter Height: ");
        double h2 = double.Parse(Console.ReadLine());
        ShapeDL.addShape(new Rectangle(w2, h2));

        Console.Write("Enter radius: ");
        double r2 = double.Parse(Console.ReadLine());
        ShapeDL.addShape(new Circle(r2));

        int i = 1;
        foreach (Shape shape in ShapeDL.getShapes())
        {
            Console.WriteLine(i + ".The shape is " + shape.getType() + " and its area is " + shape.getArea());
            i++;
        }
    }
}