using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp17_2_
{
	//public delegate void RandomDataGeneratedHandler(int bytesDone, int totalBytes);

	class RandomDataGenerator
	{
		public event EventHandler<RandomDataEventArgs> RandomDataGenerated;
		public event EventHandler GeneratedComplete;

		public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
		{
			byte[] info = new byte[dataSize];
			for (int i = 0; i < info.Length; i++)
			{
				info[i] = (byte)new Random().Next(256);
				if ((i + 1) % bytesDoneToRaiseEvent == 0)
					OnWorkPerfomed(this, new RandomDataEventArgs
					{
						bytesDone = i + 1,
						totalBytes = dataSize
					}
				);
			}
			OnWorkCompleted(this, RandomDataEventArgs.Empty);
			return info;
		}

		protected virtual void OnWorkPerfomed(object sender, RandomDataEventArgs e)
		{
			RandomDataGenerated?.Invoke(sender, e);
		}

		protected virtual void OnWorkCompleted(object sender, RandomDataEventArgs e)
		{
			GeneratedComplete?.Invoke(sender, e);
		}
	}
}
