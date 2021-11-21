namespace BenFattoLog.DAL.Repositorys {
    
    using BenFattoLog.DAL.Infra;
    using BenFattoLog.DAL.Infra.Contexts;
    using BenFattoLog.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys.Models;

    public class LogRepositoryCommands : BaseRepositoryCommands<LogPersistance, BenFattoLogCommandsContext>, IRepositoryCommands<LogPersistance>
    {
        public LogRepositoryCommands(BenFattoLogCommandsContext dataContext) : base(dataContext) {
        }
    }

}
