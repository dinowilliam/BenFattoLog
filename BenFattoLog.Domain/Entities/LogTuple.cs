using System;
using System.Net;

namespace BenFattoLog.Domain.Entities {
    public class LogTuple {
        public LogTuple(IPAddress ip, DateTime occurrence, string accesslog, int httpresponse, int port) {
            Ip = ip;
            Occurrence = occurrence;
            AccessLog = accesslog;
            HttPResponse = httpresponse;
            Port = port;
        }

        public LogTuple() {
        }

        public void Update(IPAddress ip, DateTime occurrence, string accesslog, int httpresponse, int port) {
            Ip = ip;
            Occurrence = occurrence;
            AccessLog = accesslog;
            HttPResponse = httpresponse;
            Port = port;
        }

        public IPAddress Ip { get; set; }
        public DateTime Occurrence { get; set; }
        public string AccessLog { get; set; }
        public string HttpMethod { get; set; }
        public string HttpProtocol { get; set; }
        public string Addresss { get; set;}
        public int HttPResponse { get; set; }
        public int? Port { get; set; }
    }
}
