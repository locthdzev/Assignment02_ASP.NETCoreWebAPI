using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Publisher
    {
        [Key]
        public int pub_id { get; set; }
        public string publisher_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}