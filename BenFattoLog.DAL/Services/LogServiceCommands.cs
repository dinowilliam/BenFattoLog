using System;
using System.Collections.Generic;
using Nelibur.ObjectMapper;

namespace BenFattoLog.DAL.Services {

    using BenFattoLog.DAL.Infra.Contexts;
    using BenFattoLog.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys;
    using BenFattoLog.DAL.Repositorys.Models;
    using BenFattoLog.DAL.Services.Contracts;
    using BenFattoLog.Domain.Entities;    

    public class LogServiceCommands : ILogServiceCommands   {

        private readonly BenFattoLogCommandsContext context;
        
        IRepositoryCommands<LogPersistance> logPersistanceCommands { get; set; }

        public LogServiceCommands(MicroservicesSpikeCommandsContext context) {
            this.context = context;
            this.logPersistanceCommands = new LogRepositoryCommands(this.context);
        }             
        
        public int Save(LogMessage log) {

            TinyMapper.Bind<LogMessage, LogPersistance>();
            var localLog = TinyMapper.Map<LogPersistance>(log);

            if (localLog.Id == Guid.Empty ){
                localLog.Id = Guid.NewGuid();
                return logPersistanceCommands.Insert(localLog);
            }
            else {
                return logPersistanceCommands.Update(localLog);
            }
            
        }

        public int AddRange(List<LogMessage> logs) {

            TinyMapper.Bind<List<LogMessage>, List<LogPersistance>>();
            var listLog = TinyMapper.Map<List<LogPersistance>>(logs);

            return logPersistanceCommands.AddRange(listLog);
        }
        
        public int Delete(LogMessage log) {
            
            int deleteReturn;            

            try {
                TinyMapper.Bind<LogMessage, LogPersistance>();
                var localLog = TinyMapper.Map<LogPersistance>(log);
                logPersistanceCommands.Delete(localLog);
                deleteReturn = 0;
            }
            catch (Exception) {
                deleteReturn = 1;
            }

            return deleteReturn;
        }
        

    }
}