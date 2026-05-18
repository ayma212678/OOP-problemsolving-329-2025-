using System.Collections.Generic;

namespace uams.BL
{
    public class Student
    {
        public string name;
        public int marks;
        public DegreeProgram regDegree;
        public List<DegreeProgram> preferences;
        public List<Subject> registeredSubjects;

        public Student(string n, int m)
        {
            name = n;
            marks = m;
            regDegree = null;
            preferences = new List<DegreeProgram>();
            registeredSubjects = new List<Subject>();
        }
    }
}