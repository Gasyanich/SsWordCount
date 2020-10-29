using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SsWordCount.DataAccess;
using SsWordCount.DataAccess.Entities;
using SsWordCount.Services;
using SsWordCount.Services.PageLoader;
using SsWordCount.Services.PageWordCount;
using SsWordCount.Services.TextFileParser;

namespace SsWordCount
{
    internal class Program
    {
        private static void Main()
        {
            const string testUrl = "https://www.simbirsoft.com/";

            var services = ConfigureServices();

            var wordsCountService = services.GetService<WordCountService>();

            var wordsCount = wordsCountService.GetWordsCount(testUrl);

            PrintWordsCount(wordsCount);

            var pageWordCountService = services.GetService<IPageWordCountService>();

            var page = pageWordCountService.AddWebPage(new PageWordCount {Url = testUrl, WordCounts = wordsCount});

            var readPage = pageWordCountService.GetWebPage(page.Id);

            PrintWordsCount(readPage.WordCounts);

            pageWordCountService.DeleteWebPage(readPage);

            Console.ReadKey();
        }

        private static void PrintWordsCount(IEnumerable<WordCount> wordsCount)
        {
            foreach (var wordCount in wordsCount)
            {
                Console.WriteLine($"{wordCount.Word} - {wordCount.Count}");
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<IContentLoaderService, HtmlPageLoaderService>()
                .AddSingleton<ITextFileParserService, HtmlParserService>()
                .AddSingleton<WordCountService>()
                .AddDbContext<DataContext>()
                .AddSingleton<IPageWordCountService, PageWordCountService>()
                .BuildServiceProvider();

            return services;
        }
    }
}