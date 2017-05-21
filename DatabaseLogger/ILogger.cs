using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLogger
{
    public interface ILogger
    {
        bool DoLog(string logType, string logMessage);
    }
}
