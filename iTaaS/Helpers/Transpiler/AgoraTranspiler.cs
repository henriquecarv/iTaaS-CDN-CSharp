using iTaaS.Models;
using System;
using System.Collections.Generic;

namespace iTaaS.Helpers
{
    public class AgoraTranspiler
    {
        private decimal appVersion = 0;

        public void TranspileMINHACDN<T>(List<MINHACDN> mINHACDNLogs, string targetPath)
        {
            var version = new Version();
            this.appVersion = version.GetAssemblyVersion<T>(appVersion);
            var agoraLogs = GetAgoraList(mINHACDNLogs);
            var newfile = CreateAgoraData(agoraLogs);
            var io = new IO();
            io.SaveFile(newfile, targetPath);
        }

        private string CreateAgoraData(List<Agora> agoraLogs)
        {
            var currentTime = DateTime.UtcNow.ToString("dd/MM/yyyy H:mm:ss");

            string file = $"#Version: {appVersion}\n";
            file += $"#Date: {currentTime}\n";
            file += "#Fields: provider http-method status-code uri-path time-taken response-size cache-status\n";

            foreach (var log in agoraLogs)
            {
                var line = $"{log.Provider}\t{log.HTTPMethod}\t{log.StatusCode}\t{log.UriPath}\t{log.TimeTaken}\t{log.ResponseSize}\t{log.CacheStatus}\n";
                file += line;
            }

            return file;
        }

        private List<Agora> GetAgoraList(List<MINHACDN> mINHACDNLogs)
        {
            var agoraLogs = new List<Agora>();
            foreach (var log in mINHACDNLogs)
            {
                var agora = new Agora
                {
                    CacheStatus = log.CacheStatus,
                    HTTPMethod = log.HTTPMethod,
                    ProtocolVersion = log.ProtocolVersion,
                    ResponseSize = log.ResponseSize,
                    StatusCode = log.StatusCode,
                    TimeTaken = (int)log.TimeTaken,
                    UriPath = log.UriPath
                };
                agoraLogs.Add(agora);
            }
            return agoraLogs;
        }
    }
}