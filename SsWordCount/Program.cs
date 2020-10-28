using System;
using System.Net;
using HtmlAgilityPack;
using SsWordCount.Services;
using SsWordCount.Services.PageLoader;
using SsWordCount.Services.TextFileParser;

namespace SsWordCount
{
    internal class Program
    {
        private static void Main()
        {
            const string filePath = "E:\\projects\\c#\\ss\\testHtml.html";

            const string testUrl = "https://www.simbirsoft.com/";

            var contentLoader = new HtmlPageLoaderService();
            contentLoader.LoadContent(testUrl, filePath);

            var textFileParser = new HtmlParserService();
            var parsedText = textFileParser.Parse(filePath);

            var wordCounterService = new WordCountService();
            var wordsCount = wordCounterService.GetWordsCount(parsedText);

            foreach (var (word, count) in wordsCount)
            {
                Console.WriteLine($"{word.ToUpper()} - {count}");
            }

            Console.ReadKey();
        }
    }
}