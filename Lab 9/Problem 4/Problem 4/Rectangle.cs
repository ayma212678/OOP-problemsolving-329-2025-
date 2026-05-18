using System;
using System.Collections.Generic;
using System.Text;
class Rectangle : Shape
{
    private double width;
    private double height;
    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }
    public override double getArea()
    {
        return width * height;
    }
    public override string getType()
    {
        return "Rectangle";
    }
}
