using System;
using System.Collections.Generic;
using Nelibur.ObjectMapper;

namespace BenFattoLog.DAL.Services {

    using BenFattoLog.DAL.Infra.Contexts;
    using MicroservBenFattoLogicesSpike.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys;
    using BenFattoLog.DAL.Repositorys.Models;
    using BenFattoLog.DAL.Services.Contracts;
    using BenFattoLog.Domain.Entities;    

    public class LogServiceQueries : ILogServiceQueries   {

        private readonly BenFattoLogQueriesContext context;

        public LogServiceQueries(MicroservicesSpikeQueriesContext context) {
            this.context = context;
            this.logPersistanceQueries = new LogRepositoryQueries(this.context);
        }

        IRepositoryQueries<LogPersistance> logPersistanceQueries { get; set; }
                
        public IEnumerable<LogMessage> GetAll() {

            var localListLog = logPersistanceQueries.List();

            TinyMapper.Bind<List<LogPersistance>, List<LogMessage>>(); 
            var listLog = TinyMapper.Map<List<LogMessage>>(localListLog);
            
            return listLog;
        }

        public LogMessage GetById(Guid id) {

            var localLog = logPersistanceQueries.Get(id);

            TinyMapper.Bind<LogPersistance, LogMessage>();
            var log = TinyMapper.Map<LogMessage>(localLog);

            return log;
        }

        public IEnumerable<LogMessage> LogFilter(LogSearch logSearch) {

            var localListLog = logPersistanceQueries.Where(m => m.Title.Equals(logSearch.Title) && m.OccurrenceeDate >= logSearch.InitialDate && m.OccurrenceeDate <= logSearch.FinalDate && m.Description.Contains(logSearch.Description));

            var listLog = TinyMapper.Map<List<LogMessage>>(localListLog);
            
            return listLog;
        }

    }
}