using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp13
{
	public abstract class AbstractAirCraft : IFlyingObject, IPropertiesWriter
	{
		public int MaxHeight { get; set; }
		public int CurrentHeight { get; set; }

		public AbstractAirCraft(int maxHeight)
		{
			MaxHeight = maxHeight;
			CurrentHeight = 00;
		}

		public void TakeUpper(int delta)
		{
			if (delta <= 0)
				throw new ArgumentOutOfRangeException();
			if (CurrentHeight + delta > MaxHeight)
				CurrentHeight = MaxHeight;
			else
				CurrentHeight += delta;

		}

		public void TakeLower(int delta)
		{
			if (delta <= 0)
				throw new ArgumentOutOfRangeException();
			if (CurrentHeight - delta > 0)
				CurrentHeight -= delta;
			if (CurrentHeight - delta == 0)
				CurrentHeight = 0;
			if (CurrentHeight - delta < 0)
				throw new InvalidOperationException("Crash!");
		}

		public abstract void WriteAllProperties();

		public virtual void WriteAllProperties2()
		{
			Console.Write($"MaxHeigth: {MaxHeight}\n" +
				$"CurrentHeight: {CurrentHeight}");
		}
	}
}
