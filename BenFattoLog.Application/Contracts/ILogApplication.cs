using System;
using System.Collections.Generic;

namespace BenFattoLog.Application.Contracts {
    
    using BenFattoLog.Application.DTO;
    
    public interface ILogApplication {
        public int Save(LogDTO log);                
        public int Delete(Guid id);
        public IEnumerable<LogDTO> GetAll();
        public LogDTO GetById(Guid id);
        public IEnumerable<LogDTO> LogFilter(LogSearchDTO logSearch);
        public int Upload(byte[] file);
        public DateTime ParseDateTimeLinq(string dateToParse);        
    }
}
