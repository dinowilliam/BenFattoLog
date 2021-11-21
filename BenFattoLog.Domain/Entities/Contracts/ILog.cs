using System;
using System.Net;

namespace BenFattoLog.Domain.Entities.Contracts {
    public interface ILog {
        Guid Id { get; set; }
        IPAddress IpAddress { get; set; }
        DateTime? OccurrenceeDate { get; set; }
        string AccessLog { get; set; }
        short? HttpResponse { get; set; }
        int? Port { get; set; }
    }
}
