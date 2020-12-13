using BenFattoLog.DAL.Infra.Contracts;
using System;
using System.Collections.Generic;
using System.Net;

#nullable disable

namespace BenFattoLog.DAL.Repositorys.Models
{
    public partial class Log : IEntity {
        public Guid Id { get; set; }
        public IPAddress IpAddress { get; set; }
        public DateTime? OccurrenceeDate { get; set; }
        public string AccessLog { get; set; }
        public short? HttpResponse { get; set; }
        public int? Port { get; set; }
    }
}
