using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LogService
{

    public class Logger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Service was called at {0}.", DateTime.Now);
        }
    }
}
