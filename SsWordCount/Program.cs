using System;
using Microsoft.Extensions.DependencyInjection;
using SsWordCount.Services;
using SsWordCount.Services.PageLoader;
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

            foreach (var wordCount in wordsCount)
            {
                Console.WriteLine($"{wordCount.Key} - {wordCount.Value}");
            }

            Console.ReadKey();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<IContentLoaderService, HtmlPageLoaderService>()
                .AddSingleton<ITextFileParserService, HtmlParserService>()
                .AddSingleton<WordCountService>()
                .BuildServiceProvider();

            return services;
        }
    }
}