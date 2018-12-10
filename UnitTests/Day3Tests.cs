using Xunit;
using static Day3Tasks.TasksDayThree;
using static FileExtensions.FileExtensions;

namespace UnitTests
{
    public class Day3Tests
    {
        [Theory]
        [InlineData(new string[] { "#1 @ 1,3: 4x4", "#2 @ 3,1: 4x4", "#3 @ 5,5: 2x2" }, 4)]
        public void CalculateOverlappingSurfaceTest(string[] input, int expected)
        {
            Assert.Equal(expected, CalculateOverlappingSurface(input));
        }

        [Fact]
        public void CalculateChecksumTestTwo()
        {
            string[] input = ReadStringArrayFromFile("day3_input.txt");

            Assert.Equal(101781, CalculateOverlappingSurface(input));
        }
    }
}
