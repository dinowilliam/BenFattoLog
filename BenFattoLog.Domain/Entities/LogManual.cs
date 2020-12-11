using System;
using System.Collections.Generic;

namespace BenFattoLog.Domain.Entities {
    class LogManual {
        public LogManual(string logname, DateTime logdate, List<LogTuple> logs) {
            LogName = logname;
            LogDate = logdate;
            logs.Clear();
            logs.AddRange(logs);
        }

        protected LogManual() { }

        public void Update(string logname, DateTime logdate) {
            LogName = logname;
            LogDate = logdate;
        }

        public void AddLog(LogTuple log) {
            Logs.Add(log);
        }

        public void AddLog(List<LogTuple> logs) {
            Logs.AddRange(logs);
        }

        public void Remove(LogTuple log) {
            Logs.Remove(log);
        }

        public void Remove(List<LogTuple> logs) {
            Logs.RemoveAll(log => logs.Contains(log));
        }

        public void Remove(int index) {
            Logs.RemoveAt(index);
        }

        public void ClearLogs() {
            Logs.Clear();
        }

        public string LogName { get; set; }
        public DateTime LogDate { get; set; }
        public  List<LogTuple> Logs { get; set; }
    }
}
