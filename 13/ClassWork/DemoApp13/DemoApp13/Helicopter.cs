using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp13
{
	internal class Helicopter : AbstractAirCraft, IHelicopter, IPropertiesWriter
	{
		public byte BladesCount { get; private set; }

		public Helicopter(int maxHeigth, byte bladesCount) : base(maxHeigth)
		{
			BladesCount = bladesCount;
			Console.Write("It's a helicopter, welcome aboard\n");
		}

		public override void WriteAllProperties()
		{
			Console.Write($"BladesCount: {BladesCount}\n");
		}

		public override void WriteAllProperties2()
		{
			Console.Write($"BladesCount: {BladesCount}\n");
			base.WriteAllProperties2();
		}
	}
}
