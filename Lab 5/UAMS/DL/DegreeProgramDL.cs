using System.Collections.Generic;
using uams.BL;

namespace uams.DL
{
    public class DegreeProgramDL
    {
        public static List<DegreeProgram> programList = new List<DegreeProgram>();

        public static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
    }
}