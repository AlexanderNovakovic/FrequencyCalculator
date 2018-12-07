using System;
using System.Collections.Generic;
using System.Linq;
using static FileExtensions.FileExtensions;

namespace Day2Tasks
{
    public static class TasksDayTwo
    {
        public static int CalculateChecksum(string[] words)
        {
            
        }

        public static List<string> ReturnListOfStringsWithOneDifferentCharacter(string input)
        {
            string[] words = ReadStringArrayFromFile(input);

            List<string> finalWords = new List<string> { };

            for (int i = 0; i < words.Length - 1; i++)
            {
                string firstWord = words[i];
                for (int j = i + 1; j < words.Length; j++)
                {
                    string secondWord = words[j];
                    if (GetHammingDistance(firstWord, secondWord) == 1)
                    {
                        var sameChars = Enumerable
                            .Range(0, Math.Min(firstWord.Length, secondWord.Length))
                            .Where(index => firstWord[index] == secondWord[index])
                            .Select(index => firstWord[index]);

                        string sameCharsWord = string.Join("", sameChars);

                        finalWords.Add(sameCharsWord);
                    }
                }
            }

            return finalWords;
        }
    }
}
