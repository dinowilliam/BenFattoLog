using BenFattoLog.DAL.Infra;
using BenFattoLog.DAL.Infra.Contracts;
using BenFattoLog.DAL.Repositorys.Models;

namespace BenFattoLog.DAL.Repositorys {
    public class LogRepository : BaseRepository<Log, BenFattoLogContext>, IRepository<Log>
    {
        public LogRepository(BenFattoLogContext dataContext) : base(dataContext) {
        }
    }

}
