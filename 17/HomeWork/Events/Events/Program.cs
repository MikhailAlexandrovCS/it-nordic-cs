using System;
using System.Text;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            FileWriterWithProgress fileWriterWithProgress = new FileWriterWithProgress();
            fileWriterWithProgress.DataWriting += FileWriterWithProgress_DataWriting;
            fileWriterWithProgress.DataWritingDone += FileWriterWithProgress_DataWritingDone;
            fileWriterWithProgress.WriteBytes(@"F:\testF.txt", GetDataByte(), 0.15f);
            Console.ReadLine();
        }

        private const int _dataSize = 20;

        private static void FileWriterWithProgress_DataWritingDone(object sender, WriteDataDoneEventArgs e)
        {
            Console.Write(e.GetFileText);
        }

        private static void FileWriterWithProgress_DataWriting(object sender, WriteDataEventArgs e)
        {
            Console.WriteLine($"{e.CurrentPercentageCount} of 100 % written...");
        }

        private static byte[] GetDataByte()
        {
            byte[] data = new byte[_dataSize];
            for (int i = 0; i < data.Length; i++)
                data[i] = (byte)new Random().Next(256);
            return data;
        }
    }
}
