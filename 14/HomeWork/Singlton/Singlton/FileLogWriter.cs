using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Singlton
{
    class FileLogWriter : AbstractLogWriter, IDisposable
    {
        private static FileLogWriter _fileLogWriter;
        private StreamWriter _streamWriter;

        private FileLogWriter()
        {
        }

        public static FileLogWriter GetInstance()
        {
            if (_fileLogWriter == null)
                _fileLogWriter = new FileLogWriter();
            return _fileLogWriter;
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
