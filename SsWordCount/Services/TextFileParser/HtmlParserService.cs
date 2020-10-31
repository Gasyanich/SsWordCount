using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace SsWordCount.Services.TextFileParser
{
    /// <summary>
    /// Класс-сервис для извлечения со страницы слов
    /// </summary>
    public class HtmlParserService : ITextFileParserService
    {
        private readonly char[] _separators =
            {' ', ',', '.', '!', '?', '"', ';', ':', '[', ']', '(', ')', '\n', '\r', '\t', '«', '»', '|'};

        // regex под который попадают все слова (строки, состоящие только из букв) и слова с тире
        private readonly Regex _wordRegex = new Regex(@"(^(\p{Lu}{1,})-(\p{Lu}{1,}))|(^\p{Lu}{1,})");

        /// <summary>
        /// Парсит страницу по указанному пути до файла
        /// </summary>
        /// <param name="filePath">Относительный путь до файла</param>
        /// <returns>Массив слов</returns>
        public string[] Parse(string filePath)
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(filePath);

            var textContent = htmlDoc.DocumentNode.InnerText;

            var decoded = WebUtility.HtmlDecode(textContent);

            var parsedText = decoded.Split(_separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.ToUpper())
                .Where(s => _wordRegex.IsMatch(s))
                .ToArray();


            return parsedText;
        }
    }
}