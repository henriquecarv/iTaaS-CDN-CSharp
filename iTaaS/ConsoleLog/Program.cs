using System;
using Util;

namespace ConsoleLog
{
    internal class Program
    {
        static void Main(string[] args)
        {
						var sourceURI = args[0];
						var targetPath = args[1];

            // sourceURI = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            // targetPath = "./../output/test.txt";

            var mINHACDNParser = new MINHACDNParser();
            var mINHACDNLogs = mINHACDNParser.ParseLogs(sourceURI);

            var agoraTranspiler = new AgoraTranspiler();
						agoraTranspiler.SetAppVersion<Program>();
            agoraTranspiler.TranspileMINHACDN(mINHACDNLogs, targetPath);

            Console.WriteLine("Log finished transpiling");
        }
    }
}
