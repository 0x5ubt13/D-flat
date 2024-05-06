using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Lists
    {
        public static void Run()
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            numbers.RemoveAt(0);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
