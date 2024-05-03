using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Operations
    {
        public static void Run()
        {
            double age = 23;

            age++;
            age = age + 10;
            age += 10;
            Console.WriteLine(age);

            age /= 10; // 4.4 -> 4, unless we convert int age to double
            Console.WriteLine(age);

            string name = "Gab";
            name += " is programming!";
            Console.WriteLine(name);
            
            char ch = 'a';
            ch += 'b';
            Console.WriteLine(ch); // adds unicode values together -> Ã

            int i = 0;
            Console.WriteLine(++i); // ++ before i to compute before and print later

            // Modulus
            int firstNum = 10;
            int secondNum = 3;

            Console.WriteLine(firstNum % secondNum); // 10 / 3 = 3r1 -> 1 
        }
    }
}
