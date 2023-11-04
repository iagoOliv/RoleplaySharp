using System.Collections;

namespace src
{
    public class Player : Entity
    {
        private ArrayList Inventory;
        private Boolean IsDefending { get; set; }

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
                if (item.Type == "potion")
                {
                    if (Health + item.Value >= 100) 
                    {
                        Health = 100;
                        return; 
                    }
                    Health += item.Value;
                }
            }
        }

        public void AddItemToInventory(string type, int value)
        {
            Item item = new Item(type, value);
            this.Inventory.Add(item);
        }
    }
}