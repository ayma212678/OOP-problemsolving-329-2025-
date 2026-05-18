using System;
using System.Collections.Generic;

class Student
{
    public string Name;
    public int RollNo;
    public float Marks1, Marks2, Marks3;

    public Student() 
    { Name = "Unknown"; 
        RollNo = 0; 
        Marks1 = Marks2 = Marks3 = 0; }

    public Student(string name, int roll, float m1, float m2, float m3)
    {
        Name = name; 
        RollNo = roll;
        Marks1 = m1; 
        Marks2 = m2; 
        Marks3 = m3;
    }
    public float GetAggregate() { return (Marks1 + Marks2 + Marks3) / 3; }

    public void Display()
    {
        Console.WriteLine("Roll: " + RollNo + " | Name: " + Name +
                          " | Aggregate: " + GetAggregate());
    }
}

class Program
{
    static List<Student> students = new List<Student>();

    static void Main(string[] args)
    {
        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("\n1.Add  2.Show  3.Aggregates  4.Top Student  5.Exit");
            Console.Write("Choice: ");
            choice = int.Parse(Console.ReadLine());

            if (choice == 1) AddStudent();
            else if (choice == 2) ShowStudents();
            else if (choice == 3) ShowAggregates();
            else if (choice == 4) ShowTopStudent();
            else if (choice == 5) Console.WriteLine("Goodbye!");
        }
    }

    static void AddStudent()
    {
        Console.Write("Name: "); string name = Console.ReadLine();
        Console.Write("Roll No: "); int roll = int.Parse(Console.ReadLine());
        Console.Write("Marks 1: "); float m1 = float.Parse(Console.ReadLine());
        Console.Write("Marks 2: "); float m2 = float.Parse(Console.ReadLine());
        Console.Write("Marks 3: "); float m3 = float.Parse(Console.ReadLine());
        students.Add(new Student(name, roll, m1, m2, m3));
        Console.WriteLine("Student added!");
    }

    static void ShowStudents()
    {
        if (students.Count == 0) { Console.WriteLine("No students yet."); return; }
        foreach (Student s in students) s.Display();
    }

    static void ShowAggregates()
    {
        foreach (Student s in students)
            Console.WriteLine(s.Name + " -> " + s.GetAggregate());
    }

    static void ShowTopStudent()
    {
        if (students.Count == 0) { Console.WriteLine("No students yet."); return; }
        Student top = students[0];
        foreach (Student s in students)
            if (s.GetAggregate() > top.GetAggregate()) top = s;
        Console.WriteLine("\n=== Top Student ===");
        top.Display();
    }
}