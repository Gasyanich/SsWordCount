using SsWordCount.DataAccess;
using SsWordCount.DataAccess.Entities;

namespace SsWordCount.Services.PageWordCountSaver
{
    /// <summary>
    /// Класс для загрузки количества вхождений слов на странице в бд
    /// </summary>
    public class PageWordCountSaverService : IPageWordCountSaverService
    {
        private readonly DataContext _dataContext;

        public PageWordCountSaverService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Добавляет информацию о количество вхождений слов на странице в бд
        /// </summary>
        /// <param name="pageWordCount">Страница с подсчитанными словами</param>
        /// <returns>Добавленная страница с присвоенным id</returns>
        public PageWordCount AddWebPage(PageWordCount pageWordCount)
        {
            _dataContext.WebPages.Add(pageWordCount);
            _dataContext.SaveChanges();

            return pageWordCount;
        }

        /// <summary>
        /// Удаляет страницу из бд
        /// </summary>
        /// <param name="pageWordCount">Страница для удаления</param>
        public void DeleteWebPage(PageWordCount pageWordCount)
        {
            _dataContext.WebPages.Remove(pageWordCount);
            _dataContext.SaveChanges();
        }

        /// <summary>
        /// Получение страницы по id из бд
        /// </summary>
        /// <param name="pageId">id страницы</param>
        /// <returns>Страница из бд с указанным id</returns>
        public PageWordCount GetWebPage(int pageId)
        {
            return _dataContext.WebPages.Find(pageId);
        }
    }
}