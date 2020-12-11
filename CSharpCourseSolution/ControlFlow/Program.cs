using System;

namespace ControlFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
        static void LoginToTheSystem()
        {
            string password = "qwerty";
            string login = "johndoe";

            int tries = 1;
            while (tries <= 3)
            {
                Console.WriteLine("Please enter login name");
                string loginUser = Console.ReadLine();
                Console.WriteLine("Please enter password name");
                string passwordUser = Console.ReadLine();
                if (login.Equals(loginUser) && password.Equals(passwordUser))
                {
                    Console.WriteLine("Welcome to your account!");
                    break;
                }
                else
                {
                    if (tries == 3) Console.WriteLine("You have exhausted the number of attempts");
                    else Console.WriteLine("Your login or password are wrong. Please try again!");
                    tries++;
                }
            }
        }
        static void FindFactorial()
        {
            Console.WriteLine("Please enter number >= 0");
            int n = int.Parse(Console.ReadLine());

            long factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }
            Console.WriteLine($"Factotial for {n} is {factorial}");
        }
        static void AverageValue()
        {
            int[] numbers = new int[10];
            int inputCount = 0;
            while (inputCount < 10)
            {
                int number = int.Parse(Console.ReadLine());
                numbers[inputCount] = number;

                inputCount++;

                if (number == 0)
                    break;
            }
            int sum = 0;
            int count = 0;

            foreach (var n in numbers)
            {
                if (n > 0 && n % 3 == 0)
                {
                    sum += n;
                    count++;
                }
            }
            double average = (double)sum / count;
            Console.WriteLine(average);
        }

        static double GetDouble()
        {
            return double.Parse(Console.ReadLine());
        }
        static void SwitchCase()
        {

            int month = int.Parse(Console.ReadLine());

            string season = string.Empty;
            switch (month)
            {
                case 1:
                case 2:
                case 12:
                    season = "Winter";
                    break;
                case 3:
                case 4:
                case 5:
                    season = "Spring";
                    break;
                case 6:
                case 7:
                case 8:
                    season = "Summer";
                    break;
                case 9:
                case 10:
                case 11:
                    season = "Autumn";
                    break;

                default:
                    throw new ArgumentException("Unexpected number of month");
            }
            Console.WriteLine(season);
            int weddingYears = int.Parse(Console.ReadLine());
            string name = string.Empty;

            switch (weddingYears)
            {
                case 5:
                    name = "Wood wedding";
                    break;
                case 10:
                    name = "Оловянная wedding";
                    break;
                case 15:
                    name = "Хрустальная wedding";
                    break;
                case 20:
                    name = "Фарфоровая wedding";
                    break;
                case 25:
                    name = "Серебрянная wedding";
                    break;
                case 30:
                    name = "Жемчужная wedding";
                    break;
                default:
                    name = "I don't know such type of wedding";
                    break;
            }
            Console.WriteLine(name);
        }
        static void BreakContinue()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            char[] letters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j' };

            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine($"Number={numbers[i]}");
                for (int j = 0; j < letters.Length; j++)
                {
                    if (numbers[i] == j)
                    {
                        break;
                    }
                    Console.Write($" {letters[j]}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            foreach (int item in numbers)
            {
                //if (item % 2 == 0) Console.WriteLine(item);
                if (item % 2 != 0) continue;
                Console.WriteLine(item);
            }
        }
        static void WhileDoWhile()
        {
            int age = 50;
            while (age < 18)
            {
                Console.WriteLine("First while loop");
                Console.WriteLine("What's your age?");

                age = int.Parse(Console.ReadLine());
            }
            do
            {
                Console.WriteLine("Do// While");
                Console.WriteLine("What's your age?");
                age = int.Parse(Console.ReadLine());
            } while (age < 18);

            int[] numbers = { 1, 2, 3, 4, 5, 6 };
            int i = 0;
            while (i < numbers.Length)
            {
                Console.WriteLine(numbers[i] + " ");
                i++;
            }
        }
        static void NestedFor()
        {
            int[] numbers = { 1, -2, 4, -7, 5, 3, 2, -1, -3, 2, 7, -1, -3, 1, 7 };
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int atI = numbers[i];
                    int atJ = numbers[j];
                    if (atI + atJ == 0)
                    {
                        Console.WriteLine($"Pair ({atI},{atJ}). Indexes ({i},{j})");
                    }

                }

            }
            Console.WriteLine();
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                for (int j = i + 1; j < numbers.Length - 1; j++)
                {
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        int atI = numbers[i];
                        int atJ = numbers[j];
                        int atK = numbers[k];
                        if (atI + atJ + atK == 0)
                        {
                            Console.WriteLine($"Triplets ({atI},{atJ},{atK}). Indexes ({i},{j},{k})");
                        }
                    }
                }
            }
        }
        static void ForForeach()
        { 
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i] + " ");
            }
            Console.WriteLine();
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                Console.WriteLine(numbers[i] + " ");

            }
            Console.WriteLine();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(numbers[i] + " ");

                }
            }
            Console.WriteLine();
            foreach (int val in numbers)
            {
                Console.Write(val + " ");
            }
        }
        static void GetMax()
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            //int max = 0;
            //if (a > b) max = a;
            //else max = b;

            int max = a > b ? a : b;
            Console.WriteLine($"The max number is {max}");
        }
        static void IfElse()
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

            bool isToolLow = bodyMassIndex <= 18.5;
            bool normal = bodyMassIndex > 18.5 && bodyMassIndex < 25;
            bool isAboveNormal = bodyMassIndex >= 25 && bodyMassIndex <= 30;
            bool isTooFat = bodyMassIndex > 30;

            bool isFat = isAboveNormal || isTooFat;

            if (isFat)
            {
                Console.WriteLine("You'd better lose some weight!");
            }
            else
            {
                Console.WriteLine("Oh, you're in a good shape.");
            }

            if (isToolLow)
            {
                Console.WriteLine("Not enough weight.");
            }
            else if (normal)
            {
                Console.WriteLine("You're OK.");
            }
            else if (isAboveNormal)
            {
                Console.WriteLine("Be careful");
            }
            else { Console.WriteLine("You need to lose some weight!"); }

            if (isAboveNormal || isFat)
            {
                Console.WriteLine("Anyway it's time to get on diet");
            }

            string description = age > 18 ? "You can drink alcohol!" : "You should get a bit older"; // ternary operation 

            Console.WriteLine(description);
        }
    }
}
