using System;
using System.Net;
using Microsoft.Extensions.Logging;
using SsWordCount.DataAccess.Entities;
using SsWordCount.Helpers;
using SsWordCount.Services.PageWordCountSaver;

namespace SsWordCount.Services
{
    public class AppService
    {
        private readonly WordsCountService _wordsCountService;
        private readonly IPageWordCountSaverService _pageWordCountSaverService;
        private readonly ILogger<AppService> _logger;

        public AppService(WordsCountService wordsCountService,
            IPageWordCountSaverService pageWordCountSaverService,
            ILogger<AppService> logger)
        {
            _wordsCountService = wordsCountService;
            _pageWordCountSaverService = pageWordCountSaverService;
            _logger = logger;
        }

        public void Run()
        {
            try
            {
                var isUriValid = false;
                Uri uri = null;

                while (!isUriValid)
                {
                    var pageUrl = ConsoleHelper.ReadLine("Введите адрес web страницы");

                    isUriValid = Uri.TryCreate(pageUrl, UriKind.Absolute, out uri)
                                 && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);


                    if (!isUriValid) Console.WriteLine("\nНеверный формат адреса!\n");
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

                ConsoleHelper.PrintWordsCount(readPage.WordsCount);

                _pageWordCountSaverService.DeleteWebPage(readPage);

                Console.ReadKey();
            }
            catch (WebException e)
            {
                Console.WriteLine("\nПроверьте подключение к Интернету и правильность введеного адреса!");
                _logger.LogExceptionStackTrace(e);
                Restart();
            }
            catch (Exception e)
            {
                Console.WriteLine("Возникла ошибка во время работы приложения");
                _logger.LogExceptionStackTrace(e);
                Restart();
            }
        }

        private void Restart()
        {
            Console.WriteLine("\nПерезапуск приложения..\n");
            Run();
        }
    }
}