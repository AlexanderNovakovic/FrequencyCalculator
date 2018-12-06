using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2Tasks
{
    public static class FileExtensions
    {
        public static List<string> ReturnStringArrayFromFile(string input) => File.ReadAllLines(input).ToList();

        public static int GetHammingDistance(string firstWord, string secondWord) => firstWord.ToCharArray()
                .Zip(secondWord.ToCharArray(), (c1, c2) => new { c1, c2 })
                .Count(m => m.c1 != m.c2);
    }
}
