using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceProvider.Models
{
    public class ServiceItem
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        [Required]
        public string UrlImage { get; set; }

        [Required]
        public int? serviceID { get; set; }

        [ForeignKey("serviceID")]
        public virtual Service Service { get; set; }
        public ICollection<Provider> Providers { get; set; }
    }
}
