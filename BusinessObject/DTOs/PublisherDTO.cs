using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessObject.DTOs
{
    public class PublisherDTO
    {
        [Key]
        public int pub_id { get; set; }
        public string publisher_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }

    public class CreatePublisherDTO
    {
        public string publisher_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }

    public class UpdatePublisherDTO
    {
        public string publisher_name { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}