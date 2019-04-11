using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileWritingModule
{
    class FileLogWriter : AbstractLogWriter, IDisposable
    {
        private string _pathToFile { get; set; }
        private StreamWriter _streamWriter;

        public FileLogWriter(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public override void LogError(string message)
        {
            WriteMessageInFile(message);
        }

        public override void LogInfo(string message)
        {
            WriteMessageInFile(message);
        }

        public override void LogWarning(string message)
        {
            WriteMessageInFile(message);
        }

        private void WriteMessageInFile(string message)
        {
            using (_streamWriter = new StreamWriter(_pathToFile, true))
            {
                _streamWriter.Write($"{message}\n");
            }
        }

        void IDisposable.Dispose()
        {
            if (_streamWriter != null)
                _streamWriter.Dispose();
        }
    }
}
