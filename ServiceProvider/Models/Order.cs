using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ServiceProvider.Models
{

    public enum orderStatus{
        Pending,
        Accepted,
        Archived
    }
    public class Order
    {
        
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public orderStatus status { get; set; } = orderStatus.Pending;

        [Required]
        public int customerID { get; set; }

        [ForeignKey("customerID")]
        public Customer Customer { get; set; }
        [Required]
        public int providerID { get; set; }
        [ForeignKey("providerID")]
        public Provider Provider { get; set; }
    }
}
