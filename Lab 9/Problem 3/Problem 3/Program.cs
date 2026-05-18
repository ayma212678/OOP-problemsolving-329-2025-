using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Store as dynamic so we can call greets() polymorphically
        List<dynamic> animals = new List<dynamic>();

        animals.Add(new Cat("Whiskers"));
        animals.Add(new Cat("Luna"));
        animals.Add(new Dog("Bruno"));
        animals.Add(new Dog("Max"));

        foreach (var a in animals)
        {
            a.greets();
            Console.WriteLine(a.ToString());
        }
    }
}