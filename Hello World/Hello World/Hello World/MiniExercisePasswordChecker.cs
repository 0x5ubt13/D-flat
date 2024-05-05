using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hello_World
{
    internal class MiniExercisePasswordChecker
    {
        public static void Run()
        {
            /* Ask user to enter password and store
             * Ask user to enter password again, and store
             * Check if they are both containing something
                * If so, check if they are the same
                    * If they are, print "Passwords match"
                    * If they are not, print "Passwords do not match"
                * If they are empty, print "Please enter a password"
             */

            string newPassword, confirmPassword;

            while (true)
            {
                Console.Write("Please enter your new password: ");
                newPassword = GetHashString(Console.ReadLine());

                if (newPassword == "error") 
                {
                    continue;
                }

                if (string.IsNullOrEmpty(newPassword))
                {
                    Console.WriteLine("Please enter a password.");
                    continue;
                }

                while (true)
                {
                    Console.Write("Please enter your new password again: ");
                    confirmPassword = GetHashString(Console.ReadLine());

                    if (string.IsNullOrEmpty(newPassword))
                    {
                        Console.WriteLine("Please enter a password.");
                        continue;
                    }

                    break;
                }

                if (newPassword != confirmPassword)
                {
                    Console.WriteLine("Passwords do not match.");
                    continue;
                }

                Console.WriteLine("Passwords match.");
                break;
            }
        }

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            if (inputString.Length < 6)
            {
                Console.WriteLine("Error. Please enter 6 or more characters");
                return "error";
            }
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
