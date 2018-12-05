using System.Linq;
using static Day2Tasks.FileExtensions;

namespace Day2Tasks
{
    public static class TasksDayTwo
    {
        public static int CalculateChecksum(string input)
        {
            string[] words = ReturnStringArrayFromFile(input);

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
    }
}
