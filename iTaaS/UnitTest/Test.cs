using System;
using System.Collections.Generic;
using iTaaS.Helpers;
using iTaaS.Models;
using Xunit;

namespace Test
{
    public class Test
    {
        private List<MINHACDN> getLogs()
        {
            var sourceURI = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var mINHACDNParser = new MINHACDNParser();
            var logs = mINHACDNParser.GetLogs(sourceURI);
            return logs;
        }

        [Fact]
        public void IsLogBeingParsed()
        {
            Assert.NotEmpty(getLogs());
        }
    }
}
