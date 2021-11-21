using System;
using System.Collections.Generic;
using Nelibur.ObjectMapper;

namespace BenFattoLog.DAL.Services {

    using BenFattoLog.DAL.Infra.Contexts;
    using BenFattoLog.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys;
    using BenFattoLog.DAL.Repositorys.Models;
    using BenFattoLog.DAL.Services.Contracts;

    public class LogServiceCommands : ILogServiceCommands   {

        private readonly BenFattoLogCommandsContext context;
        
        IRepositoryCommands<LogPersistance> logPersistanceCommands { get; set; }

        public LogServiceCommands(BenFattoLogCommandsContext context) {
            this.context = context;
            this.logPersistanceCommands = new LogRepositoryCommands(this.context);
        }             
        
        public int Save(LogPersistance log) {            

            if (log.Id == Guid.Empty ){
                log.Id = Guid.NewGuid();
                return logPersistanceCommands.Insert(log);
            }
            else {
                return logPersistanceCommands.Update(log);
            }
            
        }

        public int AddRange(List<LogPersistance> logs) {
            

            return logPersistanceCommands.AddRange(logs);
        }
        
        public int Delete(LogPersistance log) {
            
            int deleteReturn;            

            try {                
                logPersistanceCommands.Delete(log);
                deleteReturn = 0;
            }
            catch (Exception) {
                deleteReturn = 1;
            }

            return deleteReturn;
        }
        

    }
}