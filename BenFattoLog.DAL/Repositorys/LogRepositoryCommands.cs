using MicroservicesSpike.DAL.Infra;
using MicroservicesSpike.DAL.Infra.Contexts;
using MicroservicesSpike.DAL.Infra.Contracts;
using MicroservicesSpike.DAL.Repositorys.Models;

namespace MicroservicesSpike.DAL.Repositorys {
    public class LogRepositoryCommands : BaseRepositoryCommands<LogPersistance, MicroservicesSpikeCommandsContext>, IRepositoryCommands<LogPersistance>
    {
        public LogRepositoryCommands(MicroservicesSpikeCommandsContext dataContext) : base(dataContext) {
        }
    }

}
