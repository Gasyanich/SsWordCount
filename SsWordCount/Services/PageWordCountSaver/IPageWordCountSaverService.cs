using SsWordCount.DataAccess.Entities;

namespace SsWordCount.Services.PageWordCountSaver
{
    public interface IPageWordCountSaverService
    {
        PageWordCount AddWebPage(PageWordCount pageWordCount);
        void DeleteWebPage(PageWordCount pageWordCount);
        PageWordCount GetWebPage(int pageId);
    }
}