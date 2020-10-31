using System;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using SsWordCount.Services;
using SsWordCount.Services.PageLoader;
using SsWordCount.Services.TextFileParser;

namespace SSWordCount.Tests
{
    public class WordsCountServiceTests
    {
        private WordsCountService _wordsCountService;

        [SetUp]
        public void Setup()
        {
            var serviceCollection = new ServiceCollection();

            var contentLoaderServiceMock = new Mock<IContentLoaderService>();

            contentLoaderServiceMock.Setup(service => service.LoadContentAngGetPath(null))
                .Returns("TestData\\testHtml.html");

            var services = serviceCollection.AddSingleton(contentLoaderServiceMock.Object)
                .AddSingleton<ITextFileParserService, HtmlParserService>()
                .AddSingleton<WordsCountService>()
                .BuildServiceProvider();


            _wordsCountService = services.GetService<WordsCountService>();
        }

        [Test]
        public void TestWordsCountService()
        {
            var wordsCount = _wordsCountService.GetWordsCountByPageUri(null);

            var titleCount = wordsCount[0].Count;
            var paragraphCount = wordsCount[1].Count;
            var oneCount = wordsCount[2].Count;
            var twoCount = wordsCount[3].Count;
            var threeCount = wordsCount[4].Count;

            Assert.AreEqual(5, wordsCount.Count);

            Assert.AreEqual(1, titleCount);
            Assert.AreEqual(3, paragraphCount);
            Assert.AreEqual(1, oneCount);
            Assert.AreEqual(1, twoCount);
            Assert.AreEqual(1, threeCount);
        }
    }
}