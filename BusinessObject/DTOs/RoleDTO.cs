using System.ComponentModel.DataAnnotations;

namespace BusinessObject.DTOs
{
    public class RoleDTO
    {
        [Key]
        public int role_id { get; set; }
        public string role_desc { get; set; }
    }
}