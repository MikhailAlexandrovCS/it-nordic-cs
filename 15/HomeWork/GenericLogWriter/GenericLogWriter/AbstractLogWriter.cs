using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLogWriter
{
    abstract class AbstractLogWriter : ILogWriter
    {
        public void LogError(string message)
        {
            GetMessage(MessageType.Error, message);
        }

        public void LogInfo(string message)
        {
            GetMessage(MessageType.Info, message);
        }

        public void LogWarning(string message)
        {
            GetMessage(MessageType.Warning, message);
        }

        public abstract void GetMessage(MessageType messageType, string message);
    }
}
