using System;
using System.Collections.Generic;

namespace BenFattoLog.DAL.Services.Contracts {

    using BenFattoLog.Domain.Entities;

    public interface ILogServiceQueries    {        
        public IEnumerable<LogMessage> GetAll();
        public LogMessage GetById(Guid id);
        public IEnumerable<LogMessage> LogFilter(LogSearch logSearch);
    }
}
