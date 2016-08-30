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

        private readonly ILogger _client;

        public Calc()
        {
            //var binding = new WebHttpBinding();
            //var endpoint = new EndpointAddress("http://localhost/Logger.svc");

            //_loggerChannelFactory = new ChannelFactory<ILogger>(binding, endpoint);
            //_loggerChannelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
        }

        public string Add(string a, string b)
        {
            //var client = _loggerChannelFactory.CreateChannel();

            //client.Log();

            try
            {
                var intA = Convert.ToInt32(a);
                var intB = Convert.ToInt32(b);

                Console.WriteLine("Success.");

                return (intA + intB).ToString();
            }
            catch (Exception ex)
            {
                return string.Format("Error: {0}", ex);
            }
        }
    }
}
