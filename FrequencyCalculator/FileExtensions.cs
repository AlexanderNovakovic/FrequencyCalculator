using System.IO;
using System.Linq;

namespace FrequencyCalculator
{
    public static class FileExtensions
    {
        public static int[] ReadIntArrayFromFile(string input) =>
            File
            .ReadAllLines(input)
            .Select(int.Parse)
            .ToArray();

        public static string[] ReadStringArrayFromFile(string input) => 
            File
            .ReadAllLines(input)
            .ToArray();
    }
}
