using System;
using System.Collections.Generic;
using System.Linq;
using static Day2Tasks.FileExtensions;

namespace Day2Tasks
{
    public static class TasksDayTwo
    {
        public static int CalculateChecksum(string input)
        {
            List<string> words = ReturnStringArrayFromFile(input);

            int doubles = 0;
            int triples = 0;

            foreach (string word in words)
            {
                bool doubleFound = false;
                bool tripleFound = false;

                char[] characters = word.ToCharArray();
                var appearanceArray = characters
                                        .GroupBy(x => x)
                                        .Where(g => g.Count() > 1)
                                        .Select(g => new { Element = g.Key, Counter = g.Count() })
                                        .ToArray();

                foreach (var obj in appearanceArray)
                {
                    if (obj.Counter == 2 && !doubleFound)
                    {
                        doubleFound = true;
                        doubles++;
                    }
                    else if (obj.Counter == 3 && !tripleFound)
                    {
                        tripleFound = true;
                        triples++;
                    }
                }
            }

            return doubles * triples;
        }

        public static string ReturnCommonOfTwoStrings(string input)
        {
            string finalWord = "";

            List<string> finalWords = ReturnListOfStringsWithOneDifferentCharacter(input);

            foreach (var word in finalWords)
            {
                Console.WriteLine(word);
            }

            return finalWords.First();
        }

        public static List<string> ReturnListOfStringsWithOneDifferentCharacter(string input)
        {
            List<string> words = ReturnStringArrayFromFile(input);

            List<string> finalWords = new List<string> { };

            for (int i = 0; i < words.Count - 1; i++)
            {
                string firstWord = words[i];
                for (int j = i + 1; j < words.Count; j++)
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
