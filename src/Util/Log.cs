namespace RPSharp.Util;

public class Log
{
    public static string LogThis(string type)
    {
        string log = type switch
        {
            "heal" => "You healed!\n",
            "defend" => "You are defending!\n",
            _ => "Invalid."
        };

        return log;
    }

    public static string Damage(string attacker, int damage, string name)
    {
        return $"{attacker} has dealt {damage} damage to {name}\n";
    }
}
