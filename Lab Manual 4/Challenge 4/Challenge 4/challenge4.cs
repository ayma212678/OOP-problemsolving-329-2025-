using System;
using System.Collections.Generic;

namespace UAMS
{
    class Subject
    {
        public int subjectCode;
        public string subjectType;
        public int creditHours;
        public float fees;

        public Subject()
        {
            subjectCode = 0;
            subjectType = "";
            creditHours = 0;
            fees = 0;
        }

        public void showSubject()
        {
            Console.WriteLine("Subject Code: " + subjectCode);
            Console.WriteLine("Subject Type: " + subjectType);
            Console.WriteLine("Credit Hours: " + creditHours);
            Console.WriteLine("Fees: " + fees);
        }
    }

    class DegreeProgram
    {
        public string degreeName;
        public int duration;
        public int seats;
        public List<Subject> subjects = new List<Subject>();
        public List<Student> registeredStudents = new List<Student>();

        public DegreeProgram()
        {
            degreeName = "";
            duration = 0;
            seats = 0;
        }

        public void addSubject(Subject s)
        {
            subjects.Add(s);
        }

        public void addStudent(Student s)
        {
            registeredStudents.Add(s);
            seats--;
        }

        public bool hasSeats()
        {
            return seats > 0;
        }

        public void showDegree()
        {
            Console.WriteLine("Degree: " + degreeName);
            Console.WriteLine("Duration: " + duration + " years");
            Console.WriteLine("Seats Available: " + seats);
        }

        public void showRegisteredStudents()
        {
            Console.WriteLine("\nStudents in " + degreeName + ":");
            Console.WriteLine("Name\t\tFSC\t\tEcat\t\tAge");
            foreach (Student s in registeredStudents)
            {
                Console.WriteLine(s.name + "\t\t" + s.fscMarks + "\t\t" + s.ecatMarks + "\t\t" + s.age);
            }
        }
    }

    class Student
    {
        public string name;
        public int age;
        public int fscMarks;
        public int ecatMarks;
        public float merit;
        public List<string> preferences = new List<string>();
        public List<Subject> registeredSubjects = new List<Subject>();
        public int totalCreditHours;
        public bool isAdmitted;
        public string admittedProgram;

        public Student()
        {
            name = "";
            age = 0;
            fscMarks = 0;
            ecatMarks = 0;
            merit = 0;
            totalCreditHours = 0;
            isAdmitted = false;
            admittedProgram = "";
        }

        public float calculateMerit()
        {
            merit = (fscMarks * 0.6f) + (ecatMarks * 0.4f);
            return merit;
        }

        public void addPreference(string program)
        {
            preferences.Add(program);
        }

        public void registerSubject(Subject s)
        {
            registeredSubjects.Add(s);
            totalCreditHours += s.creditHours;
        }

        public float calculateFees()
        {
            float total = 0;
            foreach (Subject s in registeredSubjects)
            {
                total += s.fees;
            }
            return total;
        }

        public void showStudent()
        {
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("FSC Marks: " + fscMarks);
            Console.WriteLine("Ecat Marks: " + ecatMarks);
            Console.WriteLine("Merit: " + merit);
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();
        static List<DegreeProgram> programs = new List<DegreeProgram>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("\n**************************************");
                Console.WriteLine("                 UAMS                 ");
                Console.WriteLine("**************************************");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Degree Program");
                Console.WriteLine("3. Generate Merit");
                Console.WriteLine("4. View Registered Students");
                Console.WriteLine("5. View Students of a Specific Program");
                Console.WriteLine("6. Register Subjects for a Specific Student");
                Console.WriteLine("7. Calculate Fees for all Registered Students");
                Console.WriteLine("8. Exit");
                Console.Write("Enter Option: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                    addStudent();
                else if (choice == 2)
                    addDegreeProgram();
                else if (choice == 3)
                    generateMerit();
                else if (choice == 4)
                    viewRegisteredStudents();
                else if (choice == 5)
                    viewSpecificProgram();
                else if (choice == 6)
                    registerSubjects();
                else if (choice == 7)
                    calculateFees();

            } while (choice != 8);
        }

        static void addStudent()
        {
            Student s = new Student();

            Console.Write("Enter Student Name: ");
            s.name = Console.ReadLine();

            Console.Write("Enter Student Age: ");
            s.age = int.Parse(Console.ReadLine());

            Console.Write("Enter Student FSc Marks: ");
            s.fscMarks = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Ecat Marks: ");
            s.ecatMarks = int.Parse(Console.ReadLine());

            Console.WriteLine("Available Degree Programs:");
            foreach (DegreeProgram dp in programs)
            {
                Console.WriteLine(dp.degreeName);
            }

            Console.Write("Enter how many preferences to Enter: ");
            int prefCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < prefCount; i++)
            {
                Console.Write("Enter Preference: ");
                s.addPreference(Console.ReadLine());
            }

            students.Add(s);
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
        }

        static void addDegreeProgram()
        {
            DegreeProgram dp = new DegreeProgram();

            Console.Write("Enter Degree Name: ");
            dp.degreeName = Console.ReadLine();

            Console.Write("Enter Degree Duration: ");
            dp.duration = int.Parse(Console.ReadLine());

            Console.Write("Enter Seats for Degree: ");
            dp.seats = int.Parse(Console.ReadLine());

            Console.Write("Enter How many Subjects to Enter: ");
            int subCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < subCount; i++)
            {
                Subject s = new Subject();

                Console.Write("Enter Subject Code: ");
                s.subjectCode = int.Parse(Console.ReadLine());

                Console.Write("Enter Subject Type: ");
                s.subjectType = Console.ReadLine();

                Console.Write("Enter Subject Credit Hours: ");
                s.creditHours = int.Parse(Console.ReadLine());

                Console.Write("Enter Subject Fees: ");
                s.fees = float.Parse(Console.ReadLine());

                dp.addSubject(s);
            }

            programs.Add(dp);
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
        }

        static void generateMerit()
        {
            foreach (Student s in students)
            {
                s.calculateMerit();
            }

            foreach (Student s in students)
            {
                bool admitted = false;

                foreach (string pref in s.preferences)
                {
                    foreach (DegreeProgram dp in programs)
                    {
                        if (dp.degreeName == pref && dp.hasSeats())
                        {
                            dp.addStudent(s);
                            s.isAdmitted = true;
                            s.admittedProgram = dp.degreeName;
                            Console.WriteLine(s.name + " got Admission in " + dp.degreeName);
                            admitted = true;
                            break;
                        }
                    }
                    if (admitted)
                        break;
                }

                if (!admitted)
                    Console.WriteLine(s.name + " did not get Admission");
            }

            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
        }

        static void viewRegisteredStudents()
        {
            Console.WriteLine("\nName\t\tFSC\t\tEcat\t\tAge");
            foreach (Student s in students)
            {
                if (s.isAdmitted)
                    Console.WriteLine(s.name + "\t\t" + s.fscMarks + "\t\t" + s.ecatMarks + "\t\t" + s.age);
            }
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
        }

        static void viewSpecificProgram()
        {
            Console.Write("Enter Degree Name: ");
            string name = Console.ReadLine();
            bool found = false;

            foreach (DegreeProgram dp in programs)
            {
                if (dp.degreeName == name)
                {
                    dp.showRegisteredStudents();
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Program not found.");

            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
        }

        static void registerSubjects()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            bool found = false;

            foreach (Student s in students)
            {
                if (s.name == name && s.isAdmitted)
                {
                    Console.WriteLine("Available subjects in " + s.admittedProgram + ":");

                    foreach (DegreeProgram dp in programs)
                    {
                        if (dp.degreeName == s.admittedProgram)
                        {
                            foreach (Subject sub in dp.subjects)
                            {
                                sub.showSubject();
                                Console.WriteLine();
                            }
                        }
                    }

                    Console.Write("Enter Subject Code to Register: ");
                    int code = int.Parse(Console.ReadLine());

                    foreach (DegreeProgram dp in programs)
                    {
                        if (dp.degreeName == s.admittedProgram)
                        {
                            foreach (Subject sub in dp.subjects)
                            {
                                if (sub.subjectCode == code)
                                {
                                    if (s.totalCreditHours + sub.creditHours > 9)
                                    {
                                        Console.WriteLine("Cannot register! Credit hours exceed 9.");
                                    }
                                    else
                                    {
                                        s.registerSubject(sub);
                                        Console.WriteLine("Subject registered!");
                                    }
                                }
                            }
                        }
                    }
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Student not found or not admitted.");

            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
        }

        static void calculateFees()
        {
            foreach (Student s in students)
            {
                if (s.isAdmitted)
                {
                    float fees = s.calculateFees();
                    Console.WriteLine(s.name + " - Total Fees: " + fees);
                }
            }
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
        }
    }
}