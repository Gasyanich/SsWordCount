using System;

namespace SsWordCount.Services.PageLoader
{
    /// <summary>
    /// Интерфейс для загрузки контента по Uri
    /// </summary>
    public interface IContentLoaderService
    {
        string LoadContentAngGetPath(Uri uriContent);
    }
}