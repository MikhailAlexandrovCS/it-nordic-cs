using System;
using System.Collections.Generic;
using System.Text;

namespace GenericLogWriter
{
    class LogWriterFactory
    {
        private static LogWriterFactory _logWriterFactory;

        public static LogWriterFactory GetInstance()
        {
            if (_logWriterFactory == null)
                _logWriterFactory = new LogWriterFactory();
            return _logWriterFactory;
        }

        public ILogWriter GetLogWriter<T> (object parameters) where T : ILogWriter
        {
            return (ILogWriter)parameters;
        }
    }
}
