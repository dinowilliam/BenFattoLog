using System;
using System.Collections.Generic;

namespace BenFattoLog.DAL.Services.Contracts {

    using BenFattoLog.DAL.Repositorys.Models;

    public interface ILogServiceQueries    {        
        public IEnumerable<LogPersistance> GetAll();
        public LogPersistance GetById(Guid id);
        public IEnumerable<LogPersistance> LogFilter(LogSearch logSearch);
    }
}
