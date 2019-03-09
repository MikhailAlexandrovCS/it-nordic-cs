using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkPartTwo
{
    class Triangle
    {
        private double side;
        public Triangle(double sideValue)
        {
            side = sideValue;
        }

        public double TrianglePerimeter(int numbersAfterComma)
        {
            double result = 3.0 * side;
            if (result - Math.Truncate(result) == 0)
                return result;
            return Math.Round(result, numbersAfterComma);
        }

        public double TrinagleArea(int numbersAfterComma)
        {
            double result = (Math.Pow(side, 3) * Math.Sqrt(3)) / 4;
            if (result - Math.Truncate(result) == 0)
                return result;
            else
                return Math.Round(result, numbersAfterComma);
        }
    }
}
