using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FrequencyCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TasksDayOne task = new TasksDayOne();
            Console.WriteLine(task.CalculateTotalFrequency());
            Console.WriteLine(task.ReturnFirstFrequencyReached());
                                               
        }
    }
}
