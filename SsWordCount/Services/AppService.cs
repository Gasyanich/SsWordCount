using System;
using System.Net;
using System.Threading;
using Microsoft.Extensions.Logging;
using SsWordCount.DataAccess.Entities;
using SsWordCount.Helpers;
using SsWordCount.Services.PageWordCountSaver;

namespace SsWordCount.Services
{
    /// <summary>
    /// Класс, содержащий главную логику приложения
    /// </summary>
    public class AppService
    {
        private readonly ILogger<AppService> _logger;
        private readonly IPageWordCountSaverService _pageWordCountSaverService;
        private readonly WordsCountService _wordsCountService;

        public AppService(WordsCountService wordsCountService,
            IPageWordCountSaverService pageWordCountSaverService,
            ILogger<AppService> logger)
        {
            _wordsCountService = wordsCountService;
            _pageWordCountSaverService = pageWordCountSaverService;
            _logger = logger;
        }


        /// <summary>
        /// Запуск приложения
        /// </summary>
        public void Run()
        {
            try
            {
                var uri = GetUriFromConsole();

                var wordsCount = _wordsCountService.GetWordsCountByPageUri(uri);

                ConsoleHelper.PrintWordsCount(wordsCount);

                Console.WriteLine("\nДобавляем информацю в бд..");

                var page = _pageWordCountSaverService.AddWebPage(new PageWordCount
                    {
                        Url = uri.OriginalString,
                        WordsCount = wordsCount
                    }
                );
                Console.WriteLine("Готово");

                Console.WriteLine("\nЧитаем информацию из бд..");
                // чтобы "успеть" увидеть сообщение о чтении:)
                Thread.Sleep(TimeSpan.FromSeconds(3));

                var readPage = _pageWordCountSaverService.GetWebPage(page.Id);
                Console.WriteLine("Готово");

                ConsoleHelper.PrintWordsCount(readPage.WordsCount);

                Console.WriteLine("\nУдалям информацию из бд..");

                _pageWordCountSaverService.DeleteWebPage(readPage);
                Console.WriteLine("Готово\nЧтобы выйти из приложения нажмите любую клавишу..");

                Console.ReadKey();
            }
            catch (WebException e)
            {
                HandleException(e, "\nНе удалось скачать страницу по введенному адресу\n " +
                                   "Проверьте подключение к Интернету и правильность введеного адреса");
            }
            catch (OutOfMemoryException e)
            {
                HandleException(e, "\nРазмер скачанной страницы слишком большой!");
            }
            catch (Exception e)
            {
                HandleException(e, "\nВозникла ошибка во время работы приложения");
            }
        }

        private Uri GetUriFromConsole()
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

            return uri;
        }

        private void HandleException(Exception e, string consoleMessage)
        {
            Console.WriteLine(consoleMessage);
            _logger.LogExceptionStackTrace(e);
            Restart();
        }

        private void Restart()
        {
            Console.WriteLine("\nПерезапуск приложения..\n");
            Run();
        }
    }
}