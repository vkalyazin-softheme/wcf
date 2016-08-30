using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace CalcService
{
    [ServiceContract]
    public interface ICalc
    {
        [OperationContract]
        [WebGet]
        string Add(string a, string b);
    }
}
