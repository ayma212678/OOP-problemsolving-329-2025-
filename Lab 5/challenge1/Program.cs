namespace Challenge1
{
    class Program
    {
        //--- static line object ---
        static MyLine line = null;

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\n========= MyLine Menu =========");
                Console.WriteLine("1. Make a Line");
                Console.WriteLine("2. Update the Begin Point");
                Console.WriteLine("3. Update the End Point");
                Console.WriteLine("4. Show the Begin Point");
                Console.WriteLine("5. Show the End Point");
                Console.WriteLine("6. Get the Length of the Line");
                Console.WriteLine("7. Get the Gradient of the Line");
                Console.WriteLine("8. Find Distance of Begin Point from Origin");
                Console.WriteLine("9. Find Distance of End Point from Origin");
                Console.WriteLine("10. Exit");
                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter begin point x: ");
                        int x1 = int.Parse(Console.ReadLine());
                        Console.Write("Enter begin point y: ");
                        int y1 = int.Parse(Console.ReadLine());
                        Console.Write("Enter end point x: ");
                        int x2 = int.Parse(Console.ReadLine());
                        Console.Write("Enter end point y: ");
                        int y2 = int.Parse(Console.ReadLine());
                        line = new MyLine(x1, y1, x2, y2);
                        Console.WriteLine("Line created!");
                        break;

                    case 2:
                        CheckLine();
                        Console.Write("Enter new begin x: ");
                        int bx = int.Parse(Console.ReadLine());
                        Console.Write("Enter new begin y: ");
                        int by = int.Parse(Console.ReadLine());
                        line.SetBegin(bx, by);
                        Console.WriteLine("Begin point updated!");
                        break;

                    case 3:
                        CheckLine();
                        Console.Write("Enter new end x: ");
                        int ex = int.Parse(Console.ReadLine());
                        Console.Write("Enter new end y: ");
                        int ey = int.Parse(Console.ReadLine());
                        line.SetEnd(ex, ey);
                        Console.WriteLine("End point updated!");
                        break;

                    case 4:
                        CheckLine();
                        Console.WriteLine($"Begin Point: {line.GetBegin()}");
                        break;

                    case 5:
                        CheckLine();
                        Console.WriteLine($"End Point: {line.GetEnd()}");
                        break;

                    case 6:
                        CheckLine();
                        Console.WriteLine($"Length of line: {line.GetLength():F2}");
                        break;

                    case 7:
                        CheckLine();
                        double g = line.GetGradient();
                        if (!double.IsNaN(g))
                            Console.WriteLine($"Gradient of line: {g:F2}");
                        break;

                    case 8:
                        CheckLine();
                        Console.WriteLine($"Distance of begin from origin: {line.BeginDistanceFromZero():F2}");
                        break;

                    case 9:
                        CheckLine();
                        Console.WriteLine($"Distance of end from origin: {line.EndDistanceFromZero():F2}");
                        break;

                    case 10:
                        Console.WriteLine("Exiting...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            } while (choice != 10);
        }

        //--- checks if line exists before any operation ---
        static void CheckLine()
        {
            if (line == null)
            {
                Console.WriteLine("No line created yet! Please choose option 1 first.");
                throw new InvalidOperationException();
            }
        }
    }
}