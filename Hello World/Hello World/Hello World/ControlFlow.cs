using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class ControlFlow
    {
        public static void Run() 
        {   
            // Switches
            Console.WriteLine("Enter the number of a day of the week: ");
            int day = Convert.ToInt32(Console.ReadLine());

            switch (day)
            { 
                case 1: Console.WriteLine("Mon");
                    break;
                case 2: Console.WriteLine("Tue");
                    break;
                case 3: Console.WriteLine("Wed");
                    break;
                case 4: Console.WriteLine("Thu");
                    break;
                case 5: Console.WriteLine("Fri");
                    break;
                case 6: Console.WriteLine("Sat");
                    break;
                case 7: Console.WriteLine("Sun");
                    break;
                default: Console.WriteLine("Invalid, please enter a value between 1 and 7");
                    break;
            }

            // For loops
            Console.Write("What message do you want to repeat? ");
            string message = Console.ReadLine().Trim();

            Console.Write("How many times do you want the for loop to repeat? ");
            int times = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Looping {times}");
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(message);
            }

            // While loops
            while (true)
            {
                Console.Write("What's 5 plus 2? ");
                int answer = Convert.ToInt32(Console.ReadLine().Trim());

                if (answer == 7)
                {
                    break;
                }
            }
        }

    }
}
