using System;
using System.Collections.Generic;

namespace BenFattoLog.DAL.Services {

    using BenFattoLog.DAL.Infra.Contexts;
    using BenFattoLog.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys;
    using BenFattoLog.DAL.Repositorys.Models;
    using BenFattoLog.DAL.Services.Contracts;

    public class LogServiceQueries : ILogServiceQueries   {

        private readonly BenFattoLogQueriesContext context;

        public LogServiceQueries(BenFattoLogQueriesContext context) {
            this.context = context;
            this.logPersistanceQueries = new LogRepositoryQueries(this.context);
        }

        IRepositoryQueries<LogPersistance> logPersistanceQueries { get; set; }
                
        public IEnumerable<LogPersistance> GetAll() {
                                  
            return logPersistanceQueries.List();
        }

        public LogPersistance GetById(Guid id) {
            
            return logPersistanceQueries.Get(id);
        }

        public IEnumerable<LogPersistance> LogFilter(LogSearch logSearch) {            
            
            return logPersistanceQueries.Where(m => m.IpAddress.Equals(logSearch.IpAddress) && m.OccurrenceeDate >= logSearch.InitialDate && m.OccurrenceeDate <= logSearch.FinalDate && m.AccessLog.Contains(logSearch.UserAgent)); ;
        }

    }
}