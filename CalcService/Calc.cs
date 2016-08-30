using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
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
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress("http://localhost/Logger");

            _loggerChannelFactory = new ChannelFactory<ILogger>(binding, endpoint);
        }

        public int Add(int a, int b)
        {
            var client = _loggerChannelFactory.CreateChannel();

            client.Log();

            return a + b;
        }
    }
}
