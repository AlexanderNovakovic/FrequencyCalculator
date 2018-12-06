using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Day2Tasks.TasksDayTwo;
using static FileExtensions.FileExtensions;

namespace UnitTests
{
    public class Day2Tests
    {
        [Theory]
        [InlineData(new string[] { "abcdef", "bababc", "abbcde", "abcccd", "aabcdd", "abcdee", "ababab" }, 12)]
        public void CalculateChecksumTest(string[] input, int expected)
        {
            Assert.Equal(expected, CalculateChecksum(input));
        }

        [Fact]
        public void CalculateChecksumTestTwo()
        {
            string[] input = ReadStringArrayFromFile("day2_input.txt");

            Assert.Equal(8296, CalculateChecksum(input));
        }
    }
}
