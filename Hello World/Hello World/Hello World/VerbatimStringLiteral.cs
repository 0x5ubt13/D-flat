using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class VerbatimStringLiteral
    {
        public static void Run()
        {
            Console.WriteLine("C:\\Windows\\System32\\cmd.exe");
            Console.WriteLine(@"C:\Windows\System32\cmd.exe" + "\nNew line test");
            Console.WriteLine("He said \"something\"");
            Console.WriteLine(@"He said ""something""");
            Console.WriteLine("Hello 'someone'");
        }
    }
}
