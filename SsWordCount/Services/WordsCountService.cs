﻿using System;
using System.Collections.Generic;
using System.Linq;
using SsWordCount.DataAccess.Entities;
using SsWordCount.Services.PageLoader;
using SsWordCount.Services.TextFileParser;

namespace SsWordCount.Services
{
    /// <summary>
    /// Класс-сервис для подсчета количества слов
    /// </summary>
    public class WordsCountService
    {
        private readonly IContentLoaderService _contentLoaderService;
        private readonly ITextFileParserService _parserService;

        public WordsCountService(IContentLoaderService contentLoaderService, ITextFileParserService parserService)
        {
            _contentLoaderService = contentLoaderService;
            _parserService = parserService;
        }

        /// <summary>
        /// Получение количества вхождений каждого слова по uri веб страницы
        /// </summary>
        /// <param name="uri">Url веб страницы</param>
        /// <returns>Количество вхождений кажодго слова на странице</returns>
        public List<WordCount> GetWordsCountByPageUri(Uri uri)
        {
            var filePath = _contentLoaderService.LoadContentAngGetPath(uri);
            var parsedText = _parserService.Parse(filePath);

            var wordsCount = new Dictionary<string, int>();

            var upperCaseText = parsedText.Select(s => s.Trim().ToUpper());

            foreach (var text in upperCaseText)
                if (wordsCount.ContainsKey(text))
                    wordsCount[text]++;
                else
                    wordsCount.Add(text, 1);

            return wordsCount.Select(kv => new WordCount
            {
                Word = kv.Key,
                Count = kv.Value
            }).ToList();
        }
    }
}