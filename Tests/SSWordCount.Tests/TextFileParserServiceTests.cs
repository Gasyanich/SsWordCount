using NUnit.Framework;
using SsWordCount.Services.TextFileParser;

namespace SSWordCount.Tests
{
    public class TextFileParserServiceTests
    {
        private ITextFileParserService _textFileParserService;

        [SetUp]
        public void Setup()
        {
            _textFileParserService = new HtmlParserService();
        }

        [Test]
        public void TextFileParseTest()
        {
            var parsedText = _textFileParserService.Parse("TestData\\testHtml.html");

            Assert.AreEqual(parsedText.Length, 7);

            Assert.Contains("TITLE", parsedText);
            Assert.Contains("PARAGRAPH", parsedText);
            Assert.Contains("ONE", parsedText);
            Assert.Contains("TWO", parsedText);
            Assert.Contains("THREE", parsedText);
        }
    }
}