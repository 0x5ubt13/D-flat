using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class NumericFormatting
    {
        public static void Run()
        {
            double value = 100D / 12.34;

            Console.WriteLine(value);
            Console.WriteLine(string.Format("€{0:0}", value));
            Console.WriteLine(string.Format("{0:0.0}", value));
            Console.WriteLine(string.Format("{0:0.00}", value));

            double money = -10D / 3D; //3.3333333

            Console.WriteLine(money);
            Console.WriteLine(string.Format("-£10 / £3 = £{0:0.00}", money)); // £-3.33
            // Culture info
            Console.WriteLine(money.ToString("C"));  // -£3.33
            Console.WriteLine(money.ToString("C0")); // -£3
            Console.WriteLine(money.ToString("C1")); // -£3.3
            Console.WriteLine(money.ToString("C2")); // -£3.33

            Console.WriteLine(money.ToString("C", CultureInfo.CurrentCulture)); // -£3.33
            Console.WriteLine(money.ToString("C", CultureInfo.CreateSpecificCulture("en-GB"))); // -£3.33
            Console.WriteLine(money.ToString("C", CultureInfo.CreateSpecificCulture("en-US"))); // ($3.33)
            Console.WriteLine(money.ToString("C", new CultureInfo("en-IE"))); // -€3.33
        }   
    }
}
