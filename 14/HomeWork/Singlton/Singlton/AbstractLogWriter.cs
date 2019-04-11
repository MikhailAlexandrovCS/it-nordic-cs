using System;
using System.Collections.Generic;
using System.Text;

namespace Singlton
{
    abstract class AbstractLogWriter : ILogWriter
    {
        abstract public void LogError(string message);
        abstract public void LogInfo(string message);
        abstract public void LogWarning(string message);
    }
}
