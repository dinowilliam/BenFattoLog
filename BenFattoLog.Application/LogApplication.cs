using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BenFattoLog.Application {

    using BenFattoLog.Application.Contracts;
    using BenFattoLog.Application.DTO;
    using BenFattoLog.Application.Mapping;
    using BenFattoLog.DAL.Services.Contracts;
    using System.Net;

    public class LogApplication : ILogApplication  {
        
        private readonly ILogServiceCommands logServiceCommands;
        private readonly ILogServiceQueries logServiceQueries;

        private LogMappingFactory logMappingFactory;
        private LogSearchMappingFactory logSearchMappingFactory;
        public LogApplication(ILogServiceCommands logServiceCommands, ILogServiceQueries logServiceQueries) {

            this.logServiceCommands = logServiceCommands;
            this.logServiceQueries = logServiceQueries;
            this.logMappingFactory = new LogMappingFactory();
            this.logSearchMappingFactory = new LogSearchMappingFactory();
        }
        
        public int Save(LogDTO log) {
            
            return logServiceCommands.Save(logMappingFactory.ConvertLog(log));
        }
        
        public int Delete(Guid id) {
            
            var localLog = logServiceQueries.GetById(id);

            return logServiceCommands.Delete(localLog);
        }
        public IEnumerable<LogDTO> GetAll() {
            return logMappingFactory.ConvertLog(logServiceQueries.GetAll());
        }
        public IEnumerable<LogDTO> LogFilter(LogSearchDTO logSearch) {
            return logMappingFactory.ConvertLog(logServiceQueries.LogFilter(logSearchMappingFactory.ConvertLogSearch(logSearch)));
        }
        public LogDTO GetById(Guid id) {
            return logMappingFactory.ConvertLog(logServiceQueries.GetById(id));
        }
        public int Upload(byte[] file) {
            var stringList = new List<string>();

            var msFile = new MemoryStream(file);
            using (StreamReader srFile = new StreamReader(msFile)) {
                while (srFile.Peek() >= 0) {
                    stringList.Add(srFile.ReadLine());
                }
            }

            var listLog = new List<LogDTO>();

            foreach (string item in stringList) {

                var newLogDTO = new LogDTO();
                newLogDTO.Id = Guid.NewGuid();
                newLogDTO.IpAddress = IPAddress.Parse(item.Split()[0]);
                newLogDTO.OccurrenceeDate = ParseDateTimeLinq(item.Split()[3].Replace("[", "") + item.Split()[4].Replace("]", ""));
                newLogDTO.AccessLog = item.Split()[5].Replace("\"", "") + " " + item.Split()[6] + " " + item.Split()[7].Replace("\"", "");
                newLogDTO.Port = Convert.ToInt32(item.Split()[8].Replace("-", ""));
                

                listLog.Add(newLogDTO);
            }

            return logServiceCommands.AddRange(logMappingFactory.ConvertLog(listLog)); 
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
