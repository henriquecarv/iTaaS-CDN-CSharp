using Business.Interface;
using System;

namespace Business.Models
{
    public class AgoraLog : IAgoraLog
    {
        private string cacheStatus;

        private DateTime date;

        private string hTTPMethod;

        private string protocolVersion;

        private int responseSize;

        private int statusCode;

        private int timeTaken;

        private string uriPath;

        private double version;

        public AgoraLog()
        {
        }

        public string CacheStatus { get => cacheStatus; set => cacheStatus = value; }

        public DateTime Date { get => date; set => date = value; }

        public string HTTPMethod { get => hTTPMethod; set => hTTPMethod = value.Length == 3 ? value + " " : value; }
        public string ProtocolVersion { get => protocolVersion; set => protocolVersion = value; }

        public string Provider
        {
            get
            {
                return "\"MINHA CDN\"";
            }
        }

        public int ResponseSize { get => responseSize; set => responseSize = value; }
        public int StatusCode { get => statusCode; set => statusCode = value; }
        public int TimeTaken { get => timeTaken; set => timeTaken = value; }
        public string UriPath { get => uriPath; set => uriPath = value; }
        public double Version { get => version; set => version = value; }
    }
}