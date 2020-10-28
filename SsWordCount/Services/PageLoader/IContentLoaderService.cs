namespace SsWordCount.Services.PageLoader
{
    public interface IContentLoaderService
    {
        void LoadContent(string contentPath, string filePath);
    }
}