using System;
using System.Collections.Generic;
using System.Text;

namespace FileWritingModule
{
    abstract class AbstractLogWriter : ILogWriter
    {
        abstract public void LogError(string message);
        abstract public void LogInfo(string message);
        abstract public void LogWarning(string message);
    }
}
