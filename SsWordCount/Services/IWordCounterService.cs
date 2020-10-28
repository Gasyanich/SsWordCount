using System.Collections.Generic;

namespace SsWordCount.Services
{
    public interface IWordCounterService
    {
        public Dictionary<string, int> GetWordsCount(string contentFilePath);
    }
}