using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceProvider.Models
{
    public class FeedbackForWeb
    {
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public feedbackStatus Status { get; set; } = feedbackStatus.Pending;

        public double Rating { get; set; }

        public int customerID { get; set; }

        [ForeignKey("customerID")]
        public virtual Customer Customer { get; set; }

    }
}
