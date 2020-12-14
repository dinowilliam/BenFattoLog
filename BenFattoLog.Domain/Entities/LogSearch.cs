using System;
using System.Collections.Generic;
using System.Net;

namespace BenFattoLog.Domain.Entities {
    public class LogSearch {

        public LogSearch() { }

        public IPAddress IpAddress { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string UserAgent { get; set; }

    }
}
