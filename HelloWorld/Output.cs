using System;

namespace HelloWorld
{
    class Output
    {
        public static void output()
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("\nWhat is your name? ");
var name = Console.ReadLine();
var date = DateTime.Now;
Console.WriteLine($"\nHello, {name}, on {date:d} at {date:t}!");

string firstFriend = "Maria";
string secondFriend = "Sage";
Console.WriteLine($"My friends are {firstFriend} and {secondFriend}");

Console.WriteLine($"The name {firstFriend} has {firstFriend.ToUpper()} letters.");
Console.WriteLine($"The name {secondFriend} has {secondFriend.Split()} letters.");

string songLyrics = "You say goodbye, and I say hello";
Console.WriteLine(songLyrics.Contains("goodbye"));
Console.WriteLine(songLyrics.Contains("greetings"));

Console.Write("\nPress any key to exit...");
Console.ReadKey(true);
        }
    }
}
