using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FileExtensions.FileExtensions;

namespace Day4Tasks
{
    public static class LogBook
    {

        public static int CalculateIdTimesMinute(LogEntry[] logEntries)
        {
            int id = 0;
            int sumOfMinutes = 0;

            

            return sumOfMinutes;
        }

        public static List<LogEntry> GetSortedLogs(LogEntry[] logEntries)
        {
            return logEntries.ToList().Sort((l1, l2) => DateTime.Compare(l1.Timestamp, l2.Timestamp));
        }

        public static Guard GetGuard(LogEntry logEntry)
        {
            int id = logEntry.ExtractGuardId();

            if(id >= 0)
            {

            }
        }

        public static LogEntry GetLogEntry(string line) => 
            new LogEntry(ExtractTimestamp(line), ExtractLog(line));        

        public static string ExtractLog(string line) => line.Substring(19);

        public static DateTime ExtractTimestamp(string line) => 
            DateTime.ParseExact(line.Substring(1, 16), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);        
    }
}
