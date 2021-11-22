using System.Collections.Generic;

namespace BenFattoLog.Application.Mapping.Contracts {

    using BenFattoLog.Application.DTO;
    using BenFattoLog.DAL.Repositorys.Models;

    internal interface ILogMappingFactory {
        LogDTO ConvertLog(LogPersistance log);
        LogPersistance ConvertLog(LogDTO log);
        List<LogDTO> ConvertLog(List<LogPersistance> listLog);
        List<LogPersistance> ConvertLog(List<LogDTO> listLog);
        IEnumerable<LogDTO> ConvertLog(IEnumerable<LogPersistance> listLog);
        IEnumerable<LogPersistance> ConvertLog(IEnumerable<LogDTO> listLog);

    }
}
