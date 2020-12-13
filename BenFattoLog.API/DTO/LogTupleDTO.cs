using BenFattoLog.API.Converters.Json;
using System;
using System.Net;
using System.Text.Json.Serialization;

namespace BenFattoLog.API.DTO
{
    public class LogTupleDto
    {
        public Guid Id { get; set; }
        [JsonConverter(typeof(IPAddressConverter))]
        public IPAddress IpAddress { get; set; }
        public DateTime? OccurrenceeDate { get; set; }
        public string AccessLog { get; set; }
        public short? HttpResponse { get; set; }
        public int? Port { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
