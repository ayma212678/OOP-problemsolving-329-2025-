namespace UAMS
{
    class Subject
    {
        //--- fields ---
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;

        //--- constructor ---
        public Subject(string c, string t, int cH, int s)
        {
            code = c;
            type = t;
            creditHours = cH;
            subjectFees = s;
        }
    }

    class DegreeProgram
    {
        //--- fields ---
        public string degreeName;
        public float degreeDuration;
        public int seats;
        public List<Subject> subjects;

        //--- constructor ---
        public DegreeProgram(string dN, float dD, int s)
        {
            degreeName = dN;
            degreeDuration = dD;
            seats = s;
            subjects = new List<Subject>();
        }

        //--- total credit hours of all subjects ---
        public int calculateCreditHours()
        {
            int total = 0;
            for (int i = 0; i < subjects.Count; i++)
                total = total + subjects[i].creditHours;
            return total;
        }

        //--- check if subject already exists by code ---
        public bool isSubjectExists(Subject sub)
        {
            for (int i = 0; i < subjects.Count; i++)
                if (subjects[i].code == sub.code)
                    return true;
            return false;
        }

        //--- add subject if under 20 credit hour limit ---
        public bool addSubject(Subject s)
        {
            int total = calculateCreditHours();
            if (total + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            return false;
        }
    }

    class Student
    {
        //--- fields ---
        public string name;
        public int age;
        public double fscMarks;
        public double ecatMarks;
        public double merit;
        public List<DegreeProgram> preferences;
        public DegreeProgram regDegree;
        public List<Subject> regSubjects;

        //--- constructor ---
        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regDegree = null;
            regSubjects = new List<Subject>();
            calculateMerit();
        }

        //--- calculate merit based on fsc and ecat ---
        public void calculateMerit()
        {
            merit = ((0.25 * (fscMarks / 1100)) + (0.45 * (fscMarks / 1100)) + (0.30 * (ecatMarks / 400))) * 100;
        }

        //--- total credit hours of registered subjects ---
        public int getCreditHours()
        {
            int total = 0;
            for (int i = 0; i < regSubjects.Count; i++)
                total = total + regSubjects[i].creditHours;
            return total;
        }

        //--- register a subject if under 9 credit hour limit ---
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.creditHours <= 9)
            {
                regSubjects.Add(s);
                return true;
            }
            return false;
        }

        //--- calculate total fee of registered subjects ---
        public float calculateFee()
        {
            float total = 0;
            for (int i = 0; i < regSubjects.Count; i++)
                total = total + regSubjects[i].subjectFees;
            return total;
        }
    }

    internal class Program
    {
        //--- global lists and state ---
        static List<Student> studentList = new List<Student>();
        static List<DegreeProgram> programList = new List<DegreeProgram>();
        static bool meritDone = false;

        //--- display main menu ---
        static void showMenu()
        {
            Console.WriteLine("****************************************");
            Console.WriteLine("                 UAMS                  ");
            Console.WriteLine("****************************************");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Program");
            Console.WriteLine("6. Register Subjects for a Student");
            Console.WriteLine("7. Calculate Fees");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Option: ");
        }

        //--- add a new degree program with subjects ---
        static void addDegreeProgram()
        {
            Console.Write("Enter Degree Name: ");
            string dname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(dname)) { Console.WriteLine("Name cannot be empty."); return; }

            Console.Write("Enter Degree Duration: ");
            if (!float.TryParse(Console.ReadLine(), out float dur)) { Console.WriteLine("Invalid duration."); return; }

            Console.Write("Enter Seats: ");
            if (!int.TryParse(Console.ReadLine(), out int seats) || seats < 0) { Console.WriteLine("Invalid seats."); return; }

            DegreeProgram dp = new DegreeProgram(dname, dur, seats);

            Console.Write("Enter How many Subjects: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count < 0) { Console.WriteLine("Invalid count."); return; }

            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter Subject Code: ");
                string code = Console.ReadLine();
                Console.Write("Enter Subject Type: ");
                string type = Console.ReadLine();

                Console.Write("Enter Credit Hours: ");
                if (!int.TryParse(Console.ReadLine(), out int ch)) { Console.WriteLine("Invalid credit hours. Skipping."); continue; }

                Console.Write("Enter Subject Fees: ");
                if (!int.TryParse(Console.ReadLine(), out int fees)) { Console.WriteLine("Invalid fees. Skipping."); continue; }

                Subject s = new Subject(code, type, ch, fees);
                if (!dp.addSubject(s))
                    Console.WriteLine("20 credit hour limit exceeded! Subject not added.");
            }

            programList.Add(dp);
            Console.WriteLine("Degree Program added successfully!");
        }

        //--- add a new student with preferences ---
        static void addStudent()
        {
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Name cannot be empty."); return; }

            Console.Write("Enter Student Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age)) { Console.WriteLine("Invalid age."); return; }

            Console.Write("Enter Student FSc Marks: ");
            if (!double.TryParse(Console.ReadLine(), out double fsc)) { Console.WriteLine("Invalid marks."); return; }

            Console.Write("Enter Student Ecat Marks: ");
            if (!double.TryParse(Console.ReadLine(), out double ecat)) { Console.WriteLine("Invalid marks."); return; }

            Console.WriteLine("Available Degree Programs:");
            for (int i = 0; i < programList.Count; i++)
                Console.WriteLine(programList[i].degreeName);

            Console.Write("Enter how many preferences: ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count < 0) { Console.WriteLine("Invalid count."); return; }

            List<DegreeProgram> prefs = new List<DegreeProgram>();
            for (int i = 0; i < count; i++)
            {
                Console.Write("Enter Preference " + (i + 1) + ": ");
                string pname = Console.ReadLine();
                for (int j = 0; j < programList.Count; j++)
                    if (programList[j].degreeName == pname)
                        prefs.Add(programList[j]);
            }

            Student st = new Student(name, age, fsc, ecat, prefs);
            studentList.Add(st);
            Console.WriteLine("Student added successfully!");
        }

        //--- sort by merit and assign degree programs ---
        static void generateMerit()
        {
            for (int i = 0; i < studentList.Count - 1; i++)
            {
                for (int j = 0; j < studentList.Count - i - 1; j++)
                {
                    if (studentList[j].merit < studentList[j + 1].merit)
                    {
                        Student temp = studentList[j];
                        studentList[j] = studentList[j + 1];
                        studentList[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < studentList.Count; i++)
            {
                bool admitted = false;
                for (int j = 0; j < studentList[i].preferences.Count; j++)
                {
                    DegreeProgram dp = studentList[i].preferences[j];
                    if (dp.seats > 0)
                    {
                        studentList[i].regDegree = dp;
                        dp.seats--;
                        Console.WriteLine(studentList[i].name + " got Admission in " + dp.degreeName);
                        admitted = true;
                        break;
                    }
                }
                if (!admitted)
                    Console.WriteLine(studentList[i].name + " did not get Admission");
            }

            meritDone = true;
        }

        //--- show all admitted students ---
        static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\t\tFSC\t\tEcat\tAge");
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < studentList.Count; i++)
                if (studentList[i].regDegree != null)
                    Console.WriteLine(studentList[i].name + "\t\t" + studentList[i].fscMarks + "\t\t" + studentList[i].ecatMarks + "\t" + studentList[i].age);
        }

        //--- show students in a specific degree ---
        static void viewStudentsInDegree()
        {
            Console.Write("Enter Degree Name: ");
            string dname = Console.ReadLine();

            Console.WriteLine("Name\t\tFSC\t\tEcat\tAge");
            Console.WriteLine("----------------------------------------");
            for (int i = 0; i < studentList.Count; i++)
                if (studentList[i].regDegree != null && studentList[i].regDegree.degreeName == dname)
                    Console.WriteLine(studentList[i].name + "\t\t" + studentList[i].fscMarks + "\t\t" + studentList[i].ecatMarks + "\t" + studentList[i].age);
        }

        //--- register a subject for a student ---
        static void registerSubjects()
        {
            Console.Write("Enter Student Name: ");
            string sname = Console.ReadLine();

            Student st = null;
            for (int i = 0; i < studentList.Count; i++)
                if (studentList[i].name == sname)
                    st = studentList[i];

            if (st == null) { Console.WriteLine("Student not found!"); return; }
            if (st.regDegree == null) { Console.WriteLine("Student is not admitted yet!"); return; }

            Console.WriteLine("Subjects in " + st.regDegree.degreeName + ":");
            for (int i = 0; i < st.regDegree.subjects.Count; i++)
                Console.WriteLine("Code: " + st.regDegree.subjects[i].code + "  CH: " + st.regDegree.subjects[i].creditHours);

            Console.Write("Enter Subject Code to Register: ");
            string code = Console.ReadLine();

            Subject sub = null;
            for (int i = 0; i < st.regDegree.subjects.Count; i++)
                if (st.regDegree.subjects[i].code == code)
                    sub = st.regDegree.subjects[i];

            if (sub == null) { Console.WriteLine("Subject not found!"); return; }

            if (st.regStudentSubject(sub))
                Console.WriteLine("Subject registered successfully!");
            else
                Console.WriteLine("Cannot register! 9 credit hour limit exceeded or wrong subject.");
        }

        //--- print fees for all admitted students ---
        static void calculateFees()
        {
            Console.WriteLine("Name\t\tTotal Fee");
            Console.WriteLine("------------------------");
            for (int i = 0; i < studentList.Count; i++)
                if (studentList[i].regDegree != null)
                    Console.WriteLine(studentList[i].name + "\t\t" + studentList[i].calculateFee());
        }

        static void Main(string[] args)
        {
            int option = 0;
            do
            {
                showMenu();
                if (!int.TryParse(Console.ReadLine(), out option)) { Console.WriteLine("Invalid input!"); continue; }

                if (option == 1)
                {
                    if (programList.Count == 0)
                        Console.WriteLine("Please add a Degree Program first!");
                    else
                        addStudent();
                }
                else if (option == 2)
                {
                    addDegreeProgram();
                }
                else if (option == 3)
                {
                    if (studentList.Count == 0)
                        Console.WriteLine("No students found!");
                    else
                        generateMerit();
                }
                else if (option == 4)
                {
                    if (!meritDone)
                        Console.WriteLine("Please generate merit first!");
                    else
                        viewRegisteredStudents();
                }
                else if (option == 5)
                {
                    viewStudentsInDegree();
                }
                else if (option == 6)
                {
                    registerSubjects();
                }
                else if (option == 7)
                {
                    if (!meritDone)
                        Console.WriteLine("Please generate merit first!");
                    else
                        calculateFees();
                }
                else if (option == 8)
                {
                    Console.WriteLine("Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

                Console.WriteLine("Press any key to Continue..");
                Console.ReadKey();
                Console.Clear();

            } while (option != 8);
        }
    }
}