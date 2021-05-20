using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Logger
{
    interface ILogger
    {
        public void log(string logMsg, bool canWriteToConsole);
    }
}
