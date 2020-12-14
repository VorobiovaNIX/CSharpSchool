using System;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {

            Character c = new Character();
            c.Hit(120);

            Console.WriteLine(c.GetHealth());
        }
    }
}
