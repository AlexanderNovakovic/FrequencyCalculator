using static FileExtensions.FileExtensions;
using static Day2Tasks.TasksDayTwo;

namespace FrequencyCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] deltas = ReadIntArrayFromFile("day1_input.txt");

            // Console.WriteLine(CalculateTotalFrequency(deltas));
            // Console.WriteLine(ReturnFirstDoubleFrequencyReached(deltas));
            //Console.WriteLine(CalculateChecksum("day2_input.txt"));
            ReturnCommonOfTwoStrings("day2_input.txt");
        }
    }
}
