using MicroservicesSpike.DAL.Infra;
using MicroservicesSpike.DAL.Infra.Contexts;
using MicroservicesSpike.DAL.Infra.Contracts;
using MicroservicesSpike.DAL.Repositorys.Models;

namespace MicroservicesSpike.DAL.Repositorys {
    public class LogRepositoryQueries : BaseRepositoryQueries<LogPersistance, MicroservicesSpikeQueriesContext>, IRepositoryQueries<LogPersistance>
    {
        public LogRepositoryQueries(MicroservicesSpikeQueriesContext dataContext) : base(dataContext) {
        }
    }

}
