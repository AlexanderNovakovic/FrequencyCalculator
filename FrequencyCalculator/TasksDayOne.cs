using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrequencyCalculator
{
    public class TasksDayOne
    {

        public int CalculateTotalFrequency()
        {
            int[] lines = ReadLines();
            
            int totalFrequency = 0;

            foreach (int item in lines)
            {
                totalFrequency += item;
            }

            return totalFrequency;
        }

        public int ReturnFirstFrequencyReached()
        {
            int[] lines = ReadLines();           

            int sum = 0;
            List<int> numbers = new List<int>();
            bool found = false;

            for (int i = 0; i < lines.Length; i++)
            {
                if (!found)
                {                     
                    sum += lines[i];
                    numbers.Add(sum);

                    if (numbers.GroupBy(x => x).Any(g => g.Count() > 1))
                        found = true;
                }
                else
                {
                    break;
                }
            }

            return sum;

        }

        public int[] ReadLines()
        {
            StreamReader reader = new StreamReader("Text.txt");
            string line = reader.ReadToEnd();
            int[] lines = line.Trim().Split('\n').Select(int.Parse).ToArray();           
            return lines;
        }
    }
}
