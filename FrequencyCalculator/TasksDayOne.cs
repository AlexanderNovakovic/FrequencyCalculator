using System.Collections.Generic;
using System.Linq;
using static FrequencyCalculator.FileExtensions;

namespace FrequencyCalculator
{
    public static class TasksDayOne
    {

        public static int CalculateTotalFrequency(string input) =>
            GetIntArrayFromFile(input).Sum();

        public static int ReturnFirstDoubleFrequencyReached(string input)
        {
            int[] deltas = GetIntArrayFromFile(input);

            int frequency = 0;
            var numbers = new HashSet<int>();

            while (true)
            {
                foreach (int delta in deltas)
                {
                    frequency += delta;
                    if (numbers.Contains(frequency))
                    {
                        return frequency;
                    }
                    else
                    {
                        numbers.Add(frequency);
                    }
                }
            }
        }
    }
}
