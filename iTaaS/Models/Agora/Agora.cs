using iTaaS.Interfaces;
using System;

namespace iTaaS.Models
{
    public class Agora : IAgora
    {
        private string hTTPMethod;
        public Agora()
        {
        }

        public string CacheStatus { get; set; }
        public DateTime Date { get; set; }
        public string HTTPMethod { get => hTTPMethod; set => hTTPMethod = value.Length == 3 ? value + " " : value; }
        public string ProtocolVersion { get; set; }
        public string Provider
        {
            get
            {
                return "\"MINHA CDN\"";
            }
        }
        public int ResponseSize { get; set; }
        public int StatusCode { get; set; }
        public int TimeTaken { get; set; }
        public string UriPath { get; set; }
    }
}