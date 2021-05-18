using System;
using System.Collections.Generic;
using System.Text;

namespace ListingsApp.Logger
{
    class CliLogger:ILogger
    {
        public void log(string logMsg, bool canWriteToConsole=true)
        {
            if(canWriteToConsole)
                Console.WriteLine(logMsg);
            //This can also write to splunk or any cloud portal
        }
    }
}
