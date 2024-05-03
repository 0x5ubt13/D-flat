using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class FizzBuzz
    {
        public static void Run()
        {
            /*
             * Create a for loop from 1 to X (15)
             * 3 and 5 = FizzBuzz
             * 3 = Fizz
             * 5 = Buzz
             * else = number
             */

            bool divByThree = false;
            bool divByFive = false;

            for (int i = 1; i <= 15; i++)
            {
                divByThree = i % 3 == 0;
                divByFive = i % 5 == 0;

                if (divByThree && divByFive)
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (divByThree)
                {
                    Console.WriteLine("Fizz");
                }
                else if (divByFive)
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
