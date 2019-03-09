using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkPartTwo
{
    class Circle
    {
        private double diameter;
        public Circle(double diameterValue)
        {
            diameter = diameterValue;
        }

        public double CirclePerimeter(int numbersAfterComma)
        {
            double result = 2.0 * Math.PI * (diameter / 2.0); ;
            if (result - Math.Truncate(result) == 0)
                return result;
            return Math.Round(result, numbersAfterComma);
        }

        public double CircleArea(int numbersAfterComma)
        {
            double result = (Math.PI / 4.0) * diameter;
            if (result - Math.Truncate(result) == 0)
                return result;
            return Math.Round(result, numbersAfterComma); 
        }
    }
}
