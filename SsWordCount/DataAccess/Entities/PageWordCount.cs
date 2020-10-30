using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SsWordCount.DataAccess.Entities
{
    public class PageWordCount
    {
        public int Id { get; set; }

        [Required] public string Url { get; set; }

        public ICollection<WordCount> WordsCount { get; set; }
    }
}