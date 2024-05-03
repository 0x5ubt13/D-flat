using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Bool
    {
        public static void Run()
        {
            bool weather = true;

            bool isSunny = true;

            if (weather == isSunny)
            {
                Console.WriteLine("The Sun's shining!!! Go play some golf!");
            }
        }
    }
}
