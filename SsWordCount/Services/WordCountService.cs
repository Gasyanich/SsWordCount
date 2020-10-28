using System.Collections.Generic;
using System.Linq;

namespace SsWordCount.Services
{
    public class WordCountService
    {
        public Dictionary<string, int> GetWordsCount(string[] parsedText)
        {
            var wordsCount = new Dictionary<string, int>();

            var upperCaseText = parsedText.Select(s => s.Trim().ToUpper());

            foreach (var text in upperCaseText)
            {
                if (wordsCount.ContainsKey(text))
                    wordsCount[text]++;
                else
                    wordsCount.Add(text, 1);
            }

            return wordsCount;
        }
    }
}