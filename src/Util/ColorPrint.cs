using System;

namespace src
{
    public class ColorPrint
    {
        public static void Print(string String, string type)
        {
            // I preferred to make a Switch instead of ConsoleColor.{color} to simplify the colors;
            switch (type)
            {
                case "info":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case "damage":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case "success":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine(String);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}

