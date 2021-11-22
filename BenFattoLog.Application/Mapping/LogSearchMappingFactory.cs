using Nelibur.ObjectMapper;

namespace BenFattoLog.Application.Mapping {

    using BenFattoLog.Application.DTO;
    using BenFattoLog.Application.Mapping.Contracts;
    using BenFattoLog.DAL.Repositorys.Models;

    internal class LogSearchMappingFactory : ILogSearchMappingFactory {
        public LogSearchDTO ConvertLogSearch(LogSearch logSearch) {

            TinyMapper.Bind<LogSearch, LogSearchDTO>();

            return TinyMapper.Map<LogSearchDTO>(logSearch);

        }

        public LogSearch ConvertLogSearch(LogSearchDTO logSearch){

            TinyMapper.Bind<LogSearchDTO, LogSearch>();

            return TinyMapper.Map<LogSearch>(logSearch);
        }
    }
}
