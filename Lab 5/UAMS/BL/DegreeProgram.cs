using System.Collections.Generic;

namespace uams.BL
{
    public class DegreeProgram
    {
        public string name;
        public int seats;
        public int minMarks;
        public List<Subject> subjects;

        public DegreeProgram(string n, int s, int m)
        {
            name = n;
            seats = s;
            minMarks = m;
            subjects = new List<Subject>();
        }
    }
}