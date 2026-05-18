using System;

class Circle
{
    public double radius = 1.0;
    public string color = "red";
    public double getArea() { return 3.14 * radius * radius; }
}

class Cylinder : Circle
{
    public double height = 1.0;
    public double getVolume() { return getArea() * height; }
}

class Program
{
    static void Main()
    {
        Cylinder c = new Cylinder();
        c.radius = 5.0;
        Console.WriteLine("Volume is: " + c.getVolume());
    }
}