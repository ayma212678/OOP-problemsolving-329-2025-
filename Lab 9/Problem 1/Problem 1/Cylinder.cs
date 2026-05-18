using System;
using System.Collections.Generic;
using System.Text;
class Cylinder : Circle
{
    private double height;
    public Cylinder()
    {
        height = 1.0;
    }
    public Cylinder(double radius)
    {
        this.radius = radius;
        this.height = 1.0;
    }
    public Cylinder(double radius, double height)
    {
        this.radius = radius;
        this.height = height;
    }
    public Cylinder(double radius, double height, string color)
    {
        this.radius = radius;
        this.height = height;
        this.color = color;
    }
    public double getHeight() { return height; }
    public void setHeight(double height) { this.height = height; }
    public double getVolume()
    {
        return getArea() * height;
    }
    public override string ToString()
    {
        return "Cylinder[Circle[radius=" + radius + ",color=" + color + "],height=" + height + "]";
    }
}
