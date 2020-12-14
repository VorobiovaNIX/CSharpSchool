using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Character
    {
        //public int Health { get; private set; } = 100; auto property 

        private int health;
        public int Health = 100;

        public int GetHealth()
        {
            return health;
        }
        private void SetHealth(int value)
        {
            health = value;
        }

        public void Hit(int damage)
        {
            if (damage > GetHealth()) damage = GetHealth();
            //health -= damage;
            //Health -= damage;
            var health = GetHealth() - damage;
            SetHealth(health);
        }
    }
}
