using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkPartTwo
{
    class Rectangle
    {
        private double height;
        private double width;

        public Rectangle(double heightValue, double widthValue)
        {
            height = heightValue;
            width = widthValue;
        }

        public double RectanglePerimeter(int numbersAfterComma)
        {
            double result = height + width;
            if (result - Math.Truncate(result) == 0)
                return result;
            return Math.Round(result, numbersAfterComma);
        }

        public double RectangleArea(int numbersAfterComma)
        {
            double result = height * width;
            if (result - Math.Truncate(result) == 0)
                return result;
            return Math.Round(result, numbersAfterComma);
        }
    }
}
