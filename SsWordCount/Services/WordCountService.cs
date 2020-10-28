using System.Collections.Generic;
using System.Linq;
using SsWordCount.Services.PageLoader;
using SsWordCount.Services.TextFileParser;

namespace SsWordCount.Services
{
    public class WordCountService
    {
        private readonly IContentLoaderService _contentLoaderService;
        private readonly ITextFileParserService _parserService;

        public WordCountService(IContentLoaderService contentLoaderService, ITextFileParserService parserService)
        {
            _contentLoaderService = contentLoaderService;
            _parserService = parserService;
        }

        public Dictionary<string, int> GetWordsCount(string url)
        {
            var filePath = _contentLoaderService.LoadContentAngGetPath(url);
            var parsedText = _parserService.Parse(filePath);

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