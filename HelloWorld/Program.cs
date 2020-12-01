using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
int a = 5;
int b = 4;
int c = 2;
int d = (a + b) * c;
Console.WriteLine(d);
Console.WriteLine(c);

int max = int.MaxValue;
int min = int.MinValue;
Console.WriteLine($"The range of integers is {min} to {max}");

int what = max + 3;
Console.WriteLine($"An example of overflow: {what}");

        }
    }
}
