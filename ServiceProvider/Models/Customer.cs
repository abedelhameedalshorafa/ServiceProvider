using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceProvider.Models
{

    public enum Role
    {
        Admin,
        Provider,
        Customer

    }
    public class Customer
    {
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        public int Phone { get; set; }

        public string? Password { get; set; }

        public string? City { get; set; }

        [Url]
        public string? Location { get; set; }

        public bool ForDelete { get; set; } = false;

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public Role Role { get; set; } = Role.Customer;

        public ICollection<Order> Orders { get; set; }

        public ICollection<FeedbackForWeb> feedbackForWebs { get; set;}

        public ICollection<FeedbackForProvider> feedbackForProviders { get; set; }
    }
}
