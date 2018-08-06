using Business.Models;
using Util;
using System;
using Xunit;
using System.Collections.Generic;

namespace iTaaS.Tests
{
    public class iTaaSUnitTest
    {

				private List<MINHACDNLog> getLogs(){
					var mINHACDNParser = new MINHACDNParser();
					var logs = mINHACDNParser.ParseLogs("https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt");
					return logs;
				}

        [Fact]
        public void IsLogBeingParsed(){					
					Assert.NotEmpty(getLogs());
				}
    }
}
