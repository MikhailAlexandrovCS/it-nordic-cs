using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLogWriter
{
    class MultipeLogWriter : AbstractLogWriter
    {
        private List<ILogWriter> _logWriters { get; set; }

        public MultipeLogWriter(List<ILogWriter> logWriters)
        {
            _logWriters = logWriters;
        }

        public override void GetMessage(MessageType messageType, string message)
        {
            foreach (var logger in _logWriters)
                switch (messageType)
                {
                    case MessageType.Error:
                        {
                            logger.LogError(message);
                            break;
                        }
                    case MessageType.Info:
                        {
                            logger.LogInfo(message);
                            break;
                        }
                    case MessageType.Warning:
                        {
                            logger.LogWarning(message);
                            break;
                        }
                }
        }
    }
}
