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
