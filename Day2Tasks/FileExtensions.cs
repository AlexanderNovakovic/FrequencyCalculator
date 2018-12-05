using System.IO;
using System.Linq;

namespace Day2Tasks
{
    public static class FileExtensions
    {
        public static string[] ReturnStringArrayFromFile(string input)
        {
            return File.ReadAllLines(input).ToArray();
        }
    }
}
