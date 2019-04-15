using System;
using System.Collections.Generic;
using System.Text;

namespace Singlton
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        private static ConsoleLogWriter _consoleLogWriter;

        private ConsoleLogWriter() { }

        public static ConsoleLogWriter GetInstance()
        {
            if (_consoleLogWriter == null)
                _consoleLogWriter = new ConsoleLogWriter();
            return _consoleLogWriter;
        }

        public override void GetMessage(MessageType messageType, string message)
        {
            Console.Write(DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss+0000") + "\t" + messageType.ToString() + "\t" + message + "\n");
        }
    }
}
