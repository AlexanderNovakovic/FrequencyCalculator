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
        public List<LogEntry> LogEntries { get; }

        public Guard(int id, List<LogEntry> logEntries)
        {
            Id = id;            
            LogEntries = logEntries;
        }
    }
}
