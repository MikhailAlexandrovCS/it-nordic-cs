using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp17_2_
{
	//public delegate void RandomDataGeneratedHandler(int bytesDone, int totalBytes);

	class RandomDataGenerator
	{
		public event EventHandler<RandomDataEventArgs> RandomDataGenerated;
		public event EventHandler<RandomDataGenerationDoneEventArgs> GeneratedComplete;

		public byte[] GetRandomData(int dataSize, int bytesDoneToRaiseEvent)
		{
			byte[] info = new byte[dataSize];
			for (int i = 0; i < info.Length; i++)
			{
				info[i] = (byte)new Random().Next(256);
				if ((i + 1) % bytesDoneToRaiseEvent == 0)
					OnWorkPerfomed(this, new RandomDataEventArgs
					{
						BytesDone = i + 1,
						TotalBytes = dataSize
					}
				);
			}
            OnWorkCompleted(
                this,
                new RandomDataGenerationDoneEventArgs { RandomData = info });
			return info;
		}

		protected virtual void OnWorkPerfomed(object sender, RandomDataEventArgs e)
		{
			RandomDataGenerated?.Invoke(sender, e);
		}

		protected virtual void OnWorkCompleted(object sender, RandomDataGenerationDoneEventArgs e)
		{
			GeneratedComplete?.Invoke(sender, e);
		}
	}
}
