using System.ComponentModel.DataAnnotations;

namespace SsWordCount.DataAccess.Entities
{
    /// <summary>
    /// Слово и количество его вхождений на странице
    /// </summary>
    public class WordCount
    {
        public int Id { get; set; }

        /// <summary>
        /// Слово
        /// </summary>
        [Required] public string Word { get; set; }

        /// <summary>
        /// Количество вхождений слова на странице
        /// </summary>
        public int Count { get; set; }
    }
}