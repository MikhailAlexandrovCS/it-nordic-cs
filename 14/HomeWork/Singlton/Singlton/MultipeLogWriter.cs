using System;
using System.Collections.Generic;
using System.Text;

namespace Singlton
{
    class MultipeLogWriter : AbstractLogWriter
    {
        private static List<ILogWriter> _logWriters { get; set; }
        private static MultipeLogWriter _multipeLogWriter;

        private MultipeLogWriter(List<ILogWriter> logWriters)
        {
            _logWriters = logWriters;
        }

        public static MultipeLogWriter GetInstance(List<ILogWriter> _logWriters)
        {
            if (_multipeLogWriter == null)
                _multipeLogWriter = new MultipeLogWriter(_logWriters);
            return _multipeLogWriter;
        }

        public override void GetMessage(MessageType messageType, string message)
        {
            foreach(var logger in _logWriters)
                switch(messageType)
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
