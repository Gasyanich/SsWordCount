using System;
using System.Net;
using HtmlAgilityPack;

namespace SsWordCount.Services.TextFileParser
{
    public class HtmlParserService : ITextFileParserService
    {
        private readonly char[] _separators =
            {' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t'};

        public string[] Parse(string filePath)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);

            var textContent = htmlDoc.DocumentNode.InnerText;

            var decoded = WebUtility.HtmlDecode(textContent);

            var parsedText = decoded.Split(_separators, StringSplitOptions.RemoveEmptyEntries);

            return parsedText;
        }
    }
}