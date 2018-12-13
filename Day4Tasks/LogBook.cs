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



        public static Dictionary<int, List<LogEntry>> GroupLogsByGuardId(List<LogEntry> logEntries)
        {
            var logsByGuardId = new Dictionary<int, List<LogEntry>>();                     

            int runningGuardId = logEntries.First().ExtractGuardId();

            foreach (LogEntry log in logEntries)
            {
                if (log.DoBeginsShift())
                {
                    runningGuardId = log.ExtractGuardId();
                    if (!logsByGuardId.ContainsKey(runningGuardId))
                    {
                        logsByGuardId[runningGuardId] = new List<LogEntry>();
                    }                    
                }

                logsByGuardId[runningGuardId].Add(log);
            }

            return logsByGuardId;
        }

        public static List<LogEntry> MidnightShifts(LogEntry[] logEntries)
        {
            List<LogEntry> midnightLogEntries = new List<LogEntry>();
                        
            foreach (LogEntry log in GetSortedLogs(logEntries))
            {
                midnightLogEntries.Add(log.StartingAtMidnightHour(log));
            }

            return midnightLogEntries;
        }

        public static List<LogEntry> GetSortedLogs(LogEntry[] logEntries)
        {
            for (int i = 0; i < logEntries.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < logEntries.Length; j++)
                {
                    if (logEntries[j].Timestamp < logEntries[minIndex].Timestamp)
                        minIndex = j;
                }

                LogEntry temp = logEntries[i];
                logEntries[i] = logEntries[minIndex];
                logEntries[minIndex] = temp;
            }

            return logEntries.ToList();
        }

        public static LogEntry GetLogEntry(string line) => 
            new LogEntry(ExtractTimestamp(line), ExtractLog(line));        

        public static string ExtractLog(string line) => line.Substring(19);

        public static DateTime ExtractTimestamp(string line) => 
            DateTime.ParseExact(line.Substring(1, 16), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);        
    }
}
