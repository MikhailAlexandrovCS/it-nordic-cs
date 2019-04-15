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
            if (typeof(T) == typeof(ConsoleLogWriter))
                return new ConsoleLogWriter();
            else
            {
                if (typeof(T) == typeof(FileLogWriter))
                    return new FileLogWriter(parameters.ToString());
                else
                {
                    if (typeof(T) == typeof(MultipeLogWriter))
                        return new MultipeLogWriter((List<ILogWriter>)parameters);
                }
            }
            return null;
        }
    }
}
