using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Dictionaries
    {
        public static void Run()
        {
            Dictionary<int, string> keyValuePairs = new Dictionary<int, string> 
            {
                { 1, "Gab" },
                { 2, "Test" },
                { 3, "Test" }
            };

            for (int i = 0; i < keyValuePairs.Count; i++)
            {
                KeyValuePair<int, string> pair = keyValuePairs.ElementAt(i); 
                //Console.WriteLine($"{keyValuePairs.ElementAt(i).Key} - {keyValuePairs.ElementAt(i).Value}");
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            keyValuePairs.Add(4, "Leo");

            foreach (KeyValuePair<int, string> item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
