using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{

    public struct EvilStruct
    {

        public int X;
        public int Y;

        public PointRef PointRef;

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
