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
            string name = Console.ReadLine();

            Console.WriteLine("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Your name is {name}, and your age is {age}");

            Console.ReadLine();
        }
    }
}
