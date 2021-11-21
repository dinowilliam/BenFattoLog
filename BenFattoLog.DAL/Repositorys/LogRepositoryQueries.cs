namespace BenFattoLog.DAL.Repositorys {

    using BenFattoLog.DAL.Infra;
    using BenFattoLog.DAL.Infra.Contexts;
    using BenFattoLog.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys.Models;

    public class LogRepositoryQueries : BaseRepositoryQueries<LogPersistance, BenFattoLogQueriesContext>, IRepositoryQueries<LogPersistance>
    {
        public LogRepositoryQueries(BenFattoLogQueriesContext dataContext) : base(dataContext) {
        }
    }

}
