using static FileExtensions.FileExtensions;
using static Day4Tasks.LogBook;

namespace FrequencyCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] deltas = ReadIntArrayFromFile("day1_input.txt");

            string[] words = ReadStringArrayFromFile("day2_input.txt");

            string[] logs = ReadStringArrayFromFile("day4_input.txt");

            // Console.WriteLine(CalculateTotalFrequency(deltas));
            // Console.WriteLine(ReturnFirstDoubleFrequencyReached(deltas));
            // Console.WriteLine(CalculateChecksum(words));
            // ReturnCommonOfTwoStrings("day2_input.txt");
            //Console.WriteLine(CalculateOverlappingSurface("day3_input.txt"));

            System.Console.WriteLine(ExtractTimestamp(logs[0]));
        }
    }
}
