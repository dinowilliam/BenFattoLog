using System;
using System.Collections.Generic;

namespace BenFattoLog.Application.Contracts {
    
    using BenFattoLog.Domain.Entities;

    public interface ILogApplication {
        public int Save(LogMessage log);                
        public int Delete(Guid id);
        public IEnumerable<LogMessage> GetAll();
        public LogMessage GetById(Guid id);
        public IEnumerable<LogMessage> LogFilter(LogSearch logSearch);
        public int Upload(byte[] file);
        public DateTime ParseDateTimeLinq(string dateToParse);        
    }
}
