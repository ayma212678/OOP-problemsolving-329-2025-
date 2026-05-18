using System;
using System.Collections.Generic;
using System.Linq;
using uams.BL;

namespace uams.DL
{
    public class StudentDL
    {
        public static List<Student> studentList = new List<Student>();

        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }

        public static List<Student> sortStudentsByMerit()
        {
            return studentList.OrderByDescending(s => s.marks).ToList();
        }

        public static void viewRegisteredStudents()
        {
            Console.WriteLine("=== Registered Students ===");
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine($"Name: {s.name} | Marks: {s.marks} | Program: {s.regDegree.name}");
                }
            }
        }

        public static void viewStudentInDegree(string degName)
        {
            Console.WriteLine($"=== Students in {degName} ===");
            foreach (Student s in studentList)
            {
                if (s.regDegree != null && s.regDegree.name.ToLower() == degName.ToLower())
                {
                    Console.WriteLine($"Name: {s.name} | Marks: {s.marks}");
                }
            }
        }

        public static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (s.name.ToLower() == name.ToLower() && s.regDegree != null)
                    return s;
            }
            Console.WriteLine("Student not found or not admitted.");
            return null;
        }

        public static void calculateFeeForAll()
        {
            Console.WriteLine("=== Fee Calculation ===");
            foreach (Student s in studentList)
            {
                if (s.regDegree != null && s.registeredSubjects.Count > 0)
                {
                    int totalFee = 0;
                    foreach (Subject sub in s.registeredSubjects)
                        totalFee += sub.subjectFees;

                    Console.WriteLine($"Student: {s.name} | Total Fee: {totalFee}");
                }
            }
        }
    }
}