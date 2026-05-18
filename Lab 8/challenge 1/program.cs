using System;

class Bicycle
{
    public int cadence, speed, gear;
    public Bicycle(int cadence, int speed, int gear)
    {
        this.cadence = cadence; this.speed = speed; this.gear = gear;
    }
}
class MountainBike : Bicycle
{
    public int seatHeight;
    public MountainBike(int s, int c, int sp, int g) : base(c, sp, g) { seatHeight = s; }
}
class Program
{
    static void Main()
    {
        MountainBike mb = new MountainBike(20, 10, 50, 3);
        Console.WriteLine("Mountain Bike created with gear: " + mb.gear);
    }
}