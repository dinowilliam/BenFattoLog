using Nelibur.ObjectMapper;
using System.Collections.Generic;

namespace BenFattoLog.Application.Mapping {

    using BenFattoLog.Application.DTO;
    using BenFattoLog.Application.Mapping.Contracts;
    using BenFattoLog.DAL.Repositorys.Models;

    internal class LogMappingFactory : ILogMappingFactory     {

        public LogDTO ConvertLog(LogPersistance log) {

            TinyMapper.Bind<LogPersistance, LogDTO>();

            return TinyMapper.Map<LogDTO>(log);
        }

        public LogPersistance ConvertLog(LogDTO log) {

            TinyMapper.Bind<LogDTO, LogPersistance>();

            return TinyMapper.Map<LogPersistance>(log);
        }

        public List<LogDTO> ConvertLog(List<LogPersistance> listLog) {

            TinyMapper.Bind<List<LogPersistance>, List<LogDTO>>();
            
            return TinyMapper.Map<List<LogDTO>>(listLog);
        }

        public List<LogPersistance> ConvertLog(List<LogDTO> listLog) {

            TinyMapper.Bind<List<LogDTO>, List<LogPersistance>>();

            return TinyMapper.Map<List<LogPersistance>>(listLog);
            
        }

        public IEnumerable<LogDTO> ConvertLog(IEnumerable<LogPersistance> listLog){

            TinyMapper.Bind<IEnumerable<LogPersistance>, IEnumerable<LogDTO>>();

            return TinyMapper.Map<IEnumerable<LogDTO>>(listLog);
        }

        public IEnumerable<LogPersistance> ConvertLog(IEnumerable<LogDTO> listLog) {

            TinyMapper.Bind<IEnumerable<LogDTO>, IEnumerable<LogPersistance>>();

            return TinyMapper.Map<IEnumerable<LogPersistance>>(listLog);

        }
    }
}
