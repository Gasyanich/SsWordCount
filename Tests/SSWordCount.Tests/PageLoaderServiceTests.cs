using System;
using System.IO;
using NUnit.Framework;
using SsWordCount.Services.PageLoader;

namespace SSWordCount.Tests
{
    public class PageLoaderServiceTests
    {
        private IContentLoaderService _contentLoaderService;

        [SetUp]
        public void Setup()
        {
            _contentLoaderService = new HtmlPageLoaderService();
        }

        [Test]
        public void TestPageDownload()
        {
            var googleUri = new Uri("https://google.com");

            var contentPath = _contentLoaderService.LoadContentAngGetPath(googleUri);

            var fileExist = File.Exists(contentPath);

            Assert.AreEqual(fileExist, true);
        }
    }
}