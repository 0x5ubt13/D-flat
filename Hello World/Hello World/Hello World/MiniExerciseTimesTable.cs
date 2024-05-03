using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class MiniExerciseTimesTable
    {
        public static void Run() 
        {
            /*
             * Ask the user for a number for the table
             * Write a for loop to pront X times table
             */

            int parsedNum;

            while (true)
            {
                Console.Write("Please enter a number to print its times table: ");
                string inputNum = Console.ReadLine();
                if (int.TryParse(inputNum, out _))
                {
                    parsedNum = Convert.ToInt32(inputNum);
                    break;
                }

                Console.WriteLine("Please enter a valid number.");
            }
            
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{parsedNum} x {i} = {parsedNum * i}");
            }
        }
    }
}
