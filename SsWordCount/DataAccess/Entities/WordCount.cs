using System.ComponentModel.DataAnnotations;

namespace SsWordCount.DataAccess.Entities
{
    public class WordCount
    {
        public int Id { get; set; }

        [Required] public string Word { get; set; }

        public int Count { get; set; }
    }
}