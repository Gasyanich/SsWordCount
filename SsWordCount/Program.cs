using System;
using Microsoft.Extensions.DependencyInjection;
using SsWordCount.DataAccess;
using SsWordCount.Services;
using SsWordCount.Services.PageLoader;
using SsWordCount.Services.PageWordCountSaver;
using SsWordCount.Services.TextFileParser;

namespace SsWordCount
{
    internal class Program
    {
        private static void Main()
        {
            var services = ConfigureServices();

            services.GetService<AppService>().Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection()
                .AddSingleton<IContentLoaderService, HtmlPageLoaderService>()
                .AddSingleton<ITextFileParserService, HtmlParserService>()
                .AddSingleton<WordsCountService>()
                .AddDbContext<DataContext>()
                .AddSingleton<IPageWordCountSaverService, PageWordCountSaverService>()
                .AddSingleton<AppService>()
                .BuildServiceProvider();

            return services;
        }
    }
}