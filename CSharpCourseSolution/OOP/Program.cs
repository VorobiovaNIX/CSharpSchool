﻿using OOP.Homeworks;
using OOP.Homeworks.Hangman;
using OOP.Homeworks.TicTacToeGame;
using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    class Program
    {

        static void Main(string[] args)
        {

            HangmanGame game = new HangmanGame();

            string word = game.GenerateWord();

            Console.WriteLine($"The word consists of {word.Length} letters.");
            Console.WriteLine("Try to guess the word");

            while (game.GameStatus==GameStatus.InProgress)
            {
                Console.WriteLine("Pick a letter");
                char c = (char)Console.ReadLine().ToCharArray()[0];

                string curState = game.GuessLetter(c);
                Console.WriteLine(curState);

                Console.WriteLine($"Remaining tries = {game.RemainingTries}");
                Console.WriteLine($"Tried letters: {game.TriedLetters}");
            }

            if (game.GameStatus == GameStatus.Lost)
            {
                Console.WriteLine("You're hanged.");
                Console.WriteLine($"The word was: {game.Word}");
            }
            else if(game.GameStatus==GameStatus.Won){
                Console.WriteLine("You won!");
            }
        }

        private static TicTacToeGame g = new TicTacToeGame();

        static void HW_RunCrossesAndZeros()
        {
            Console.WriteLine(GetPrintableState());
            while (g.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                g.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }
            Console.WriteLine($"Result: {g.GetWinner()}");
            Console.ReadLine();

        }
        static string GetPrintableState()
        {
            var sb = new StringBuilder();
            for (int i = 1; i <=7; i+=3)
            {
                sb.AppendLine("    |   |   |")
                    .AppendLine(
                    $"  {GetPrintableChar(i)} | {GetPrintableChar(i + 1)} | {GetPrintableChar(i + 2)}  ")
                    .AppendLine("____|___|___|");

            }
            return sb.ToString();
        }

        static string GetPrintableChar(int index)
        {
            State state = g.GetState(index);
            if (state==State.Unset)
                return index.ToString();

            return state == State.Cross ? "X" : "O";
        }

        static void HW_RunNumberGuessingGame()
        {
            GuessNumberGame game = new GuessNumberGame(guessingPlayer: GuessingPlayer.Human);
            game.Start();

            GuessNumberGame game1 = new GuessNumberGame(guessingPlayer: GuessingPlayer.Machine);
            game1.Start();
        }
        static void HW_ComplexDemo()
        {
            Complex c1 = new Complex(1, 1);
            Complex c2 = new Complex(1, 2);

            Complex result = c1.Plus(c2);
            Console.WriteLine($"Result. Real ={result.Real}; Imaginary = {result.Imaginary}");
        }

        static void StackDemo()
        {
            MyStack<int> ms = new MyStack<int>();
            //System.Collections.IEnumerable enumer = (System.Collections.IEnumerable) ms;
            //enumer.GetEnumerator();

            ms.Push(1);
            ms.Push(2);
            ms.Push(3);

            foreach (var item in ms)
            {
                Console.WriteLine(item);
            }


            while (ms.Count != 0)
            {
                Console.WriteLine(ms.Peek());
                ms.Pop();
            }

            //Console.WriteLine(ms.Peek());

            ms.Pop();

            Console.WriteLine(ms.Peek());

            ms.Push(4);
            ms.Push(5);
            ms.Push(6);
            Console.WriteLine(ms.Peek());
        }

        static void CallingThroughInterface()
        {
            IShape rect = new Rect() { Height = 5, Width = 2 };
            IShape square = new Square { SideLength = 10 };

            Console.WriteLine($"Rect area = {rect.CalcSquare()}");
            Console.WriteLine($"Square area = {square.CalcSquare()}");

            //Rect rect = new Rect { Height = 2, Width = 5 }; // вызван конструктор по умолчания 
            //int rectArea = AreaCalculator.CalcSquare(rect);
            //Console.WriteLine($"Rect area = {rectArea}");

            //Rect square = new Square { Height = 5 };
            //int squareArea = AreaCalculator.CalcSquare(square);
            //Console.WriteLine($"Rect area = {square}");



            List<object> list = new List<object> { 1, 2, 3 };
            IBaseCollection collection = new BaseList(4);
            collection.Add(1);
            collection.AddRange(list);
        }

        static void PolymorphismDemo()
        {

            ModelXTerminal terminal = new ModelXTerminal("123");
            terminal.Connect();

            Shape[] shapes = new Shape[2];
            shapes[0] = new Triangle(10, 20, 30);
            shapes[1] = new Rectangle(5, 10);

            foreach (Shape item in shapes)
            {
                item.Draw();
                Console.WriteLine(item.Area());
                Console.WriteLine(item.Perimeter());
            }
        }

        static void CreateInstanceOfClass()
        {
            Character carachter = new Character(Race.Elf);
            carachter.Hit(120);
            Console.WriteLine(carachter.GetHealth());
            Console.WriteLine(carachter.Race);

            Character c1 = new Character(Race.Ork);
            Character c2 = new Character(Race.Terrain);
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

        static void OutParametrs()
        {
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
        }

        static void Do(object obj)
        {
            bool isPointRef = obj is PointRef; //keyword "is" checks is it true that value1 IS value2, return true if it's true 
            if (isPointRef)
            {
                PointRef pr = (PointRef)obj;
                Console.WriteLine(pr.X);
            }
            else
            {
                //do someting 
            }

            PointRef pr1 = obj as PointRef; //keyword "as": если obj это PointRef, то кастование произойдет автоматически и мы получим переменную pr1 типа PointRef, а если obj это НЕ PointRef, то переменная pr1 будет содержать NULL 
            if (pr1!= null)
            {
                Console.WriteLine(pr1.X);
            }
            else
            {
                // do somithing, e.g. throws exception 
            }

        }

        static void BoxingUnboxing()
        {
            int x = 1;
            object obj = x; //boxing 

            int y = (int)obj; //unboxing 

            double pi = 3.14;
            object obj1 = pi;

            int numb = (int)(double)obj1;
            Console.WriteLine(numb);
        }

        static void NRE_NullableValTypeDemo()
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
            //es1.PointRef = new PointRef() { X = 1, Y = 2 };
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
