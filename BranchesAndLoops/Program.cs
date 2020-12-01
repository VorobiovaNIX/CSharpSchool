using System;
using System.Collections.Generic;

namespace BranchesAndLoops
{
    class Program
    {
        static void Main(string[] args)
        {
            int x =5;
            int z =3;

            if(x +z > 10) 
                Console.WriteLine("The answer is greater than 10.");

            else Console.WriteLine("The answer is not greater than 10");


                int a = 5;
                int b = 3;
                int c = 4;
                
                if ((a + b + c > 10) && (a == b))
                {
                    Console.WriteLine("The answer is greater than 10");
                    Console.WriteLine("And the first number is equal to the second");
                }
                else
                    {
                        Console.WriteLine("The answer is not greater than 10");
                        Console.WriteLine("Or the first number is not equal to the second");
                    }
            int counter = 0;
            while (counter < 10)
            {
            Console.WriteLine($"Hello World! The counter is {counter}");
            counter++;
            } 
            int counter1 = 0;

            do
            {
                Console.WriteLine($"Hello World! The counter is {counter1}");
                counter1++;
                } while (counter1 < 10);

            for(int counter2 =0;counter2 <10; counter2++){
                Console.WriteLine($"Hello Loop - {counter2}");
            }

            for (int row = 1; row < 11; row++){
                for (char column = 'a'; column < 'k'; column++)
                {
                    Console.WriteLine($"The cell is ({row}, {column})");
                    }
                }
            
            int sum =0;
            for(int i =1; i <21;i++){
                if (i%3 ==0) sum+=i;
            }
            Console.WriteLine($"The sum is {sum}");


            var names =new List<string>{"<name>","Alenka","Anna"};
            foreach(var name in names){
                Console.WriteLine($"Hello {name.ToUpper()}!");
                }
                names.Add("Maria");
                names.Add("Bill");
                names.Remove("Anna");
                foreach (var name in names)
                {
                    Console.WriteLine($"Hello {name.ToUpper()}!");
                    }

                Console.WriteLine($"My name is {names[0]}.");
                Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");
                Console.WriteLine($"The list has {names.Count} people in it");
                
                var index = names.IndexOf("Alenka");
                if (index != -1)Console.WriteLine($"The name {names[index]} is at index {index}");
                else{
                    var notFound = names.IndexOf("Not Found");
                    Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");
                }

                var fibonacciNumbers = new List<int> {1, 1};
                var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
                var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
                
                fibonacciNumbers.Add(previous + previous2);
                foreach(var item in fibonacciNumbers)
                Console.WriteLine(item);
       
        }           
     }
}