using System;
using System.Collections;

namespace src
{
    public class Entity
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }
        public bool IsDead { get => Health <= 0; }

        public Entity(string name, int health, int damage, int defense)
        {
            Name = name;
            Health = health;
            Damage = damage;
            Defense = defense;
        }

        public override string ToString()
        {
            return $"{Name}: Health = {Health} / Damage = {Damage} / Defense = {Defense}";
        }

        public void Attack(Entity entity)
        {
            int calculatedDamage = (int)((Damage - entity.Defense));

            if (entity.Health - calculatedDamage <= 0)
            {
                entity.Health = 0;
            }
            else 
            {
                entity.Health -= calculatedDamage;
            }         
        }
    }
}
