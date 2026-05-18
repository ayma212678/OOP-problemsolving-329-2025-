using System;
using System.Collections.Generic;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    public class StudentUI
    {
        public static Student takeInputForStudentWithPreferences()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Marks: ");
            int marks = int.Parse(Console.ReadLine());

            Student s = new Student(name, marks);

            Console.WriteLine("Available Degree Programs:");
            for (int i = 0; i < DegreeProgramDL.programList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {DegreeProgramDL.programList[i].name}");
            }

            Console.Write("How many preferences? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Preference {i + 1} (enter number): ");
                int choice = int.Parse(Console.ReadLine()) - 1;
                if (choice >= 0 && choice < DegreeProgramDL.programList.Count)
                    s.preferences.Add(DegreeProgramDL.programList[choice]);
            }

            return s;
        }

        public static void printStudents()
        {
            Console.WriteLine("\n=== Merit List & Admissions ===");
            foreach (Student s in StudentDL.studentList)
            {
                string program = s.regDegree != null ? s.regDegree.name : "Not Admitted";
                Console.WriteLine($"Name: {s.name} | Marks: {s.marks} | Admitted To: {program}");
            }
        }

        public static void viewSubjects(Student s)
        {
            Console.WriteLine($"\n=== Subjects in {s.regDegree.name} ===");
            for (int i = 0; i < s.regDegree.subjects.Count; i++)
            {
                Subject sub = s.regDegree.subjects[i];
                Console.WriteLine($"{i + 1}. {sub.code} | {sub.type} | {sub.creditHours} CH | Fee: {sub.subjectFees}");
            }
        }

        public static void registerSubjects(Student s)
        {
            Console.Write("\nHow many subjects to register? ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Subject {i + 1} number: ");
                int choice = int.Parse(Console.ReadLine()) - 1;
                if (choice >= 0 && choice < s.regDegree.subjects.Count)
                    s.registeredSubjects.Add(s.regDegree.subjects[choice]);
            }

            Console.WriteLine("Subjects registered successfully!");
        }
    }
}