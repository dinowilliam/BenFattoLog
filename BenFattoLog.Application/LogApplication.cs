using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BenFattoLog.Application {

    using BenFattoLog.Application.Contracts;
    using BenFattoLog.DAL.Services.Contracts;
    using BenFattoLog.Domain.Entities;

    public class LogApplication : ILogApplication  {
        
        private readonly ILogServiceCommands logServiceCommands;
        private readonly ILogServiceQueries logServiceQueries;
        public LogApplication(ILogServiceCommands logServiceCommands, ILogServiceQueries logServiceQueries) {

            this.logServiceCommands = logServiceCommands;
            this.logServiceQueries = logServiceQueries;
        }

        public int Save(LogMessage log) {
            return logServiceCommands.Save(log);
        }
        
        public int Delete(Guid id) {
            
            var localLog = logServiceQueries.GetById(id);

            return logServiceCommands.Delete(localLog);
        }
        public IEnumerable<LogMessage> GetAll() {
            return logServiceQueries.GetAll();
        }
        public IEnumerable<LogMessage> LogFilter(LogSearch logSearch) {
            return logServiceQueries.LogFilter(logSearch);
        }
        public LogMessage GetById(Guid id) {
            return logServiceQueries.GetById(id);
        }
        public int Upload(byte[] file) {
            var stringList = new List<string>();

            var msFile = new MemoryStream(file);
            using (StreamReader srFile = new StreamReader(msFile)) {
                while (srFile.Peek() >= 0) {
                    stringList.Add(srFile.ReadLine());
                }
            }

            var listLog = new List<LogMessage>();

            foreach (string item in stringList) {

                var newLogTuple = new LogMessage();
                newLogTuple.Id = Guid.NewGuid();
                newLogTuple.Title = item.Split()[0];
                newLogTuple.OccurrenceeDate = ParseDateTimeLinq(item.Split()[3].Replace("[", "") + item.Split()[4].Replace("]", ""));
                newLogTuple.Description = item.Split()[5].Replace("\"", "") + " " + item.Split()[6] + " " + item.Split()[7].Replace("\"", "");
                newLogTuple.Source = item.Split()[8].Replace("-", "");
                

                listLog.Add(newLogTuple);
            }

            return logServiceCommands.AddRange(listLog); ;
        }

        public DateTime ParseDateTimeLinq(string dateToParse) {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dateParse;

            var format = "dd/MMM/yyyy:HH:mm:sszzz";
            dateParse = DateTime.ParseExact(dateToParse, format, provider);

            return dateParse;
        }
                

    }

}
