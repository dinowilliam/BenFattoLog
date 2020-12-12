using System;
using System.Net;

namespace BenFattoLog.API.DTO
{
    public class LogTupleDTO
    {
        public Guid Id { get; set; }
        public IPAddress IpAddress { get; set; }
        public DateTime OccurrenceeDate { get; set; }
        public string AccessLog { get; set; }
        public string HttpMethod { get; set; }
        public string HttpProtocol { get; set; }
        public string Addresss { get; set; }
        public short? HttpResponse { get; set; }
        public int? Port { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
