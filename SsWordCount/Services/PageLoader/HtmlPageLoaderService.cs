using System;
using System.Net;

namespace SsWordCount.Services.PageLoader
{
    public class HtmlPageLoaderService : IContentLoaderService
    {
        public void LoadContent(string contentPath, string filePath)
        {
            var uri = new Uri(contentPath);

            using var webClient = new WebClient();
            webClient.DownloadFile(uri, filePath);
        }
    }
}