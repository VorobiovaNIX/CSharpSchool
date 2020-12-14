using System;
using System.Collections.Generic;
using System.Text;

namespace OOP
{
    public class Calculator
    {
        public bool TryDivide(double divisible, double divisor, out double result) //out-parametr should be the last one in signature  (like params for example)
        {
            result = 0; // it's essential to assign some value to result 
            if (divisor==0)
            {
                return false;
            }
            result = divisible / divisor;
            return true;
        }
        public double Average(int[] numbers)
        {
            int sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }
            return (double)sum / numbers.Length;
        }

        public double Average2(params int[] numbers)
        {
            int sum = 0;
            foreach (var item in numbers)
            {
                sum += item;
            }
            return (double)sum / numbers.Length;
        }
        public double CalcTriangleSquare(double ab, double bc, double ca)
        {
            double p = (ab + bc + ca) / 2;
            double square = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ca));

            Console.WriteLine($"Square ot the triangle equals {square}");
            return square;
        }

        public double CalcTriangleSquare(double b, double h)
        {
            Console.WriteLine($"Square ot the triangle equals {0.5 * b * h}");
            return 0.5 * b * h;
        }

        public double CalcTriangleSquare(double ab, double bc, int alpha, bool isInRadians = false)
        {
            if (isInRadians)
            {
                return 0.5 * ab * bc * Math.Sin(alpha);
            }
            else
            {
                double rads = alpha * Math.PI / 180;
                return 0.5 * ab * bc * Math.Sin(rads);
            }
        }

        public double CalcTriangleSquare(double ab, double bc, int alpha)
        {
            double rads = alpha * Math.PI / 180;
            return 0.5 * ab * bc * Math.Sin(rads);

        }
    }
}
