using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challlenge_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            
         
                WorkoutRoutine myRoutine = new WorkoutRoutine { Name = "Morning Weights" };

                Exercise squats = new Exercise { Name = "Squats" };

             
                squats.Sets.Add(new Set { Weight = 50, Reps = 10 });
                squats.Sets.Add(new Set { Weight = 55, Reps = 8 });

                myRoutine.Exercises.Add(squats);

                myRoutine.ShowWorkout();
            
        }
    }
}
