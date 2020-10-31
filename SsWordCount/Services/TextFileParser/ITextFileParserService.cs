namespace SsWordCount.Services.TextFileParser
{
    /// <summary>
    /// Интерфейс для парсинга текстовых файлов
    /// </summary>
    public interface ITextFileParserService
    {
        string[] Parse(string filePath);
    }
}