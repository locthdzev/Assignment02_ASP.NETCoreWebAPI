using System.ComponentModel.DataAnnotations;

namespace BusinessObject.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string email_address { get; set; }
        public string password { get; set; }
        public string source { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public int role_id { get; set; }
        public int pub_id { get; set; }
        public DateTime hire_date { get; set; }

        public virtual Role Role { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}