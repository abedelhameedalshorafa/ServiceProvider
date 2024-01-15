using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceProvider.Models
{
    public enum feedbackStatus
    {
        Pending,
        Accepted,
        Archived
    }
    public class FeedbackForProvider
    {
        public int ID { get; set; }

        public string Text { get; set; }

        public feedbackStatus Status { get; set; } = feedbackStatus.Pending;

        public double Rating { get; set; }

        [Required]
        public int customerID { get; set; }

        [Required]
        public int providerID { get; set; }

        [ForeignKey("providerID")]
        public virtual Provider Provider { get; set; }

        [ForeignKey("customerID")]
        public virtual Customer Customer { get; set; }
    }
}
