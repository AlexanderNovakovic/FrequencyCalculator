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
            int doubles = 0;
            int triples = 0;

            foreach (string word in words)
            {                   
                    if (IsLetterAppearingForGivenNumberOfTimes(word, 2))
                        doubles++;

                    if (IsLetterAppearingForGivenNumberOfTimes(word, 3))
                        triples++;                
            }

            return doubles * triples;
        }

        public static bool IsLetterAppearingForGivenNumberOfTimes(string word, int numberOfAppearance)
        {            
            foreach (char letter in word)
            {
                if (CountLetterAppearance(word, letter) == numberOfAppearance)                    
                    return true;
            }
                       
            return false;
        }

        public static int CountLetterAppearance(string word, char c)
        {
            int counter = 0;
            foreach(char letter in word)
            {
                if (letter == c)
                    counter++;
            }

            return counter;
        }

        public static string ReturnStringWithOneDifferentCharacter(string[] words)
        {
            string finalWord = "";

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

                        finalWord = string.Join("", sameChars);
                    }
                }
            }

            return finalWord;
        }

        public static int GetHammingDistance(string firstWord, string secondWord) =>
            Enumerable
            .Range(0, Math.Min(firstWord.Length, secondWord.Length))
            .Where(index => firstWord[index] != secondWord[index])
            .Count();
    }
}
