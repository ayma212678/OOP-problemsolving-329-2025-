using System;
class Circle
{
    protected double radius;
    protected string color;
    public Circle()
    {
        radius = 1.0;
        color = "red";
    }
    public Circle(double radius)
    {
        this.radius = radius;
        this.color = "red";
    }
    public Circle(double radius, string color)
    {
        this.radius = radius;
        this.color = color;
    }
    public double getRadius() { return radius; }
    public void setRadius(double radius) { this.radius = radius; }
    public string getColor() { return color; }
    public void setColor(string color) { this.color = color; }

    public double getArea()
    {
        return Math.PI * radius * radius;
    }
    public override string ToString()
    {
        return "Circle[radius=" + radius + ",color=" + color + "]";
    }
}