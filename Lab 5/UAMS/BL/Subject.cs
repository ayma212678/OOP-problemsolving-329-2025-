namespace uams.BL
{
    public class Subject
    {
        public string code;
        public string type;
        public int creditHours;
        public int subjectFees;

        public Subject(string c, string t, int cH, int s)
        {
            code = c;
            type = t;
            creditHours = cH;
            subjectFees = s;
        }
    }
}