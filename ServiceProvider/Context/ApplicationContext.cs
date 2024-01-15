using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using ServiceProvider.Models;

namespace ServiceProvider.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option)
        {

        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Provider> providers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<ServiceItem> serviceItems { get; set; }
        public DbSet<Subscription> subscriptions { get; set; }
        public DbSet<FeedbackForProvider> feedbackForProviders { get; set; }
        public DbSet<FeedbackForWeb> feedbackForWebs { get; set; }
        public DbSet<Payment> payments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provider>(entity =>
            {
                entity.HasMany(p => p.Subscriptions)
                      .WithOne(s => s.Provider)
                      .HasForeignKey(s => s.providerID);


                entity.HasMany(p => p.Orders)
                      .WithOne(o => o.Provider)
                      .HasForeignKey(o => o.providerID);


                entity.HasMany(p => p.FeedbackForProviders)
                      .WithOne(f => f.Provider)
                      .HasForeignKey(f => f.providerID);
            });


            modelBuilder.Entity<Customer>(entity =>
                {

                    entity.HasMany(c => c.Orders)
                          .WithOne(o => o.Customer)
                          .HasForeignKey(o => o.customerID);

                    entity.HasMany(c => c.feedbackForWebs)
                          .WithOne(f => f.Customer)
                          .HasForeignKey(f => f.customerID);

                    entity.HasMany(c => c.feedbackForProviders)
                          .WithOne(f => f.Customer)
                          .HasForeignKey(f => f.customerID);
                });


            modelBuilder.Entity<Service>()
                .HasMany(s => s.ServiceItems)
                .WithOne(si => si.Service)
                .HasForeignKey(si => si.serviceID);

            modelBuilder.Entity<ServiceItem>()
                .HasMany(s => s.Providers)
                .WithOne(si => si.ServiceItem)
                .HasForeignKey(si => si.serviceID);

        }
    }
}
