using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    public struct EvilStruct
    {

        public int X;
        public int Y;

        public readonly PointRef PointRef;

        public EvilStruct(int x, int y)
        {
            X = x;
            Y = y;
            this.PointRef = new PointRef(); // readonly field is initialize in constructor 
        }

    }
    public struct PointVal
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X={X}; Y={Y}");
        }
    }

    public class PointRef
    {
        public int X;
        public int Y;

        public void LogValues()
        {
            Console.WriteLine($"X={X}; Y={Y}");
        }
    }
}
