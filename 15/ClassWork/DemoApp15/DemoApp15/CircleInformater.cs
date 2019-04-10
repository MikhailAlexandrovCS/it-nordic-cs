using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp15
{
	class CircleInformater
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
