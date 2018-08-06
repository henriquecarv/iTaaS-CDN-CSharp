using iTaaS.Interfaces;
using iTaaS.Models;
using System;
using System.Collections.Generic;

namespace iTaaS.Helpers
{
    public class MINHACDNParser
    {
        public List<MINHACDN> GetLogs(string filepath)
        {
            var normalize = new Normalize();
            var filePath = normalize.GetUri(filepath);

            var io = new IO();
            var streamedFile = io.StreamFile(filepath.ToString());
            var readFile = io.ReadFile(streamedFile);

            var splitLog = new SplitLog();
            var lines = splitLog.ListLogLines(readFile);

            var logs = new List<MINHACDN>();
            foreach (var line in lines)
            {
                var values = splitLog.SplitColumnValues(line);
                MINHACDN log = new MINHACDN
                {
                    CacheStatus = values[2],
                    HTTPMethod = values[3],
                    ProtocolVersion = values[5],
                    ResponseSize = Int16.Parse(values[0]),
                    StatusCode = Int16.Parse(values[1]),
                    TimeTaken = Decimal.Parse(values[6]),
                    UriPath = values[4]
                };
                logs.Add(log);
            }
            return logs;
        }
    }
}