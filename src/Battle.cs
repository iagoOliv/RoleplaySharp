using RPSharp.Entities;
using RPSharp.Util;

namespace RPSharp;

public class Battle
{
    private readonly Random _rand = new();
    private readonly Player _hero;
    private readonly List<Entity> _turns;
    private readonly Enemy[] _enemies;
    private bool _ran = false;
    private static string Actions => "1) Attack\n2) Defend\n3) Potion\n4) Run";

    
    public Battle(Player hero)
    {
        _hero = hero;
        _turns = new List<Entity> { hero };
        
        var enemyCount = _rand.Next(1,3);
        _enemies = new Enemy[enemyCount];

        // Push enemies to the Turn List and Enemy Array
        for (var i = 0; i < enemyCount; i++)
        {
            Enemy enemy = new($"Slime {i}", 20, 2, 1);
            _turns.Add(enemy);
            _enemies[i] = enemy;
        }
    }

    
    public void Start()
    {
        while (!_hero.IsDead && _turns.Count > 1 && !_ran)
        {
            Console.Write(_turns.Count);
            PrintEntities();

            for (var i = 0; i < _turns.Count; i++)
            {
                if (_turns[i] is Player)
                {
                    ChooseAction();
                    CheckEntities();
                    if (_ran) { break; }
                }
                else
                {
                    _turns[i].Attack(_hero);
                    ColorPrint.Print(Log.Damage(_turns[i].Name, _turns[i].Damage, _hero.Name), "damage");
                }

                Thread.Sleep(500);
            }
        }
    }

    
    private void ChooseAction()
    {
        ColorPrint.Print(Actions, "success");
        ColorPrint.Print("Choose an Action", "success");
        var action = int.Parse(Console.ReadLine() ?? string.Empty);

        switch (action)
        {
            case 1:
                ColorPrint.Print("Choose the Enemy index", "success");
                var enemyIndex = int.Parse(Console.ReadLine() ?? string.Empty);

                if (!_enemies[enemyIndex].IsDead)
                {
                    _hero.Attack(_enemies[enemyIndex]);
                    ColorPrint.Print(Log.Damage(_hero.Name, _hero.Damage, _enemies[enemyIndex].Name), "damage");
                }
                else
                {
                    ColorPrint.Print("This enemy is already dead!", "damage");
                }
                break;

            case 2:
                _hero.Defend();
                ColorPrint.Print("You are defending!", "success");
                break;

            case 3:
                _hero.UsePotion();
                ColorPrint.Print("You used a potion!", "success");
                break;

            case 4:
                _ran = true;
                ColorPrint.Print("You ran!", "success");
                break;

            default:
                break;
        }
    }


    private void CheckEntities()
    {
        for (var i = 0; i < _turns.Count; i++)
        {  
            if (_turns[i].IsDead) { _turns.Remove(_turns[i]); }
        }
    }

    
    private void PrintEntities()
    {
        foreach (var entity in _turns)
        {
            Console.Write(entity);
        }
    }
}

