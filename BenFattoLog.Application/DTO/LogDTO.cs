using System;
using System.Net;
using System.Text.Json.Serialization;

namespace BenFattoLog.Application.DTO {
    
    using BenFattoLog.Utils.Converters.Json;

    public class LogDTO {
        
        public Guid? Id { get; set; }
        [JsonConverter(typeof(IPAddressConverter))]
        public IPAddress IpAddress { get; set; }
        public DateTime? OccurrenceeDate { get; set; }
        public string AccessLog { get; set; }
        public short? HttpResponse { get; set; }
        public int? Port { get; set; }

    }
}
