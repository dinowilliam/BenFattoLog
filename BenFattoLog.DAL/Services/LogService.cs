using System;
using System.Collections.Generic;
using System.Linq;

namespace BenFattoLog.DAL.Services {
    using BenFattoLog.DAL.Infra;
    using BenFattoLog.DAL.Infra.Contracts;
    using BenFattoLog.DAL.Repositorys;
    using BenFattoLog.DAL.Repositorys.Models;
    using BenFattoLog.Domain.Entities;
    using Nelibur.ObjectMapper;

    public class LogService {

        IRepository<Log> RepLog { get; set; }

        public LogService() {
            var dataContext = new BenFattoLogContext();
            this.RepLog = new LogRepository(dataContext);
        }

        public int Save(LogTuple log) {

            var localLog = new Log {
                Id = log.Id,
                IpAddress = log.IpAddress,
                OccurrenceeDate = log.OccurrenceeDate,
                AccessLog = log.AccessLog,
                HttpResponse = log.HttpResponse,
                Port = log.Port,
            };

            return RepLog.Insert(localLog);
        }

        public int AddRange(List<LogTuple> logs) {

            var listLog = logs.Select(a => new Log() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port

            }).ToList();

            return RepLog.AddRange(listLog);
        }

        public int Update(LogTuple log) {

            var localLog = new Log {
                Id = log.Id,
                IpAddress = log.IpAddress,
                OccurrenceeDate = log.OccurrenceeDate,
                AccessLog = log.AccessLog,
                HttpResponse = log.HttpResponse,
                Port = log.Port,
            };

            return RepLog.Update(localLog);
        }

        public int Delete(Guid id) {
            int deleteReturn;

            var localLog = RepLog.Get(id);

            try {
                RepLog.Delete(localLog);
                deleteReturn = 0;
            }
            catch (Exception) {
                deleteReturn = 1;
            }

            return deleteReturn;
        }

        public IEnumerable<LogTuple> GetAll() {

            var localListLog = RepLog.List();


            var listLog = localListLog.Select(a => new LogTuple() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port

            }).ToList();

            return listLog;
        }

        public LogTuple GetById(Guid id) {

            var localLog = RepLog.Get(id);

            var log = new LogTuple {
                Id = localLog.Id,
                IpAddress = localLog.IpAddress,
                OccurrenceeDate = localLog.OccurrenceeDate,
                AccessLog = localLog.AccessLog,
                HttpResponse = localLog.HttpResponse,
                Port = localLog.Port,
            };

            return log;

        }

        public IEnumerable<LogTuple> LogFilter(LogSearch logSearch) {

            var localListLog = RepLog.Where(m => m.IpAddress.Equals(logSearch.IpAddress) && m.OccurrenceeDate >= logSearch.InitialDate && m.OccurrenceeDate <= logSearch.FinalDate && m.AccessLog.Contains(logSearch.UserAgent));

            var listLog = localListLog.Select(a => new LogTuple() {
                Id = a.Id,
                IpAddress = a.IpAddress,
                OccurrenceeDate = a.OccurrenceeDate,
                AccessLog = a.AccessLog,
                HttpResponse = a.HttpResponse,
                Port = a.Port

            }).ToList();

            return listLog;
        }

    }
}