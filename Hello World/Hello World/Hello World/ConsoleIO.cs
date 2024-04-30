using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class ConsoleIO
    {
        public static void Run()
        {
            Console.WriteLine("Hello my name is Gabriel!");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine().Trim();

            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine().Trim());

            Console.WriteLine($"Your name is {name}, and your age is {age}");

            if (age <0 || age > 150)
            {
                Console.WriteLine("Error: invalid age.");
                return;
            }

            if (age >= 18 && age <= 25) 
            { 
                Console.WriteLine("You are between 18 and 25");
            }    
            else if (age >= 26)
            {
                Console.WriteLine("You are older than 26");
            }
        }
    }
}
