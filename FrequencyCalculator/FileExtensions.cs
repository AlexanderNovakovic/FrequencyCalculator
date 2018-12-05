using System.IO;
using System.Linq;

namespace FrequencyCalculator
{
    public static class FileExtensions
    {
        public static int[] GetIntArrayFromFile(string input) =>
            File
            .ReadAllLines(input)
            .Select(int.Parse)
            .ToArray();
    }
}
