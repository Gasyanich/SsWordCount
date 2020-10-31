namespace SsWordCount.Services.TextFileParser
{
    public interface ITextFileParserService
    {
        string[] Parse(string filePath);
    }
}