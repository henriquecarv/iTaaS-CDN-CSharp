using System;
using Util;

namespace ConsoleLog
{
    class Program
    {
        static void Main(string[] args)
        {
            var sourceURI = "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt";
            var targetPath = "./../../output/";

            var mINHACDNParser = new MINHACDNParser();
            var mINHACDNLogs = mINHACDNParser.ParseLogs(sourceURI);

            var agoraTranspiler = new AgoraTranspiler();
            agoraTranspiler.TranspileMINHACDN(mINHACDNLogs, targetPath);

            Console.ReadKey();
        }
    }
}
