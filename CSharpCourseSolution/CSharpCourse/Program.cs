using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpCourse
{
    class Program
    {
        static void Main(string[] args)
        {
           

        }

        static void CalculateBodyMassIndex()
        {
            Console.WriteLine("What is your last name?");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is your first name?");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is your age?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("What is your weight in kg?");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("What is your height in meters?");
            double height = double.Parse(Console.ReadLine());

            double bodyMassIndex = weight / (height * height);

            string profile =
                $"Your profile: {Environment.NewLine}"
                + $"Full name: {lastName} {firstName} {Environment.NewLine}"
                + $"Age: {age} {Environment.NewLine}"
                + $"Weight: {weight} {Environment.NewLine}"
                + $"Height: {height} {Environment.NewLine}"
                + $"Body Mass Index: {bodyMassIndex}";
            Console.WriteLine(profile);
        }
        static void NumberOfDigits()
        {
            Console.WriteLine("Enter the integer");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine($"The number of digits: {number.ToString().Length}");
        }
        static void AreaOfTriangle()
        {
            Console.WriteLine("Lets calculate the area of a triangle");
            Console.WriteLine("Enter please the  lenght of side AB");
            double ab = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter please the  lenght of side BC");
            double bc = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter please the  lenght of side CA");
            double ca = double.Parse(Console.ReadLine());

            double p = (ab + bc + ca) / 2;
            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));
            Console.WriteLine($"Square ot the triangle equals {square}");
        }
        static void DateTimeIntro()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine(now.ToString());

            Console.WriteLine($"It's {now.Date}, {now.Hour}:{now.Minute}");

            DateTime dt = new DateTime(2016, 2, 28);
            DateTime newdt = dt.AddDays(1);
            Console.WriteLine(newdt);

            TimeSpan ts = now - dt;
            Console.WriteLine(ts.TotalMinutes);
            ts = now.Subtract(dt);
            Console.WriteLine(ts.TotalMinutes);
        }

        static void IntroToArrays()
        {
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];
            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };
            int[] a4 = { 1, 3, 4, 5, 9, 7 };

            Console.WriteLine(a4[0]);
            int number = a4[4];

            Console.WriteLine(number);

            a4[4] = 6;
            Console.WriteLine(a4[4]);

            Console.WriteLine(a4.Length);
            Console.WriteLine(a4[a4.Length - 1]);

            string s1 = "dsvfsfvfc";
            char first = s1[0];
            char last = s1[s1.Length - 1];

            Console.WriteLine($"First: {first}. Last: {last}");

            // s1[0] = 'z'; - impossible 
        }
        static void MathDemo()
        {
            long o = Math.BigMul(8000, 90000);
            Console.WriteLine(o);
            Console.WriteLine(Math.Pow(2, 3));
            Console.WriteLine(Math.Sqrt(9));
            Console.WriteLine(Math.Round(1.8));
            Console.WriteLine(Math.Round(1.3));

            Console.WriteLine(Math.Round(1.5));

            Console.WriteLine(Math.Round(2.5, MidpointRounding.AwayFromZero));
            Console.WriteLine(Math.Round(2.5, MidpointRounding.ToEven));
        }
        static void CastingAndParsing()
        {
                byte b = 3; //0000 0011
                int i = b; // 0000 0000 0000 0000 0000 0000 0000 0011
                long l = i;// 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0000 0011

                float f = i; //3.0

                Console.WriteLine(f);

                b = (byte)i;
                Console.WriteLine(b);

                i = (int)f;
                Console.WriteLine(i);

                string str = "1";
                // i = (int)str;
                i = int.Parse(str);
                Console.WriteLine($"Parsed i = {i}");

                int x = 5;
                int result = x / 2; //2
                Console.WriteLine(result);

                double result1 = x / 2; //2
                double result2 = (double)x / 2; //2.5 
                Console.WriteLine(result2);
        }
        static void ConsoleBasics()
        {
            Console.WriteLine("Hi, please tell me your name");

            string name = Console.ReadLine();
            string sentence = $"Your name is {name}";
            Console.WriteLine(sentence);

            Console.WriteLine("Tell me please your age.");
            string input = Console.ReadLine();
            int age = int.Parse(input);
            sentence = $"Your age is {age}";
            Console.WriteLine(sentence);

            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            Console.Write("New Style");
            Console.Write("New Style\n");
        }

        static void ComparingStrings()
        {
            string str1 = "abcde";
            string str2 = "abcde";

            bool areEqual = str1 == str2;
            Console.WriteLine(areEqual);

            areEqual = string.Equals(str1, str2, StringComparison.Ordinal);
            Console.WriteLine(areEqual);

            string s1 = "Strasse";
            string s2 = "Straße";

            areEqual = string.Equals(s1, s2, StringComparison.Ordinal);
            Console.WriteLine(areEqual);

            areEqual = string.Equals(s1, s2, StringComparison.InvariantCulture);
            Console.WriteLine(areEqual);

            areEqual = string.Equals(s1, s2, StringComparison.CurrentCulture);
            Console.WriteLine(areEqual);
        }

        static void StringFormat()
        {
            string name = "John";
            string age = "30";
            string str1 = $"My name is {name} and I'm {age}"; //интерпалирование строк 
            string str2 = string.Format("My name is {0} and I'm {1}", name, age);
            Console.WriteLine(str1);
            Console.WriteLine(str2);

            string str3 = "My name is \r\nJohn."; //перенос на новую строку 
            Console.WriteLine(str3);

            string str4 = "I'm \t 30";// добавление табуляции 
            Console.WriteLine(str4);

            str3 = $"My name is {Environment.NewLine}John."; // так лучше указывать новую строку на разных ОС
            Console.WriteLine(str3);

            string str5 = "I'm John and I'm a \"good programmer\"";
            Console.WriteLine(str5);

            string str6 = "C:\tmp\test\test_file.txt"; //компилятор воспринимает это как табуляцию 

            string str7 = "C:\\tmp\\test\\test_file.txt"; //решение это добавить еще слэшь 
            string str8 = @"C:\tmp\test\test_file.txt"; //или решение это поставь символ @ перед строкой  

            int answer = 42;
            string result = string.Format("{0:d}", answer);
            string result2 = string.Format("{0:d4}", answer);
            Console.WriteLine(result);
            Console.WriteLine(result2);

            result = string.Format("{0:f}", answer);
            result2 = string.Format("{0:f4}", answer);
            Console.WriteLine(result);
            Console.WriteLine(result2);

            double answer1 = 42.08;
            result2 = string.Format("{0:f1}", answer1); //округление 
            Console.WriteLine(result2);

            Console.OutputEncoding = Encoding.UTF8;
            double money = 12.8;
            result = string.Format("{0:C}", money);
            result2 = string.Format("{0:C2}", money);

            Console.WriteLine(result);
            Console.WriteLine(result2);
            Console.WriteLine(money.ToString("C2"));
            result = $"{money:C2}";

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");

            Console.WriteLine(money.ToString("C2"));
        }

        static void StringBuilderDemo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("My ");
            sb.Append("name ");
            sb.Append("is ");
            sb.Append("John");
            sb.AppendLine("!");
            sb.AppendLine("Hello!");

            string str = sb.ToString();
            Console.WriteLine(str);
        }

        static void StringModification()
        {
            string nameConcat = string.Concat("My ", "name ", " is", " John");
            Console.WriteLine(nameConcat);

            nameConcat = string.Join(" ", "My", "name", "is", "John");
            Console.WriteLine(nameConcat);

            nameConcat = "My " + "name " + "is " + "John ";

            nameConcat = nameConcat.Insert(0, "By the way, ");
            Console.WriteLine(nameConcat);

            nameConcat = nameConcat.Remove(0, 1);

            Console.WriteLine(nameConcat);

            string replaced = nameConcat.Replace('n', 'z');
            Console.WriteLine(replaced);

            string data = "12;28;34;25;64";

            string[] splitData = data.Split(';');
            string first = splitData[0];
            Console.WriteLine(first);
            //Console.WriteLine(splitData.ToString());

            char[] chars = nameConcat.ToCharArray();
            Console.WriteLine(chars[0]);
            Console.WriteLine(nameConcat[0]);

            string lower = nameConcat.ToLower();
            Console.WriteLine(lower);

            string upper = nameConcat.ToUpper();
            Console.WriteLine(upper);

            string john = " My name is John ";
            Console.WriteLine(john.Trim());
        }
        static void StringEmptiness()
        {
            string str = string.Empty; // same as ""
            string empty = "";
            string whiteSpaced = " ";
            string notEmpty = " b";
            string nullString = null;

            Console.WriteLine("IsNullOrEmpty");
            //nullString.Contains('a');
            bool isNullOrEmpty = string.IsNullOrEmpty(nullString);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(whiteSpaced);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(notEmpty);
            Console.WriteLine(isNullOrEmpty);

            isNullOrEmpty = string.IsNullOrEmpty(empty);
            Console.WriteLine(isNullOrEmpty);

            Console.WriteLine("IsNullOrWhiteSpac");

            bool isNullOrWhiteSpace = string.IsNullOrWhiteSpace(nullString);
            Console.WriteLine(isNullOrWhiteSpace);

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(whiteSpaced);
            Console.WriteLine(isNullOrWhiteSpace);

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(notEmpty);
            Console.WriteLine(isNullOrWhiteSpace);

            isNullOrWhiteSpace = string.IsNullOrWhiteSpace(empty);
            Console.WriteLine(isNullOrWhiteSpace);
        }

        static void QueryingStrings()
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a');
            bool containsE = name.Contains('E');

            Console.WriteLine(containsA);
            Console.WriteLine(containsE);

            bool endsWithAbra = name.EndsWith("abra");
            Console.WriteLine(endsWithAbra);

            bool startWithAbra = name.StartsWith("abra");
            Console.WriteLine(startWithAbra);

            int indexOfA = name.IndexOf('a', 1);
            Console.WriteLine(indexOfA);

            int lastIndexOfR = name.LastIndexOf('r');
            Console.WriteLine(lastIndexOfR);

            Console.WriteLine(name.Length);

            string substrFrom5 = name.Substring(5);
            string substringFromTo = name.Substring(0, 3);

            Console.WriteLine(substrFrom5);
            Console.WriteLine(substringFromTo);
        }

        static void StaticAndInstanceMembers()
        {
            string name = "abracadabra";
            bool containsA = name.Contains('a');
            bool containsB = name.Contains("b");

            Console.WriteLine(containsA);
            Console.WriteLine(containsB);

            string abc = string.Concat("a", "b", "c");
            Console.WriteLine(abc);

            Console.WriteLine(int.MinValue);

            int i = 1;
            string xStr = i.ToString();
            Console.WriteLine(xStr);
            Console.WriteLine(i);
        }
        static void MathOperations()
        {
            int b = 3 * 2;
            int c = 5 / 2;
            Console.WriteLine(b);
            Console.WriteLine(c);

            int a = 4 % 2;
            b = 5 % 2;
            Console.WriteLine(a);
            Console.WriteLine(b);

            a = 3;
            a = a * a;
            //a=a*a*a;
            Console.WriteLine(a);

            a = 2 + 2 * 2;
            Console.WriteLine(a);

            a *= 2;
            //a = a * 2;
            Console.WriteLine(a);

            a /= 2;
            //a = a / 2;
            Console.WriteLine(a);
        }

        static void IncrementDecrementDemo()
        {
            int x = 1;
            x = x + 1;
            Console.WriteLine(x);

            x++;
            Console.WriteLine(x);

            ++x;
            Console.WriteLine(x);

            x = x - 1;
            x--;
            --x;

            Console.WriteLine(x);
            Console.WriteLine($"Last x state is {x}");

            int j = x++;
            Console.WriteLine(j);
            Console.WriteLine(x);

            x += 2;
            //x=x+2
            Console.WriteLine(x);

            j -= 2;
            //j=j-2
            Console.WriteLine(j);
        }

        static void Variables()
        {
            var x = 3;
            var y = 3.098;
            var i = new Dictionary<int, string>(5);
        }
        static void Overflow()
        {
           checked
            {
                uint x = uint.MaxValue;
                Console.WriteLine(x);
                x = x + 1;
                Console.WriteLine(x);

                x = x - 1;
                Console.WriteLine(x);
            }
        }
    }
}
