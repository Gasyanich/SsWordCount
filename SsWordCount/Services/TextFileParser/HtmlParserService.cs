using System;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

namespace SsWordCount.Services.TextFileParser
{
    public class HtmlParserService : ITextFileParserService
    {
        private readonly char[] _separators =
            {' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '«', '»'};

        // если строка начинается на какой-то из этих символов - то это не слово (номер телефона, дата и тд)
        private readonly char[] _excludingWordChars = {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-', '–'};

        public string[] Parse(string filePath)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);

            var textContent = htmlDoc.DocumentNode.InnerText;

            var decoded = WebUtility.HtmlDecode(textContent);

            var parsedText = decoded.Split(_separators, StringSplitOptions.RemoveEmptyEntries)
                //убираем из результатов строки, начинающиеся с цифр или тире
                .Where(s => !_excludingWordChars.Contains(s.First()))
                .ToArray();


            return parsedText;
        }
    }
}