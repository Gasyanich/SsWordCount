using System;
using System.IO;
using System.Net;

namespace SsWordCount.Services.PageLoader
{
    public class HtmlPageLoaderService : IContentLoaderService
    {
        private const string PagesFolderName = "DownloadedPages";
        private const string HtmlExtension = ".html";

        public string LoadContentAngGetPath(string contentPath)
        {
            var uri = new Uri(contentPath);

            var fileName = GetFileNameByUri(uri);
            var filePath = Path.Combine(PagesFolderName, fileName);

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