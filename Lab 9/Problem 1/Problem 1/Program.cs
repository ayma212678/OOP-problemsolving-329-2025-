using System;

class Program
{
    static void Main(string[] args)
    {
        Cylinder c1 = new Cylinder();
        c1.setHeight(5.0);
        Console.WriteLine(c1);
        Console.WriteLine("Volume: " + c1.getVolume());

        // 2 parameterized constructors
        Cylinder c2 = new Cylinder(3.0, 7.0);
        Console.WriteLine(c2);
        Console.WriteLine("Volume: " + c2.getVolume());

        Cylinder c3 = new Cylinder(4.0, 10.0, "blue");
        Console.WriteLine(c3);
        Console.WriteLine("Volume: " + c3.getVolume());
    }
}