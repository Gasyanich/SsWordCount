using SsWordCount.DataAccess.Entities;

namespace SsWordCount.Services.PageWordCountSaver
{
    /// <summary>
    /// Интерфейс для сохранения количества слов на странице
    /// </summary>
    public interface IPageWordCountSaverService
    {
        PageWordCount AddWebPage(PageWordCount pageWordCount);
        void DeleteWebPage(PageWordCount pageWordCount);
        PageWordCount GetWebPage(int pageId);
    }
}