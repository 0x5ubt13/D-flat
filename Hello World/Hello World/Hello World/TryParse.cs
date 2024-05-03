using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class TryParse
    {
        public static void Run()
        {
            bool success = false;
            while (!success) 
            {
                Console.Write("Enter a number: ");
                string numInput = Console.ReadLine();

                if (int.TryParse(numInput, out int num))
                {
                    success = true;
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Failed to convert");
                }
            }
        }
    }
}
