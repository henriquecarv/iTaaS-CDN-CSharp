using Business.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Util
{
    public class MINHACDNParser
    {
        public List<MINHACDNLog> ParseLogs(string filepath)
        {
            var filePath = GetUri(filepath);
            var streamedFile = StreamFile(filepath.ToString());
            var readFile = ReadFile(streamedFile);
            var splittedLogs = SplitLogs(readFile);

            return EncapsulateLogs(splittedLogs);
        }

        private string CleanLogs(string file)
        {
            return file.Replace("\"", "").Replace(" ", "|");
        }

        private List<MINHACDNLog> EncapsulateLogs(List<string> lines)
        {
            var logs = new List<MINHACDNLog>();
            foreach (var line in lines)
            {
                var elements = SplitElements(line);
                MINHACDNLog log = new MINHACDNLog
                {
                    CacheStatus = elements[2],
                    HTTPMethod = elements[3],
                    ProtocolVersion = elements[5],
                    ResponseSize = Int16.Parse(elements[0]),
                    StatusCode = Int16.Parse(elements[1]),
                    TimeTaken = Decimal.Parse(elements[6]),
                    UriPath = elements[4]
                };
                logs.Add(log);
            }
            return logs;
        }

        private Uri GetUri(string uri)
        {
            try
            {
                return new Uri(uri);
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (UriFormatException)
            {
                throw;
            }
        }

        private string ReadFile(Stream file)
        {
            try
            {
                using (var stream = new MemoryStream())
                {
                    byte[] buffer = new byte[2048];
                    int bytesRead;
                    while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }
                    byte[] result = stream.ToArray();
                    return Encoding.UTF8.GetString(result, 0, result.Length - 1);
                }
            }
            catch (DecoderFallbackException)
            {
                throw;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (NotSupportedException)
            {
                throw;
            }
            catch (ObjectDisposedException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        private List<string> SplitElements(string line)
        {
            var elements = line.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            var fields = new List<string>();
            foreach (var element in elements)
            {
                fields.Add(element);
            }
            return fields;
        }

        private List<string> SplitLogs(string file)
        {
            var logLines = new List<string>();
            file = CleanLogs(file);
            string[] lines = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines)
            {
                logLines.Add(line);
            }
            return logLines;
        }

        private Stream StreamFile(string file)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    Stream stream = client.OpenRead(file);
                    return stream;
                }
            }
            catch (WebException)
            {
                throw;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}