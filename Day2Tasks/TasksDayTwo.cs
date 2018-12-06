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
                var appearanceArray = characters.GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => new { Element = y.Key, Counter = y.Count() })
                    .ToArray();                

                foreach (var obj in appearanceArray)
                {                   
                    if (obj.Counter == 2 && !doubleFound) { 
                        doubleFound = true;
                        doubles++;
                    }
                    else if (obj.Counter == 3 && !tripleFound) { 
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

            foreach (string firstWord in finalWords)
            {
                foreach(string secondWord in finalWords)
                {
                    if(firstWord != secondWord)
                    {
                        var sameChars = firstWord.Intersect(secondWord);
                        finalWord = String.Join("", sameChars);
                    }
                }                
            }
            return finalWord;
        }

        public static List<string> ReturnListOfStringsWithOneDifferentCharacter(string input)
        {
            List<string> words = ReturnStringArrayFromFile(input);

            List<string> finalWords = new List<string> { };

            foreach (string firstWord in words)
            {
                foreach (string secondWord in words)
                {
                    if (GetHammingDistance(firstWord, secondWord) == 1)
                    {
                        var sameChars = firstWord.Intersect(secondWord);
                        string sameCharsWord = String.Join("", sameChars);
                        finalWords.Add(sameCharsWord);
                    }
                }
            }
            return finalWords;
        }
    }
}
