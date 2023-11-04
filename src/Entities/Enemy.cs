namespace src
{
    public class Enemy : Entity
    {
        public Enemy(string name, int health, int damage, int defense) 
            : base(name, health, damage, defense)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Defense = defense;
        }
    }
}

