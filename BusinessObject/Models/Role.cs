using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class Role
    {
        [Key]
        public int role_id { get; set; }
        public string role_desc { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}