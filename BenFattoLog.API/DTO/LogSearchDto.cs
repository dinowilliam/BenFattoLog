using BenFattoLog.API.Converters.Json;
using System;
using System.Net;
using System.Text.Json.Serialization;

namespace BenFattoLog.API.DTO {
    public class LogSearchDto {

        [JsonConverter(typeof(IPAddressConverter))]
        public IPAddress IpAddress { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string UserAgent { get; set; }
    }
}