using System.Collections.Generic;
using System.Linq;
using static FrequencyCalculator.FileExtensions;

namespace FrequencyCalculator
{
    public static class TasksDayOne
    {
        public static int CalculateTotalFrequency(int[] deltas) =>
            deltas.Sum();

        public static int ReturnFirstDoubleFrequencyReached(int[] deltas)
        {
            int frequency = 0;
            var seen = new HashSet<int>();

            while (true)
            {
                foreach (int delta in deltas)
                {
                    frequency += delta;
                    if (seen.Contains(frequency))
                    {
                        return frequency;
                    }
                    else
                    {
                        seen.Add(frequency);
                    }
                }
            }
        }
    }
}
