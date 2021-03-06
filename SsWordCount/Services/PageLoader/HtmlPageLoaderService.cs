﻿using System;
using System.IO;
using System.Net;

namespace SsWordCount.Services.PageLoader
{
    /// <summary>
    /// Класс-сервис для загрузки html страницы и сохранения ее на жесткий диск
    /// </summary>
    public class HtmlPageLoaderService : IContentLoaderService
    {
        private const string PagesFolderName = "DownloadedPages";
        private const string HtmlExtension = ".html";

        /// <summary>
        /// Загружает страницу по указанному uri и возвращает относительный путь до файла
        /// </summary>
        /// <param name="uri">Адрес для загрузки страницы</param>
        /// <returns>Путь до загруженного файла</returns>
        public string LoadContentAngGetPath(Uri uri)
        {
            var fileName = GetFileNameByUri(uri);
            var filePath = Path.Combine(PagesFolderName, fileName);

            if (!Directory.Exists(PagesFolderName))
                Directory.CreateDirectory(PagesFolderName);

            using var webClient = new WebClient();
            webClient.DownloadFile(uri, filePath);

            return filePath;
        }

        private string GetFileNameByUri(Uri contentUri)
        {
            // формируем имя файла из хоста + абсолютного пути uri
            var host = contentUri.Host.Replace("www.", string.Empty);
            // заменяем символы '/' на '-'
            var uriAbsPath = contentUri.AbsolutePath.Replace("/", "-");

            // убираем символ '-' в конце имени файла
            if (uriAbsPath.EndsWith("-"))
                uriAbsPath = uriAbsPath.Remove(uriAbsPath.Length - 1);

            var fileName = host + uriAbsPath + HtmlExtension;

            return fileName;
        }
    }
}