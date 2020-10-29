using WebPageWordCount = SsWordCount.DataAccess.Entities.PageWordCount;

namespace SsWordCount.Services.PageWordCount
{
    public interface IPageWordCountService
    {
        WebPageWordCount AddWebPage(WebPageWordCount pageWordCount);
        void DeleteWebPage(WebPageWordCount pageWordCount);
        WebPageWordCount GetWebPage(int pageId);
    }
}