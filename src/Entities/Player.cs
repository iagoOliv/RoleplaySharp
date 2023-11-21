using System.Collections;
using RPSharp.Entities.Items;

namespace RPSharp.Entities;

public class Player : Entity
{
    protected ArrayList Inventory;
    protected bool IsDefending;

    public Player(string name, int health, int damage, int defense) 
        : base(name, health, damage, defense)
    {
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.Defense = defense;
        this.Inventory = new ArrayList();

        Item potion = new("potion", 10);
        Inventory.Add(potion);
    }

    public void Defend()
    {
        if (!IsDefending)
        {
            Defense += 2;
        }
    }

    public void UsePotion()
    {
        foreach (Item item in Inventory)
        {
            if (item.Type != "potion") continue;
            if (Health + item.Value >= 50) 
            {
                Health = 50;
                return; 
            }
            Health += item.Value;
        }
    }

    public void AddItemToInventory(string type, int value)
    {
        Item item = new Item(type, value);
        this.Inventory.Add(item);
    }
}
