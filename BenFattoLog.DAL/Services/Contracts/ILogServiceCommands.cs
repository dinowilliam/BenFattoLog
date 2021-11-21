using System.Collections.Generic;

namespace BenFattoLog.DAL.Services.Contracts {

    using BenFattoLog.DAL.Repositorys.Models;

    public interface ILogServiceCommands  {
        public int Save(LogPersistance log);        
        public int Delete(LogPersistance log);
        public int AddRange(List<LogPersistance> logs);
    }
}
