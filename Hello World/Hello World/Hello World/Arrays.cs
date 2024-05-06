using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Arrays
    {
        public static void Run()
        {
            int[] numbers = new int[]
            {
                1, 2, 3, 76, 5, 9, 0, 8, 22, 10
            };

            numbers[0] = 35;
            numbers[1] = 23;
            numbers[2] = 95;

            // Arrays that are rearranged in memory don't need to be returned to a var
            Array.Reverse(numbers);
            Array.Sort(numbers);

            foreach (int num in numbers)
            {
                Console.WriteLine($"{num}");
            }

            Console.Write("Enter a number to search for: ");
            int search = Convert.ToInt32(Console.ReadLine());
            //int position = Array.IndexOf(numbers, search);
            int searchStart = 0;
            int searchEnd = 5;
            int position = Array.IndexOf(numbers, search, searchStart, searchEnd);

            if (position > -1)
            {
                Console.WriteLine($"[+] Number {search} has been found at position {position} between indexes {searchStart}, {searchEnd}");
            }
            else
            {
                Console.WriteLine($"[-] Number {search} has not been found between indexes {searchStart}, {searchEnd}.");
            }
        }
    }
}
