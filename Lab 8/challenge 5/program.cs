using System;

class Car
{
    public string model, color;
    public double price;
    public virtual double calculateFuel() { return 0; }
}

class BMW : Car
{
    public override double calculateFuel() { return price * 0.15; }

class Audi : Car
{
    public override double calculateFuel() { return price * 0.12; } 
}

class Program
{
    static void Main()
    {
        BMW myCar = new BMW();
        myCar.model = "BMW M5";
        myCar.calculateFuel();
    }
}