using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileExtensions
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

        public static List<string> ReturnStringArrayFromFile(string input) => 
            File
            .ReadAllLines(input)
            .ToList();

        public static int GetHammingDistance(string firstWord, string secondWord) =>
            Enumerable
                .Range(0, Math.Min(firstWord.Length, secondWord.Length))
                .Where(index => firstWord[index] != secondWord[index])
                .Count();
    }
}
