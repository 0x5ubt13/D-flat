using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int x = 10,
                y = 20,
                z = 30;
            
            Console.WriteLine($"x = {x}, y = {y}, z = {z}");

            // var age; -> not possible to create var and not assign value

            string textAge = "23";
            var age = Convert.ToInt32(textAge);
            Console.WriteLine(age);

            Console.WriteLine(int.MaxValue);
            Console.WriteLine(int.MinValue);

            string textBigNumber = "-900000000000";
            // long bigNumber = -900000000000L;
            long bigNumber = Convert.ToInt64(textBigNumber);
            Console.WriteLine(bigNumber);
            Console.WriteLine(long.MaxValue);
            Console.WriteLine(long.MinValue);

            string textNegative = "-55.2";
            // double negative = -55.2D;
            double negative = Convert.ToDouble(textNegative);
            Console.WriteLine(negative);
            Console.WriteLine(double.MaxValue);
            Console.WriteLine(double.MinValue);

            string textPrecision = "5.0000001";
            // float precision = 5.0000001F;
            float precision = Convert.ToSingle(textPrecision);
            Console.WriteLine(precision);
            Console.WriteLine(float.MaxValue);
            Console.WriteLine(float.MinValue);

            string textMoney = "14.99";
            //decimal money = 14.99M;
            decimal money = Convert.ToDecimal(textMoney);
            Console.WriteLine(money);
            Console.WriteLine(decimal.MaxValue);
            Console.WriteLine(decimal.MinValue);

            // Call classes
            //String_Chars.Run();
            //Bool.Run();
            //Operations.Run();
            //ConsoleIO.Run();
            //ControlFlow.Run();
            //ConditionalOperator.Run();
            //NumericFormatting.Run();
            //MiniExerciseTimesTable.Run();
            //FizzBuzz.Run();
            //VerbatimStringLiteral.Run();
            //MiniExercisePasswordChecker.Run();
            //Arrays.Run();
            //Lists.Run();
            Dictionaries.Run();

            Console.ReadLine();
        }
    }
}
