using System;
using System.Net;

namespace BenFattoLog.DAL.Repositorys.Models {
    public class LogSearch {
        public LogSearch() { }        
        public IPAddress IpAddress { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public string UserAgent { get; set; }

    }
}
