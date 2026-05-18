using uams.BL;

namespace uams.UI
{
    public class DegreeProgramUI
    {
        //--- take input and build a degree program ---
        public static DegreeProgram takeInputForDegree()
        {
            Console.Write("Enter Degree Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) { Console.WriteLine("Name cannot be empty."); return null; }

            Console.Write("Enter Total Seats: ");
            if (!int.TryParse(Console.ReadLine(), out int seats) || seats < 0) { Console.WriteLine("Invalid seats."); return null; }

            Console.Write("Enter Minimum Marks Required: ");
            if (!int.TryParse(Console.ReadLine(), out int minMarks) || minMarks < 0) { Console.WriteLine("Invalid marks."); return null; }

            DegreeProgram d = new DegreeProgram(name, seats, minMarks);

            Console.Write("How many subjects does this program have? ");
            if (!int.TryParse(Console.ReadLine(), out int count) || count < 0) { Console.WriteLine("Invalid count."); return null; }

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"\n-- Subject {i + 1} --");

                Console.Write("Subject Code: ");
                string code = Console.ReadLine();

                Console.Write("Type (Core/Elective): ");
                string type = Console.ReadLine();

                Console.Write("Credit Hours: ");
                if (!int.TryParse(Console.ReadLine(), out int ch)) { Console.WriteLine("Invalid credit hours. Skipping."); continue; }

                Console.Write("Subject Fee: ");
                if (!int.TryParse(Console.ReadLine(), out int fee)) { Console.WriteLine("Invalid fee. Skipping."); continue; }

                d.subjects.Add(new Subject(code, type, ch, fee));
            }

            return d;
        }
    }
}