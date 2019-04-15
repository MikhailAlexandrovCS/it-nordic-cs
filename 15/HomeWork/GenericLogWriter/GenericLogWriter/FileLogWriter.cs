using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenericLogWriter
{
    class FileLogWriter : AbstractLogWriter, IDisposable
    {
        private string _pathToFile { get; set; }
        private StreamWriter _streamWriter;

        public FileLogWriter(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public override void GetMessage(MessageType messageType, string message)
        {
            _streamWriter = new StreamWriter(@"F:\testF.txt", true);
            if (_streamWriter != null)
                _streamWriter.Write(DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss+0000") + "\t" + messageType.ToString() + "\t" + message + "\n");
            _streamWriter.Close();
        }

        public void Dispose()
        {
            if (_streamWriter != null)
                ((IDisposable)_streamWriter).Dispose();
        }
    }
}
