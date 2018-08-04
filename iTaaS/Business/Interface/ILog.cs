namespace Business.Interface
{
    internal interface ILog
    {
        string CacheStatus { get; set; }
        string HTTPMethod { get; set; }
        string ProtocolVersion { get; set; }
        int ResponseSize { get; set; }
        int StatusCode { get; set; }
        string UriPath { get; set; }
    }
}