using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using LogService;

namespace CalcService
{
    public class Calc : ICalc
    {
        private readonly ChannelFactory<ILogger> _loggerChannelFactory;

        public Calc()
        {
            _loggerChannelFactory = new ChannelFactory<ILogger>(new WebHttpBinding(), "http://localhost/Logger");
            _loggerChannelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
        }

        public string Add(string a, string b)
        {
            try
            {
                var client = _loggerChannelFactory.CreateChannel();

                client.Log("From other service.");

                var intA = Convert.ToInt32(a);
                var intB = Convert.ToInt32(b);

                Console.WriteLine("Service was called at {0}.", DateTime.Now);

                return (intA + intB).ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return string.Format("Error: {0}", ex);
            }
        }
    }
}
