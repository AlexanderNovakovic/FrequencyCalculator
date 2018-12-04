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
            var hashset = new HashSet<int>();            

            while (true)
            {
                foreach (int number in lines)
                {
                    sum += number;
                    if (hashset.Contains(sum))
                    {
                        return sum;
                    }
                    else
                    {
                        hashset.Add(sum);
                    }                                           
                }
            }            
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
