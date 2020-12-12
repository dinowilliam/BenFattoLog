using System;
using System.Collections.Generic;
using System.Linq;

namespace BenFattoLog.DAL.Services {
    using BenFattoLog.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys;
    using BenFattoLog.DAL.Repositorys.Models;
    using BenFattoLog.Domain.Entities;
    using Nelibur.ObjectMapper;

    public class LogService {

        IRepository<Log> RepLog { get; set; }

        public LogService() {
            this.RepLog = new LogRepository();
        }

        public int Save(LogTuple log) {

            TinyMapper.Bind <LogTuple, Log> ();
            Log localUser = TinyMapper.Map<Log>(log);

            return RepLog.Insert(localUser);
        }

        public int Update(LogTuple log) {

            TinyMapper.Bind<LogTuple, Log>();
            var localUser = TinyMapper.Map<Log>(log);

            return RepLog.Update(localUser);
        }

        public int Delete(Guid id) {
            int deleteReturn;

            var localUser = RepLog.Get(id);

            try {
                RepLog.Delete(localUser);
                deleteReturn = 0;
            }
            catch(Exception) {
                deleteReturn = 1;
            }

            return deleteReturn;
        }

        public IEnumerable<LogTuple> GetAll() {

            var localListUsers = RepLog.List();

            TinyMapper.Bind<LogTuple, Log>();
            var listlUsers = TinyMapper.Map<List<LogTuple>>(localListUsers);

            return listlUsers;
        }

        public LogTuple GetById(Guid id) {

            var localUser = RepLog.Get(id);

            TinyMapper.Bind<LogTuple, Log>();
            var user = TinyMapper.Map<LogTuple>(localUser);

            return user;

        }

        /*
        public IEnumerable<LogTuple> UserFilter(string sex, string email, string name) {

            var localListUsers = RepLog.Where(m => m.Sex.Contains(sex) && m.Email.Contains(email) && m.Name.Contains(name));

            var listlUsers = TinyMapper.Map<List<LogTuple>>(localListUsers);

            return listlUsers;
        }
        */
    }
}