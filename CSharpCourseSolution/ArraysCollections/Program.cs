﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysCollections
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(RomanNumeral.Parse("XIV"));
        }
        static void CustomIndexBasedArrays()
        {
            Array myArray = Array.CreateInstance(typeof(int), new[] { 4 }, new[] { 1 });
            myArray.SetValue(2019, 1);
            myArray.SetValue(2020, 2);
            myArray.SetValue(2021, 3);
            myArray.SetValue(2022, 4);

            Console.WriteLine($"Starting index: {myArray.GetLowerBound(0)}");
            Console.WriteLine($"Ending index: {myArray.GetUpperBound(0)}");

            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");

            }
            Console.WriteLine();
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"{myArray.GetValue(i)} at index {i}");
            }
        }

        static void JaggedArray()
        {

            int[][] jaggedArray = new int[4][];
            jaggedArray[0] = new int[1];
            jaggedArray[1] = new int[3];
            jaggedArray[2] = new int[2];
            jaggedArray[3] = new int[4];

            Console.WriteLine("Enter the number for a jagged array.");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    string st = Console.ReadLine();
                    jaggedArray[i][j] = int.Parse(st);

                }
            }
            Console.WriteLine();
            Console.WriteLine("Printing the Elements ");

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write(jaggedArray[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void MultiArrays()
        {
            int[,] r1 = new int[2, 3] { { 1, 2, 3, }, { 4, 5, 6 } };
            int[,] r2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            for (int i = 0; i < r2.GetLength(0); i++)
            {
                for (int j = 0; j < r2.GetLength(1); j++)
                {
                    Console.Write($"{r2[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        static void StackQueue()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine($"Should print out 4: {stack.Peek()}");

            stack.Pop(); //remove the last one 
            Console.WriteLine($"Should print out 3: {stack.Peek()}");

            Console.WriteLine("Iterate over the stack.");

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();

            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine($"Should print out 1: {queue.Peek()}");

            queue.Dequeue(); // remove the first one 

            Console.WriteLine($"Should print out 2: {queue.Peek()}");

            Console.WriteLine("Iterate over the queue.");

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
        static void DictionaryDemo()
        {
            var people = new Dictionary<int, string>();
            people.Add(1, "John");
            people.Add(2, "Alice");
            people.Add(3, "Bob");


            people = new Dictionary<int, string>()
            {
                { 1, "John" },
                { 2, "Alice"},
                {3, "Bob" }
            };


            string name = people[1];
            Console.WriteLine(name);

            Console.WriteLine("Iterating over values");
            Dictionary<int, string>.KeyCollection keys = people.Keys; //initialization 
            foreach (var item in keys)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Iterating over values");
            var values = people.Values;
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Iterating over key-value pairs ");
            foreach (var pair in people)
            {
                Console.WriteLine($"Key: {pair.Key}. Value: {pair.Value}");
            }
            Console.WriteLine();

            Console.WriteLine($"Count={people.Count}");

            bool containsKey = people.ContainsKey(2); // works much faster than serching by Value - ContainsValue method
            bool containsValue = people.ContainsValue("John");
            Console.WriteLine($"Contains key: {containsKey}. Contains value: {containsValue}");

            people.Remove(1);
            people.TryAdd(2, "Ellias"); //try to add new name by key - 2 (already existing value); if it's not successfull, method returns false

            if (people.TryAdd(2, "Ellias"))
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Failed to add using key 2");
            }

            if (people.TryGetValue(2, out string val))
            {
                Console.WriteLine($"Key 2, Val ={val}");
            }
            else
            {
                Console.WriteLine("Failed to get ");
            }

            people.Clear();

        }

        static void ListDemo()
        {
            var intList = new List<int>() { 1, 4, 2, 7, 5, 9, 12 };
            intList.Add(7);

            int[] intArray = { 1, 2, 3 };
            intList.AddRange(intArray);

            foreach (var item in intList)
            {
                Console.WriteLine(item);
            }

            if (intList.Remove(1)) //remove the first occurence 
            {
                //do
            }
            intList.RemoveAt(0);
            intList.Reverse();
            bool contains = intList.Contains(3);

            int min = intList.Min();
            int max = intList.Max();
            Console.WriteLine($"Min = {min} and Max = {max}");

            int indexOf = intList.IndexOf(2);
            int lastIndexOf = intList.LastIndexOf(2);

            Console.WriteLine($"IndexOf2 = {indexOf}. LastIndexOf2 = {lastIndexOf}");

            for (int i = 0; i < intList.Count; i++)
            {
                Console.Write($"{intList[i]} ");
            }
            Console.WriteLine();
            foreach (var item in intList)
            {
                Console.Write(item);
            }
        }

        static void ArrayType()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int index = Array.BinarySearch(numbers, 7);
            Console.WriteLine(index);

            int[] copy = new int[10];
            Array.Copy(numbers, copy, numbers.Length);

            int[] anotherCopy = new int[10];
            copy.CopyTo(anotherCopy, 0);

            Array.Reverse(copy);
            foreach (var item in copy)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Array.Sort(copy);
            foreach (var item in copy)
            {
                Console.WriteLine(item);
            }
            Array.Clear(copy, 0, copy.Length);
            int[] a1;
            a1 = new int[10];

            int[] a2 = new int[5];
            int[] a3 = new int[5] { 1, 3, -2, 5, 10 };
            int[] a4 = { 1, 3, 2, 4, 6 };

            Array myArray = new int[5];
            Array myArray2 = Array.CreateInstance(typeof(int), 5); // the same array as previos one
            myArray2.SetValue(12, 0);

            Console.WriteLine(myArray2.GetValue(0));

        }
    }
}
