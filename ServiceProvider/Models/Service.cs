using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceProvider.Models
{
    public class Service
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? ImageUrl { get; set; }


        public ICollection<ServiceItem> ServiceItems { get; set; }
    }
}
