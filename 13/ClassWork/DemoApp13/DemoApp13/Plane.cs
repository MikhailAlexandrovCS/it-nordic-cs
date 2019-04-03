using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp13
{
	class Plane : AbstractAirCraft, IPlane, IPropertiesWriter
	{
		public byte EnginesCount { get; set; }

		public Plane(int maxHeight, byte enginesCount) : base(maxHeight)
		{
			EnginesCount = enginesCount;
			Console.Write("It's a plane, welcome aboard\n");
		}

		public override void WriteAllProperties()
		{
			Console.Write($"EnginesCount: {EnginesCount}\n");
		}

		public override void WriteAllProperties2()
		{
			Console.Write($"EnginesCount: {EnginesCount}\n");
			base.WriteAllProperties2();
		}
	}
}
