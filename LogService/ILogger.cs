﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LogService
{
    [ServiceContract]
    public interface ILogger
    {
        [OperationContract]
        void Log();
    }
}
