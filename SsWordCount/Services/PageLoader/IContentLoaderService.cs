using System;

namespace SsWordCount.Services.PageLoader
{
    public interface IContentLoaderService
    {
        string LoadContentAngGetPath(Uri uriContent);
    }
}