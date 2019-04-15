using System;

namespace Calculator.Operation
{
	public class CircleInformater
	{
		public static double CirclePerimeter(double radius)
		{
			return 2.0 * Math.PI * radius;
		}

		public static double CircleArea(double radius)
		{
			return Math.PI * Math.Pow(radius, 2);
		}
	}
}
