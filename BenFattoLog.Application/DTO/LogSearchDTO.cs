using System;
using System.Net;
using System.Text.Json.Serialization;

namespace BenFattoLog.Application.DTO {

    using BenFattoLog.Utils.Converters.Json;

    public class LogSearchDTO {
        public LogSearchDTO() { }

        [JsonConverter(typeof(IPAddressConverter))]
        public IPAddress IpAddress { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string UserAgent { get; set; }

    }
}
