using BenFattoLog.DAL.Services;
using BenFattoLog.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BenFattoLog.BLL
{
    public class LogBusiness {
        LogService logService { get; set; }
        public LogBusiness() {
            this.logService = new LogService();
        }
        public int Save(LogTuple log) {
            return logService.Save(log);
        }
        public int Update(LogTuple log) {
            return logService.Update(log);
        }
        public int Delete(Guid id) {
            return logService.Delete(id);
        }
        public IEnumerable<LogTuple> GetAll() {
            return logService.GetAll();
        }
        public LogTuple GetById(Guid id) {
            return logService.GetById(id);
        }
        //public IEnumerable<LogTuple> UserFilter(string sex, string email, string name) {
        //    return logService.LogFilter(sex, email, name);
        //}
    }

}
