using System;
using System.Collections.Generic;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            PointVal? pv = null;
            if (pv.HasValue)
            {
                PointVal pv2 = pv.Value;
                Console.WriteLine(pv.Value.X);
                Console.WriteLine(pv2.X);

            }
            else
            {

            }
            PointVal pv3 = pv.GetValueOrDefault();

            PointRef c = null; ;
            Console.WriteLine(c.X); //NullReferenceException

            Calculator calc = new Calculator();

            if (calc.TryDivide(10, 0, out double result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Failed to divide");
            }


            Console.WriteLine("Enter a number, please");
            string line = Console.ReadLine();
            bool wasParsed = int.TryParse(line, out int number);
            if (wasParsed)
            {
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine("Failed to parse");
            }

            Character carachter = new Character();
            carachter.Hit(120);
            Console.WriteLine(carachter.GetHealth());

            Character c1 = new Character();
            Character c2 = new Character();
            Console.WriteLine($"c1.Speed = {c1.PrintSpeed()} c2.Speed = {c2.PrintSpeed()}");
            c1.IncreaseSpeed();
            Console.WriteLine($"c1.Speed = {c1.PrintSpeed()} c2.Speed = {c2.PrintSpeed()}");

            Calculator cal = new Calculator();
            double avg = cal.Average(new int[] { 8, 7, 9 });
            Console.WriteLine(avg);

            double avg2 = cal.Average2(8, 7, 9);
            Console.WriteLine(avg2);

            double square1 = cal.CalcTriangleSquare(10, 20);
            double square2 = cal.CalcTriangleSquare(ab: 40, bc: 20, ca: 30.5);

            double square3 = cal.CalcTriangleSquare(ab: 10, bc: 20, alpha: 50);
        }

        static void PassByRefDemo()
        {
            int aa = 1;
            int bb = 2;
            Swap(ref aa, ref bb);
            Console.WriteLine($"a={aa}, b ={bb}");

            var list = new List<int>();
            AddNumbers(list);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
        static void Swap(ref int a, ref int b)
        {
            Console.WriteLine($"Original a={a}, b={b}");

            int tmp = a;
            a = b;
            b = tmp;

            Console.WriteLine($"Swapped a={a}, b={b}");
        }
        static void AddNumbers(List<int> numbers)
        {
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(4);
        }
        public static void ValRefTypesDemo()
        {
            EvilStruct es1 = new EvilStruct();
            es1.PointRef = new PointRef() { X = 1, Y = 2 };
            //es1.PointRef.X = 1;
            //es1.PointRef.Y = 2;

            EvilStruct es2 = es1;
            Console.WriteLine($"es1.PointRef.X ={es1.PointRef.X}, es1.PointRef.Y ={es1.PointRef.Y}");
            Console.WriteLine($"es2.PointRef.X ={es2.PointRef.X}, es2.PointRef.Y ={es2.PointRef.Y}");

            es2.PointRef.X = 42;
            es2.PointRef.Y = 45;
            Console.WriteLine($"es1.PointRef.X ={es1.PointRef.X}, es1.PointRef.Y ={es1.PointRef.Y}");
            Console.WriteLine($"es2.PointRef.X ={es2.PointRef.X}, es2.PointRef.Y ={es2.PointRef.Y}");

            PointVal a; // same as PointVal a = new PointVal();
            a.X = 3;
            a.Y = 5;

            PointVal b = a;
            b.X = 7;
            b.Y = 10;

            a.LogValues();
            b.LogValues();

            Console.WriteLine("After structers");

            PointRef c = new PointRef();
            c.X = 3;
            c.Y = 5;

            PointRef d = c;
            d.X = 7;
            d.Y = 10;

            c.LogValues();
            d.LogValues();

        }
    }
}
