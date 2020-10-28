using System;
using System.Net;
using HtmlAgilityPack;
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

            foreach (var str in parsedText)
            {
                Console.WriteLine(str + " ");
            }

            Console.ReadKey();
        }
    }
}