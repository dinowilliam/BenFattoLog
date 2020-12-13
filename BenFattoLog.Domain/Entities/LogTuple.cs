using System;
using System.Net;

namespace BenFattoLog.Domain.Entities {
    public class LogTuple {
        public LogTuple(IPAddress ip, DateTime occurrencee, string accesslog, short httpresponse, int port) {
            IpAddress = ip;
            OccurrenceeDate = occurrencee;
            AccessLog = accesslog;
            HttpResponse = httpresponse;
            Port = port;
        }

        public LogTuple() {
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
        public DateTime? AddDate { get; set; }
    }
}
