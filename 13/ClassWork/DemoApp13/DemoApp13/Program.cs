using System;

namespace DemoApp13
{
	class Program
	{
		static void Main(string[] args)
		{
			Helicopter helicopter = new Helicopter(15, (byte)10);
			helicopter.WriteAllProperties2();

			Plane plane = new Plane(10, (byte)4);
			plane.WriteAllProperties2();
			Console.ReadLine();
		}
	}
}
