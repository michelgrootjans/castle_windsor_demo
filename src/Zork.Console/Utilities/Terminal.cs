using System;

namespace Zork.ConsoleApp.Utilities
{
    public class Terminal
    {
        public static string ReadPassword()
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

        public static void Clear()
        {
            Console.Clear();
        }

        public static void WriteLine(string message = null, params object[] arguments)
        {
                if (message == null)
                    Console.WriteLine();
                else
                    Console.WriteLine(message, arguments);

        }

        public static void Write(string message, params object[] arguments)
        {
            Console.Write(message, arguments);
        }

        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}