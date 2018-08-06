using System;
using System.Collections.Generic;

namespace iTaaS.Helpers
{
    internal class SplitLog
    {

        public List<string> SplitColumnValues(string line)
        {
            var values = line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var fields = new List<string>();
            foreach (var value in values)
            {
                fields.Add(value);
            }
            return fields;
        }

        public List<string> ListLogLines(string file)
        {
            var logLines = new List<string>();
						var normalize = new Normalize();
            file = normalize.GetNewFormat(file);
            string[] lines = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                logLines.Add(line);
            }
            return logLines;
        }
    }
}