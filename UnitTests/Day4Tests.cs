using System;
using System.Collections.Generic;
using Xunit;
using static FileExtensions.FileExtensions;
using static Day4Tasks.LogBook;
using Day4Tasks;

namespace UnitTests
{
    public class Day4Tests
    {
        [Theory]
        [MemberData(nameof(TotalMinutesAsleepTestParams))]
        public void TotalMinutesAsleepTest(List<LogEntry> input, int expected)
        {
            Assert.Equal(expected, TotalMinutesAsleep(input.ToArray()));
        }

        public static IEnumerable<object[]> TotalMinutesAsleepTestParams()
        {
            yield return new object[]
            {
                new List<LogEntry>
                {
                    new LogEntry(new DateTime(1518, 11, 01, 00, 00, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 05, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 25, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 30, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 55, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 05, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 24, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 29, 00), "wakes up"),
                },
                50
            };

            yield return new object[]
           {
                new List<LogEntry>
                {
                    new LogEntry(new DateTime(1518, 11, 01, 23, 58, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 40, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 50, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 02, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 36, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 46, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 03, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 45, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 55, 00), "wakes up")
                },
                30
            };
        }

        [Fact]
        public void TotalMinutesAsleepTestTwo()
        {
            LogEntry[] logs = GetLogEntries(ReadStringArrayFromFile("day4_input.txt"));            

            var totalMinutesAsleepPerGuardId = TotalMinutesAsleepPerGuardId(GroupLogsByGuardId(GetSortedLogs(logs)));

            Assert.Equal(310, totalMinutesAsleepPerGuardId[151]);            
        }

        [Theory]
        [MemberData(nameof(MostMinutesAsleepTestParams))]
        public void ReturnMostAsleepGuardIdTest(Dictionary<int, int> input, int expected)
        {
            Assert.Equal(expected, ReturnMostAsleepGuardId(input));
        }

        public static IEnumerable<object[]> MostMinutesAsleepTestParams()
        {
            yield return new object[]
            {
                new Dictionary<int, int>
                {
                    {10, 50 },
                    {99, 30 }
                },
                10
            };
        }
    }
}
