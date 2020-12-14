using BenFattoLog.DAL.Services;
using BenFattoLog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;

namespace BenFattoLog.BLL {
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
        public IEnumerable<LogTuple> LogFilter(LogSearch logSearch) {
            return logService.LogFilter(logSearch);
        }
        public LogTuple GetById(Guid id) {
            return logService.GetById(id);
        }
        public int Upload(byte[] file) {
            var stringList = new List<string>();

            var msFile = new MemoryStream(file);
            using (StreamReader srFile = new StreamReader(msFile)) {
                while (srFile.Peek() >= 0) {
                    stringList.Add(srFile.ReadLine());
                }
            }

            var listLog = new List<LogTuple>();

            foreach (string item in stringList) {

                var newLogTuple = new LogTuple();
                newLogTuple.Id = Guid.NewGuid();
                newLogTuple.IpAddress = IPAddress.Parse(item.Split()[0]);
                newLogTuple.OccurrenceeDate = ParseDateTimeLinq(item.Split()[3].Replace("[", "") + item.Split()[4].Replace("]", ""));
                newLogTuple.AccessLog = item.Split()[5].Replace("\"", "") + " " + item.Split()[6] + " " + item.Split()[7].Replace("\"", "");
                newLogTuple.HttpResponse = ParseShortLinq(item.Split()[8].Replace("-", ""));
                newLogTuple.Port = ParseIntLinq(item.Split()[9].Replace("-", ""));

                listLog.Add(newLogTuple);
            }

            return logService.AddRange(listLog); ;
        }

        public DateTime ParseDateTimeLinq(string dateToParse) {
            CultureInfo provider = CultureInfo.InvariantCulture;
            DateTime dateParse;

            var format = "dd/MMM/yyyy:HH:mm:sszzz";
            dateParse = DateTime.ParseExact(dateToParse, format, provider);

            return dateParse;
        }

        public short? ParseShortLinq(string shortToParse) {
            short? value = null;

            if (!string.IsNullOrWhiteSpace(shortToParse))
                value = Convert.ToInt16(shortToParse);

            return value;
        }
        public int? ParseIntLinq(string shortToParse) {
            int? value = null;
            if (!string.IsNullOrWhiteSpace(shortToParse))
                value = Convert.ToInt32(shortToParse);
            return value;
        }

    }

}
