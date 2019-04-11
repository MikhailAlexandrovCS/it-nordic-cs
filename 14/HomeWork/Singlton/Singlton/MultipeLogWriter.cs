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

        public static MultipeLogWriter GetInstance()
        {
            if (_multipeLogWriter == null)
                _multipeLogWriter = new MultipeLogWriter(_logWriters);
            return _multipeLogWriter;
        }

        public override void LogError(string message)
        {
            foreach (var logger in _logWriters)
                logger.LogError(message);
        }

        public override void LogInfo(string message)
        {
            foreach (var logger in _logWriters)
                logger.LogError(message);
        }

        public override void LogWarning(string message)
        {
            foreach (var logger in _logWriters)
                logger.LogError(message);
        }
    }
}
