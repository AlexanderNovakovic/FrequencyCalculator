using static FileExtensions.FileExtensions;

namespace FrequencyCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] deltas = ReadIntArrayFromFile("day1_input.txt");

            string[] words = ReadStringArrayFromFile("day2_input.txt");

            // Console.WriteLine(CalculateTotalFrequency(deltas));
            // Console.WriteLine(ReturnFirstDoubleFrequencyReached(deltas));
            // Console.WriteLine(CalculateChecksum(words));
            // ReturnCommonOfTwoStrings("day2_input.txt");
            //Console.WriteLine(CalculateOverlappingSurface("day3_input.txt"));
        }
    }
}
