using System;
using System.Collections.Generic;

namespace BenFattoLog.Domain.Entities {
    class LogFile {
        public LogFile(string filename, DateTime filedate, List<LogTuple> logs) {

            FileName = filename;
            FileDate = filedate;

            logs.Clear();
            logs.AddRange(logs);
        }

        protected LogFile() { }

        public void Update(string filename, DateTime filedate) {
            FileName = filename;
            FileDate = filedate;
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

        public string FileName { get; set; }
        public DateTime FileDate { get; set; }
        public List<LogTuple> Logs { get; set; }

    }
}
