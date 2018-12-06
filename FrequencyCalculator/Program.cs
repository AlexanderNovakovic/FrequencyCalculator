using System;
using static FrequencyCalculator.TasksDayOne;
using static FrequencyCalculator.FileExtensions;
using static Day2Tasks.TasksDayTwo;

namespace FrequencyCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] deltas = ReadIntArrayFromFile("day1_input.txt");

            // Console.WriteLine(CalculateTotalFrequency(deltas));
            //Console.WriteLine(ReturnFirstDoubleFrequencyReached(deltas));

            ReturnCommonOfTwoStrings("day2_input.txt");
        }
    }
}
