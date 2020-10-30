using System;
using SsWordCount.DataAccess.Entities;
using SsWordCount.Helpers;
using SsWordCount.Services.PageWordCountSaver;

namespace SsWordCount.Services
{
    public class AppService
    {
        private readonly WordsCountService _wordsCountService;
        private readonly IPageWordCountSaverService _pageWordCountSaverService;

        public AppService(WordsCountService wordsCountService, IPageWordCountSaverService pageWordCountSaverService)
        {
            _wordsCountService = wordsCountService;
            _pageWordCountSaverService = pageWordCountSaverService;
        }

        public void Run()
        {
            var pageUrl = ConsoleHelper.ReadLine("Введите адрес web страницы");

            var wordsCount = _wordsCountService.GetWordsCountByPageUrl(pageUrl);

            ConsoleHelper.PrintWordsCount(wordsCount);

            var page = _pageWordCountSaverService.AddWebPage(new PageWordCount
                {
                    Url = pageUrl,
                    WordsCount = wordsCount
                }
            );

            var readPage = _pageWordCountSaverService.GetWebPage(page.Id);

            ConsoleHelper.PrintWordsCount(readPage.WordsCount);

            _pageWordCountSaverService.DeleteWebPage(readPage);

            Console.ReadKey();
        }
    }
}