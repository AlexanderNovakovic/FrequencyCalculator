using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Tasks
{
    public class Guard
    {
        public int Id { get; }
        public int MinutesAsleep { get; }
        public List<LogEntry> LogEntries { get; }

        public Guard(int id, int minutesAsleep, List<LogEntry> logEntries)
        {
            Id = id;
            MinutesAsleep = minutesAsleep;
            LogEntries = logEntries;
        }
    }
}
