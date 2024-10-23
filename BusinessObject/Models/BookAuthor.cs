using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class BookAuthor
    {
        [Key]
        public int author_id { get; set; }
        public int book_id { get; set; }
        public int author_order { get; set; }
        public decimal royality_percentage { get; set; }

        public virtual Author Author { get; set; }
        public virtual Book Book { get; set; }
    }
}