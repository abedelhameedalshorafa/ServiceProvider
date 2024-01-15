using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceProvider.Models
{
    public class Subscription
    {
        public int ID { get; set; }

        public string? Name { get; set; }

        public DateTime paymentDate { get; set; }

        public double paymentAmount { get; set; }

        public int numberOfMonths { get; set; }

        public DateTime startDate { get; set; }

        public DateTime endDate { get; set; }

        public bool flagfordelete { get; set; } = false;

        public string cardNumber { get; set; }

        public string? cardPassword { get; set; }

        public int providerID { get; set; }

        [ForeignKey("providerID")]
        public Provider Provider { get; set; }
    }
}
