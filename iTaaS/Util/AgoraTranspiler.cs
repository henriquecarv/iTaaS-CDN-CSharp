using Business.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Util
{
    public class AgoraTranspiler
    {
        private decimal appVersion = 0;

        public void SetAppVersion<T>()
        {
            try
            {
                var version = typeof(T).Assembly.GetName().Version;
                var stringVersion = $"{version.Major}.{version.Minor}";
                appVersion = Decimal.Parse(stringVersion);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (FormatException)
            {
                throw;
            }
            catch (OverflowException)
            {
                throw;
            }
        }

        public void TranspileMINHACDN(List<MINHACDNLog> mINHACDNLogs, string targetPath)
        {
            var agoraLogs = EncapsulateLogs(mINHACDNLogs);
            var newfile = CreateFile(agoraLogs);
            SaveFile(newfile, targetPath);
        }

        private string CreateFile(List<AgoraLog> agoraLogs)
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

        private List<AgoraLog> EncapsulateLogs(List<MINHACDNLog> mINHACDNLogs)
        {
            var agoraLogs = new List<AgoraLog>();
            foreach (var log in mINHACDNLogs)
            {
                var agora = new AgoraLog
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

        private void SaveFile(string file, string outPath)
        {
            try
            {
                var folderPath = Path.GetDirectoryName(outPath).ToString();
                Directory.CreateDirectory(folderPath);
                var filename = Path.GetFileName(outPath);
                var fullPath = Path.Combine(folderPath, filename);
                using (StreamWriter sw = new StreamWriter(File.Open(fullPath, FileMode.Create)))
                {
                    sw.Write(file);
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw;
            }
            catch (PathTooLongException)
            {
                throw;
            }
            catch (FileNotFoundException)
            {
                throw;
            }
            catch (NotSupportedException)
            {
                throw;
            }
            catch (DirectoryNotFoundException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (ArgumentOutOfRangeException)
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
    }
}