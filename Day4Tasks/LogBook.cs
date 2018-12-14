using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day4Tasks
{
    public static class LogBook
    {
        public static int ReturnMostAsleepGuardId(Dictionary<int, int> totalMinutesAsleepPerGuardId)
        {
            int maxTimeAsleep = 0;
            int mostAsleepGuardId = 0;

            foreach (var item in totalMinutesAsleepPerGuardId)
            {
                if (item.Value > maxTimeAsleep)
                {
                    maxTimeAsleep = item.Value;
                    mostAsleepGuardId = item.Key;
                }                                        
            }

            return mostAsleepGuardId;
        }

        public static Dictionary<int, int> TotalMinutesAsleepPerGuardId(Dictionary<int, List<LogEntry>> guardLogs)
        {
            var totalMinutesAsleepPerGuard = new Dictionary<int, int>();

            int sum = 0;

            foreach (var item in guardLogs)
            {
                sum = TotalMinutesAsleep(item.Value.ToArray());

                totalMinutesAsleepPerGuard[item.Key] = sum;
            }

            return totalMinutesAsleepPerGuard;
        }

        public static int TotalMinutesAsleep(LogEntry[] logs)
        {
            int sum = 0;

            for (int i = 0; i < logs.Length; i++)
            {
                if (logs[i].Log == "falls asleep" && i < logs.Length - 1)
                {
                    sum += (int)(logs[i + 1].Timestamp - logs[i].Timestamp).TotalMinutes;
                }
            }

            return sum;
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

        public static List<LogEntry> MidnightShifts(this List<LogEntry> logEntries)
        {
            List<LogEntry> midnightLogEntries = new List<LogEntry>();
                        
            foreach (LogEntry log in GetSortedLogs(logEntries.ToArray()))
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

        public static LogEntry[] GetLogEntries(string[] lines)
        {
            List<LogEntry> logs = new List<LogEntry>();

            foreach (string line in lines)
            {
                logs.Add(GetLogEntry(line));
            }

            return logs.ToArray();
        }

        public static LogEntry GetLogEntry(string line) => 
            new LogEntry(ExtractTimestamp(line), ExtractLog(line));        

        public static string ExtractLog(string line) => line.Substring(19);

        public static DateTime ExtractTimestamp(string line) => 
            DateTime.ParseExact(line.Substring(1, 16), "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);        
    }
}
