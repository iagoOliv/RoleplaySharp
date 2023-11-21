namespace RPSharp.Util;

public class ColorPrint
{
    public static void Print(string String, string type)
    {
        switch (type)
        {
            case "info":
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                break;
            case "damage":
                Console.ForegroundColor = ConsoleColor.Red;
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


