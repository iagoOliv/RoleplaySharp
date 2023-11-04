using System;
using System.Collections;

namespace src
{
    public class Battle
    {
        public Random rand = new();
        public Player Hero;
        public ArrayList Turns;
        public Entity[] Enemies;
        private string Actions 
        {
            get =>
                "1) Attack\n2) Defend\n3) Potion\n4) Run";
        }

        // <summary>
        //  Sets up the Turns Array
        // </summary>
        public Battle(Player hero)
        {
            Hero = hero;
            Turns = new();
            Turns.Add(hero);
            int EnemyCount = rand.Next(1,3);

            Enemies = new Entity[EnemyCount];

            // Push enemies to the Turn List
            for (int i = 0; i < EnemyCount; i++)
            {
                Enemy enemy = new($"Slime {i}", 20, 2, 1);
                Turns.Add(enemy);
                Enemies[i] = enemy;
            }
        }

        // Could a delegate be implemented?
        public void ParseTurns()
        {
            while ((!Hero.IsDead) || (Turns.Count > 1))
            {
                foreach (Entity entity in Turns)
                {
                    ColorPrint.Print(entity.ToString(),"info");
                }

                foreach (Entity entity in Turns)
                {
                    if (entity is Player)
                    {
                        ColorPrint.Print("Choose an Action", "success");
                        string option = ChooseAction();
                        
                        switch (option)
                        {
                            case "attack":
                                ColorPrint.Print("Choose the Enemy index", "success");
                                int enemyIndex = Int32.Parse(Console.ReadLine());

                                Hero.Attack(Enemies[enemyIndex]);
                                ColorPrint.Print(Log.Damage(Hero.Name, Hero.Damage, Enemies[enemyIndex].Name), "damage");
                                break;
                            case "defend":
                                Hero.Defend();
                                break;
                            case "potion":
                                Hero.UsePotion();
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        entity.Attack(Hero);
                        ColorPrint.Print(Log.Damage(entity.Name, entity.Damage, Hero.Name), "damage");
                    }

                    if (entity.IsDead) { Turns.Remove(entity); }

                    Thread.Sleep(1000);
                }
            }
        }

        public string ChooseAction()
        {
            ColorPrint.Print(Actions, "success");
            int action = Int32.Parse(Console.ReadLine());
            
            return action switch 
            {
                1 => "attack",
                2 => "defend",
                3 => "heal",
                _ => "attack"
            };
        }

        public static void Main(string[] args)
        {
            Battle battle = new(new("Heroi", 50, 10, 5));
            battle.ParseTurns();
        }
    }
}
