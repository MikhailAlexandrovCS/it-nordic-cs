using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Events
{
    class FileWriterWithProgress
    {
        public event EventHandler<WriteDataEventArgs> DataWriting;
        public event EventHandler<WriteDataDoneEventArgs> DataWritingDone;

        public void WriteBytes(string fileName, byte[] data, float percentageToFireEvent)
        {
            using (StreamWriter streamWriter = new StreamWriter(File.Create(fileName)))
            {
                if (streamWriter != null)
                    for (int i = 0; i < data.Length; i++)
                    {
                        streamWriter.Write(data[i]);
                        if (((i + 1) * 100 / data.Length) % (percentageToFireEvent * 100) == 0)
                            WritingPerfomed(
                                this,
                                new WriteDataEventArgs
                                {
                                    CurrentPercentageCount = (i + 1) * 100 / data.Length
                                });
                    }
                streamWriter.Close();
                WritingCompleted(
                    this,
                    new WriteDataDoneEventArgs
                    {
                        GetFileText = File.ReadAllText(fileName)
                    });
            }
        }

        protected virtual void WritingPerfomed(object sender, WriteDataEventArgs e)
        {
            DataWriting?.Invoke(sender, e);
        }

        protected virtual void WritingCompleted(object sender, WriteDataDoneEventArgs e)
        {
            DataWritingDone?.Invoke(sender, e);
        }
    }
}
