using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singlton
{
    class FileLogWriter : AbstractLogWriter
    {
        private static string _pathToFile { get; set; }
        private static FileLogWriter _fileLogWriter;

        private FileLogWriter(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        public static FileLogWriter GetInstance(string _pathToFile)
        {
            if (_fileLogWriter == null)
                _fileLogWriter = new FileLogWriter(_pathToFile);
            return _fileLogWriter;
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
