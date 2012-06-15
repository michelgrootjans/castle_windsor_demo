using System;

namespace Zork.ConsoleApp.Utilities
{
    public class ConsolePasswordReader
    {
        public static string ReadLine()
        {
            var password = "";
            var info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        password = password.Substring
                            (0, password.Length - 1);
                    }
                }
                else
                {
                    password += info.KeyChar;
                    Console.Write("*");
                }
                info = Console.ReadKey(true);
            }
            Console.WriteLine();
            return password;
        }
    }
}