using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challlenge_3
{
     public class WorkoutRoutine
    {
        public string Name;
        public List<Exercise> Exercises = new List<Exercise>();

        public void ShowWorkout()
        {
            Console.WriteLine("Workout: " + Name);
            foreach (var ex in Exercises)
            {
                Console.WriteLine("- " + ex.Name);
                foreach (var s in ex.Sets)
                {
                    Console.WriteLine("   " + s.Weight + "kg x " + s.Reps);
                }
            }
        }
    }


}
