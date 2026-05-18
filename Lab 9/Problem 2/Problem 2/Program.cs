using System;
using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student("Ali", "Lahore", "CS", 2, 50000);
        Student s2 = new Student("Sara", "Karachi", "EE", 3, 55000);

        Staff st1 = new Staff("Sir Ahmed", "Lahore", "UET", 80000);
        Staff st2 = new Staff("Sir Bilal", "Islamabad", "FAST", 90000);

        Console.WriteLine(s1.ToString());
        Console.WriteLine(s2.ToString());
        Console.WriteLine(st1.ToString());
        Console.WriteLine(st2.ToString());
    }
}