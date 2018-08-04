using System;

namespace Business.Interface
{
    internal interface IAgoraLog : ILog
    {
        DateTime Date { get; set; }
        string Provider { get; }
        int TimeTaken { get; set; }
        double Version { get; set; }
    }
}