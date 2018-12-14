using System;

namespace Day4Tasks
{
    public class LogEntry
    {
        public DateTime Timestamp { get; }
        public string Log { get; }

        public LogEntry(DateTime timestamp, string log)
        {
            Timestamp = timestamp;
            Log = log;
        }

        public bool DoBeginsShift() => Log.EndsWith("begins shift");
                            

        public LogEntry StartingAtMidnightHour(LogEntry logEntry)
        {
            if (logEntry.Timestamp.Hour == 23)
                return new LogEntry(Timestamp.Date.AddDays(1), Log);

            return logEntry;
        }

        public int ExtractGuardId() =>        
            int.Parse(Log
                .Replace("Guard #", string.Empty)
                .Replace(" begins shift", string.Empty));
        
    }
}
