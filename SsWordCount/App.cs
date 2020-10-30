using System;
using Microsoft.Extensions.DependencyInjection;
using SsWordCount.DataAccess;
using SsWordCount.DataAccess.Entities;
using SsWordCount.Helpers;
using SsWordCount.Services;
using SsWordCount.Services.PageLoader;
using SsWordCount.Services.PageWordCount;
using SsWordCount.Services.TextFileParser;

namespace SsWordCount
{
    public class App
    {
        public static void Run()
        {
            const string testUrl = "https://www.simbirsoft.com/";

            var services = ConfigureServices();

            var wordsCountService = services.GetService<WordCountService>();

            var wordsCount = wordsCountService.GetWordsCountByPageUrl(testUrl);

            ConsoleHelper.PrintWordsCount(wordsCount);

            var pageWordCountService = services.GetService<IPageWordCountService>();

            var page = pageWordCountService.AddWebPage(new PageWordCount {Url = testUrl, WordCounts = wordsCount});

            var readPage = pageWordCountService.GetWebPage(page.Id);

            ConsoleHelper.PrintWordsCount(readPage.WordCounts);

            pageWordCountService.DeleteWebPage(readPage);

            Console.ReadKey();
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