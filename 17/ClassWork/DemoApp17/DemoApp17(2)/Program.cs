using System;
using System.IO;
using System.IO.Compression;

namespace DemoApp17_2_
{
	class Program
	{
		static void Main(string[] args)
		{
			RandomDataGenerator randomDataGenerator = new RandomDataGenerator();
			randomDataGenerator.RandomDataGenerated += RandomDataGenerator_RandomDataGenerated;
			randomDataGenerator.GeneratedComplete += RandomDataGenerator_GeneratedComplete;
			string result = Convert.ToBase64String(randomDataGenerator.GetRandomData(10000, 1000));
			Console.WriteLine(result);

			using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(@"C:\Users\User\Desktop\test.bin")))
			{
				if (binaryWriter != null)
				{
					binaryWriter.Write(result);
					binaryWriter.Flush();
				}
			}

			ZipFile.CreateFromDirectory(@"C:\Users\User\Desktop\testZIP", @"C:\Users\User\Desktop\testZIP.zip");
			Console.ReadLine();
		}

		private static void RandomDataGenerator_GeneratedComplete(object sender, RandomDataEventArgs e)
		{
			Console.WriteLine("Work DONE!");
		}

		private static void RandomDataGenerator_RandomDataGenerated(object sender, RandomDataEventArgs e)
		{
			Console.WriteLine($"Generated: {e.bytesDone} from {e.totalBytes} bytes");
		}
	}
}
