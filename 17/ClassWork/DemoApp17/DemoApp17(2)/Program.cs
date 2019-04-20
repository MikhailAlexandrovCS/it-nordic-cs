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
            randomDataGenerator.RandomDataGenerated += RandomDataGenerator_RandomDataGenerated1;
            randomDataGenerator.GeneratedComplete += RandomDataGenerator_GeneratedComplete;
            string result = Convert.ToBase64String(randomDataGenerator.GetRandomData(30, 5));
            Console.WriteLine(result);

            using (BinaryWriter binaryWriter = new BinaryWriter(File.Create(@"F:\test.bin")))
            {
                if (binaryWriter != null)
                {
                    binaryWriter.Write(result);
                    binaryWriter.Flush();
                }
            }

            ZipFile.CreateFromDirectory(@"F:\Users\User\Desktop\testZIP", @"C:\Users\User\Desktop\testZIP.zip");
            Console.ReadLine();
		}

        private static void RandomDataGenerator_GeneratedComplete(object sender, RandomDataGenerationDoneEventArgs e)
        {
            Console.WriteLine(Convert.ToBase64String(e.RandomData));
        }

        private static void RandomDataGenerator_RandomDataGenerated1(object sender, RandomDataEventArgs e)
        {
            Console.WriteLine($"Generated {e.BytesDone} from {e.TotalBytes} byte(s)...");
        }
	}
}
