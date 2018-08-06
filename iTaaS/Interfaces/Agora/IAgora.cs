using System;

namespace iTaaS.Interfaces
{
    public interface IAgora : IBase
    {
        DateTime Date { get; set; }
        string Provider { get; }
        int TimeTaken { get; set; }
    }
}