using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class BookDTO
    {
        [Key]
        public int book_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string pub_name { get; set; }
        public decimal price { get; set; }
        public decimal advance { get; set; }
        public decimal royalty { get; set; }
        public int ytd_sales { get; set; }
        public string notes { get; set; }
        public DateTime published_date { get; set; }
    }

    public class CreateBookDTO
    {
        public string title { get; set; }
        public string type { get; set; }
        public int pub_id { get; set; }
        public decimal price { get; set; }
        public decimal advance { get; set; }
        public decimal royalty { get; set; }
        public int ytd_sales { get; set; }
        public string notes { get; set; }
        public DateTime published_date { get; set; }
    }

    public class UpdateBookDTO
    {
        public string title { get; set; }
        public string type { get; set; }
        public int pub_id { get; set; }
        public decimal price { get; set; }
        public decimal advance { get; set; }
        public decimal royalty { get; set; }
        public int ytd_sales { get; set; }
        public string notes { get; set; }
        public DateTime published_date { get; set; }
    }
}