using System;
using System.Collections.Generic;
using System.Text;
class Square : Shape
{
    private double side;

    public Square(double side)
    {
        this.side = side;
    }

    public override double getArea()
    {
        return side * side;
    }

    public override string getType()
    {
        return "Square";
    }
}
