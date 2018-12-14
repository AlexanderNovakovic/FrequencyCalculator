using System.Collections.Generic;

namespace Day4Tasks
{
    public class GuardLogEntries
    {
        public int Id { get; }        
        public List<LogEntry> LogEntries { get; }

        public GuardLogEntries(int id, List<LogEntry> logEntries)
        {
            Id = id;            
            LogEntries = logEntries;
        }
    }
}
