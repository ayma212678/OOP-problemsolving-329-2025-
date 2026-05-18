using System;
using System.Collections.Generic;
using System.Text;
using System;
class Circle : Shape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public override double getArea()
    {
        return 2 * Math.PI * radius * radius;
    }

    public override string getType()
    {
        return "Circle";
    }
}