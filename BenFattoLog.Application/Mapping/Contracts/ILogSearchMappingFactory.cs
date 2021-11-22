namespace BenFattoLog.Application.Mapping.Contracts {
    
    using BenFattoLog.Application.DTO;
    using BenFattoLog.DAL.Repositorys.Models;

    internal interface ILogSearchMappingFactory   {
    
        LogSearchDTO ConvertLogSearch(LogSearch logSearch);
        LogSearch ConvertLogSearch(LogSearchDTO logSearch);

    }
}
