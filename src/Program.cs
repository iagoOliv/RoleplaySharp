namespace RPSharp;

public class Program
{
    public static void Main(string[] args)
    {
        Battle battle = new(new("Cloud", 50, 10, 5));
        battle.Start();
        Console.WriteLine("The battle is over!");
        Console.ReadLine();
    }
}
