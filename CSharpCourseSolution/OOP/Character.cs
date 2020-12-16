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

        public Race Race { get; private set; }
        public int Armor { get; private set; }
        public string Name { get; private set; }

        public Character(Race race)
        {
            Race = race;
            Armor = 30;
        }
        public Character(Race race, int armor)
        {
            Race = race;
            Armor = armor;
        }

        public Character(string name, int armor)
        {
            if (name==null)
                throw new ArgumentNullException("name arg can't be null");
            if (armor < 0 || armor > 100) throw new ArgumentException("armor can't be less than 0 or greater than 100");

            Name = name;
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
            if (GetHealth() == 0)
            {
                throw new InvalidOperationException("cannot hit a dead character ");
            }
            if (damage > GetHealth()) throw new ArgumentException("damage can't be less");

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
