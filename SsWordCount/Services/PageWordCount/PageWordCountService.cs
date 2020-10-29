using SsWordCount.DataAccess;
using WebPageWordCount = SsWordCount.DataAccess.Entities.PageWordCount;

namespace SsWordCount.Services.PageWordCount
{
    public class PageWordCountService : IPageWordCountService
    {
        private readonly DataContext _dataContext;

        public PageWordCountService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public WebPageWordCount AddWebPage(WebPageWordCount pageWordCount)
        {
            _dataContext.WebPages.Add(pageWordCount);
            _dataContext.SaveChanges();

            return pageWordCount;
        }

        public void DeleteWebPage(WebPageWordCount pageWordCount)
        {
            _dataContext.WebPages.Remove(pageWordCount);
            _dataContext.SaveChanges();
        }

        public WebPageWordCount GetWebPage(int pageId)
        {
            return _dataContext.WebPages.Find(pageId);
        }
    }
}