using Business.Interface;

namespace Business.Models
{
    public class MINHACDNLog : IMINHACDNLog
    {
        public MINHACDNLog()
        {
        }

        private string cacheStatus;
        private string hTTPMethod;
        private string protocolVersion;
        private int responseSize;
        private int statusCode;
        private decimal timeTaken;
        private string uriPath;

        public string CacheStatus { get => cacheStatus; set => cacheStatus = value; }
        public string HTTPMethod { get => hTTPMethod; set => hTTPMethod = value; }
        public string ProtocolVersion { get => protocolVersion; set => protocolVersion = value; }
        public int ResponseSize { get => responseSize; set => responseSize = value; }
        public int StatusCode { get => statusCode; set => statusCode = value; }
        public decimal TimeTaken { get => timeTaken; set => timeTaken = value; }
        public string UriPath { get => uriPath; set => uriPath = value; }
    }
}