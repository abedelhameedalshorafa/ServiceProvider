using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ServiceProvider.Models;

namespace ServiceProvider.Models
{
    public class Provider
    {
        public int ID { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        public string? Position { get; set; }

        public int Phone { get; set; }

        public string? Password { get; set; }

        public string? City { get; set; }

        [Url]
        public string? Location { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }

        public string? ImageUrl { get; set; }

        public double MonthlyPrice { get; set; } = 40;

        public double Rate { get; set; }

        public DateTime SubscriptionStartDate { get; set; }

        public DateTime SubscriptionEndDate { get; set; }

        public bool IsSubscriptionActive { get; set; } = false;

        public bool IsActive { get; set; } = false;

        [Required]
        public Role Role { get; set; } = Role.Provider;
        public int? serviceID { get; set; }

        [ForeignKey("serviceID")]
        public virtual ServiceItem ServiceItem { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<FeedbackForProvider> FeedbackForProviders { get; set; }

    }
}

//public class SubscriptionService
//{
//    public void ProcessPayment(Provider provider, decimal paymentAmount)//here maybe just count of months I need table for subscription to check the 
//    {
//        provider.TotalPaid += paymentAmount;

//        // Check if the provider has achieved the subscription for the current month
//        if (provider.TotalPaid >= provider.MonthlyPrice)
//        {
//            if (!provider.IsSubscriptionActive)
//            {
//                // Set the subscription start date when the subscription becomes active
//                provider.SubscriptionStartDate = DateTime.Now;
//            }

//            // Calculate the subscription end date based on the number of months paid
//            provider.SubscriptionEndDate = provider.SubscriptionStartDate.AddMonths(1); // Assuming monthly subscription

//            provider.IsSubscriptionActive = true;
//        }
//        else
//        {
//            // Check if the current date is after the subscription end date
//            if (provider.IsSubscriptionActive && DateTime.Now > provider.SubscriptionEndDate)
//            {
//                // Subscription has finished, set IsSubscriptionActive to false
//                provider.IsSubscriptionActive = false;
//            }
//        }
//    }
//}

