using Xunit;
using static FrequencyCalculator.TasksDayOne;
using static FileExtensions.FileExtensions;

namespace UnitTests
{
    public class Day1Tests
    {
        [Theory]
        [InlineData(new int[] { 1, 1, 1 }, 3)]
        [InlineData(new int[] {1, 1, -2}, 0)]
        [InlineData (new int[] { -1, -2, -3 }, -6)]
        public void CalculateTotalFrequencyTest(int [] deltas, int expected)
        {
            Assert.Equal(expected, CalculateTotalFrequency(deltas));
        }

        [Fact]
        public void CalculateTotalFrequencyTestTwo()
        {
            int[] deltas = ReadIntArrayFromFile("day1_input.txt");

            Assert.Equal(510, CalculateTotalFrequency(deltas));
        }

        [Theory]
        [InlineData(new int[] { 1, -2, 3, 1, 1, -2 }, 2)]
        public void ReturnFirstDoubleFrequencyReachedTest(int[] deltas, int expected)
        {
            Assert.Equal(expected, ReturnFirstDoubleFrequencyReached(deltas));
        }

        [Fact]
        public void ReturnFirstDoubleFrequencyReachedTestTwo()
        {
            int[] deltas = ReadIntArrayFromFile("day1_input.txt");

            Assert.Equal(69074, ReturnFirstDoubleFrequencyReached(deltas));
        }
    }
}
