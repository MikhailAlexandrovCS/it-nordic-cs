using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileWritingModule
{
    class FileLogWriter : AbstractLogWriter
    {
        private string _pathToFile { get; set; }

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
            using (StreamWriter streamWriter = new StreamWriter(_pathToFile, true))
            {
                streamWriter.Write($"{message}\n");
            }
        }
    }
}
