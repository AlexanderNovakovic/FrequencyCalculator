using System;
using static FrequencyCalculator.TasksDayOne;


namespace FrequencyCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {                        
            // Console.WriteLine(CalculateTotalFrequency("day1_input.txt"));
            Console.WriteLine(ReturnFirstDoubleFrequencyReached("day1_input.txt"));
        }
    }
}
