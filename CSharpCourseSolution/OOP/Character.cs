using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Character
    {
        private static int speed = 10; //static property/field will be the same for all instance of this class

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

        public int PrintSpeed()
        {
            Console.WriteLine($"Speed = {speed}");
            return speed;
        }

        public void IncreaseSpeed()
        {
            speed += 10;
        }
    }
}
