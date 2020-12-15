using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Point2D {

        private int x;
        private int y;

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    
    }

    public class Character
    {
        private static int speed=10; //static modifier of property/field will be the same for all instance of this class

        private const int height=120; // "const"/ "readonly" modifier makes field not changeable for all instance of this class


        //public int Health { get; private set; } = 100; auto property 

        private int health;
        public int Health = 100;

        public string Race { get; private set; }
        public int Armor { get; private set; }

        public Character(string race)
        {
            Race = race;
            Armor = 30;
        }
        public Character(string race, int armor)
        {
            Race = race;
            Armor = armor;
        }

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
