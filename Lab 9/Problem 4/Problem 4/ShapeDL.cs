using System;
using System.Collections.Generic;
using System.Text;
class ShapeDL
{
    private static List<Shape> shapeList = new List<Shape>();

    public static void addShape(Shape s)
    {
        shapeList.Add(s);
    }

    public static List<Shape> getShapes()
    {
        return shapeList;
    }
}
