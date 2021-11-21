using System.Collections.Generic;

namespace BenFattoLog.DAL.Services.Contracts
{
    public interface ILogServiceCommands  {
        public int Save(LogMessage log);        
        public int Delete(LogMessage log);
        public int AddRange(List<LogMessage> logs);
    }
}
