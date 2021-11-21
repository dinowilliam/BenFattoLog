using System;
using System.Net;

namespace BenFattoLog.Domain.Entities {

    using BenFattoLog.Domain.Entities.Contracts;

    public class Log : ILog {
        public Log(IPAddress ip, DateTime occurrencee, string accesslog, short httpresponse, int port) {
            IpAddress = ip;
            OccurrenceeDate = occurrencee;
            AccessLog = accesslog;
            HttpResponse = httpresponse;
            Port = port;
        }

        public Log() {
        }

        public void Update(IPAddress ip, DateTime occurrencee, string accesslog, short httpresponse, int port) {
            IpAddress = ip;
            OccurrenceeDate = occurrencee;
            AccessLog = accesslog;
            HttpResponse = httpresponse;
            Port = port;
        }

        public Guid Id { get; set; }
        public IPAddress IpAddress { get; set; }
        public DateTime? OccurrenceeDate { get; set; }
        public string AccessLog { get; set; }
        public short? HttpResponse { get; set; }
        public int? Port { get; set; }
    }
}
