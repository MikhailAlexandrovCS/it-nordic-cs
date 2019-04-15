using System;

namespace Calculator.Figure
{
	public class Figure
	{
		private double _radius;

		public Figure(double radius)
		{
			_radius = radius;
		}

		public double Calculate(Func<double, double> operation)
		{
			return operation(_radius);
		}
	}
}
