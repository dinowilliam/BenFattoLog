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
        public DateTime? OccurrencieDate { get; set; }
        public string AccessLog { get; set; }
        public short? HttpRespose { get; set; }
        public int? Port { get; set; }
        public DateTime? AddDate { get; set; }
    }
}
