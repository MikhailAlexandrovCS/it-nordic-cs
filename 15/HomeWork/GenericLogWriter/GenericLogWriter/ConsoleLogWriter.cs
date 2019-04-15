using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLogWriter
{
    class ConsoleLogWriter : AbstractLogWriter
    {
        public override void GetMessage(MessageType messageType, string message)
        {
            Console.Write(DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss+0000") + "\t" + messageType.ToString() + "\t" + message + "\n");
        }
    }
}
