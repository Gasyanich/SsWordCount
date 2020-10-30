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
            var isUriValid = false;
            Uri uri = null;

            while (!isUriValid)
            {
                var pageUrl = ConsoleHelper.ReadLine("Введите адрес web страницы");

                isUriValid = Uri.TryCreate(pageUrl, UriKind.Absolute, out uri)
                             && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);


                if (!isUriValid) Console.WriteLine("Неверный формат адреса!\n");
            }


            var wordsCount = _wordsCountService.GetWordsCountByPageUri(uri);

            ConsoleHelper.PrintWordsCount(wordsCount);

            var page = _pageWordCountSaverService.AddWebPage(new PageWordCount
                {
                    Url = uri.OriginalString,
                    WordsCount = wordsCount
                }
            );

            var readPage = _pageWordCountSaverService.GetWebPage(page.Id);

            // ConsoleHelper.PrintWordsCount(readPage.WordsCount);

            _pageWordCountSaverService.DeleteWebPage(readPage);

            Console.ReadKey();
        }
    }
}