using SsWordCount.DataAccess;
using SsWordCount.DataAccess.Entities;


namespace SsWordCount.Services.PageWordCountSaver
{
    public class PageWordCountSaverService : IPageWordCountSaverService
    {
        private readonly DataContext _dataContext;

        public PageWordCountSaverService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public PageWordCount AddWebPage(PageWordCount pageWordCount)
        {
            _dataContext.WebPages.Add(pageWordCount);
            _dataContext.SaveChanges();

            return pageWordCount;
        }

        public void DeleteWebPage(PageWordCount pageWordCount)
        {
            _dataContext.WebPages.Remove(pageWordCount);
            _dataContext.SaveChanges();
        }

        public PageWordCount GetWebPage(int pageId)
        {
            return _dataContext.WebPages.Find(pageId);
        }
    }
}