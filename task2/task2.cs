using System;
class Calculator
{
    public float Num1;
    public float Num2;

    //--Default Constructor
    public Calculator()
    {
        Num1 = 0;
        Num2 = 0;
    }

    //--Parameterized Constructor
    public Calculator(float n1, float n2)
    {
        Num1 = n1;
        Num2 = n2;
    }

    public float Add() {return Num1+Num2;}
    public float Subtract() {return Num1-Num2;}
    public float Multiply() {return Num1*Num2;}
    public float Divide()
    {
        if (Num2 == 0)
        {
            Console.WriteLine("Error: Cannot divide by zero!");
            return 0;
        }
        return Num1/Num2;
    }

    public void ShowResults()
    {
        Console.WriteLine("Add      = " + Add());
        Console.WriteLine("Subtract = " + Subtract());
        Console.WriteLine("Multiply = " + Multiply());
        Console.WriteLine("Divide   = " + Divide());
    }
}

class task2
{
    static void Main(string[] args)
    {
        Calculator c1 = new Calculator(20, 4);
        c1.ShowResults();
        Console.ReadKey();
    }
}