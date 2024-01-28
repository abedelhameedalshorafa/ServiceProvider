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


            /// for intial values 
            /// 

            modelBuilder.Entity<Service>().HasData(
                new Service { ID = 1, Name = "Home", Description = "Revitalize your home with our quick and efficient services. From cleaning to repairs, we've got it handled. Enjoy a hassle-free, comfortable living space with our expert touch.", ImageUrl = "~/Images/Home.png" },
                new Service { ID = 2, Name = "Health", Description = "Boost your health with our swift services. From check-ups to treatments, we've got it covered. Experience hassle-free, personalized care for a vibrant life.", ImageUrl = "~/Images/Health.png" },
                new Service { ID = 3, Name = "Mechanical", Description = "Enhance your devices with our swift services. From repairs to upgrades, we've got it covered. Experience hassle-free, expert solutions for optimal performance..", ImageUrl = "~/Images/Mechanical.png" },
                new Service { ID = 4, Name = "Electrical", Description = "Elevate your electrical well-being with our prompt services. From comprehensive assessments to expert solutions, we've got your electrical needs covered. Enjoy seamless, customized care for a powered-up and resilient system.", ImageUrl = "~/Images/Electrical.jpg" },
                new Service { ID = 5, Name = "Electronic", Description = "Revitalize your electronic systems with our efficient services. From diagnostics to tailored solutions, we've got your electronic requirements fully addressed. Experience a hassle-free journey to optimize and enhance your electronic devices for a seamlessly connected and empowered technological lifestyle.", ImageUrl = "~/Images/Electronic.jpg" }
                );



            modelBuilder.Entity<ServiceItem>().HasData(
                //Home
                new ServiceItem { ID = 1, Name = "Assembly", serviceID = 1, Description = "Streamline your home setup with our assembly service. From furniture to electronics, we've got the assembly covered. Enjoy the ease of a quick and expertly assembled home, leaving you with more time to relax and enjoy your space. Our efficient service ensures your items come together seamlessly, making your home functional and cozy in no time.", UrlImage = "~/Images/Home/Assembly.png" },
                new ServiceItem { ID = 2, Name = "Electrical Service", serviceID = 1, Description = "Revitalize your home's electricity with our expert services. From installations to repairs, we've got you covered. Experience the ease of a safer and more efficient home. Trust us for quick, reliable electrical services to brighten up your living space.", UrlImage = "~/Images/Home/Electrical Service.png" },
                new ServiceItem { ID = 3, Name = "General Handyman", serviceID = 1, Description = "Simplify your to-do list with our general handyman services. From small repairs to odd jobs, we've got the expertise to tackle a variety of tasks around your home. Enjoy the convenience of a skilled professional handling everything from fixing leaks to assembling furniture. Let us take care of the details, so you can relax and make the most of your time. With our reliable and efficient services, your home will be in top shape in no time.", UrlImage = "~/Images/Home/General Handyman.png" },
                new ServiceItem { ID = 4, Name = "Home Cleaning", serviceID = 1, Description = "Experience the luxury of a spotless home with our impeccable cleaning services. From meticulous dusting to thorough vacuuming, we take care of every detail to ensure your living space is fresh and inviting. Our dedicated team of professionals is committed to delivering a deep and comprehensive clean, leaving no corner untouched. Enjoy the convenience of a pristine home without the hassle. Let us transform your space into a sanctuary of cleanliness, providing you with the peace of mind and comfort you deserve.", UrlImage = "~/Images/Home/Home Cleaning.png" },
                new ServiceItem { ID = 5, Name = "Interior Painting", serviceID = 1, Description = "Transform your living space with our expert interior painting services. Our skilled team is committed to adding a splash of color and vibrancy to your home. From meticulous preparation to flawless execution, we ensure a smooth and professional paint job for your walls, ceilings, and trim. Choose from our wide range of quality paints and finishes to suit your style and preferences. Experience the joy of a freshly painted interior that not only enhances the aesthetics but also adds a sense of newness to your home. Let us bring your vision to life with our top-notch interior painting services.", UrlImage = "~/Images/Home/Interior Painting.png" },
                new ServiceItem { ID = 6, Name = "Moving ", serviceID = 1, Description = "Streamline your move with our hassle-free home moving service. We handle all aspects of your relocation, from careful packing to efficient transportation and unpacking. Our experienced team ensures a smooth transition to your new home, prioritizing the safety and security of your belongings. Sit back and relax while we take care of the logistics, making your move a stress-free experience. Choose our reliable and professional home moving service for a seamless transition to your new living space.", UrlImage = "~/Images/Home/Moving.png" },
                new ServiceItem { ID = 7, Name = "Plumbing ", serviceID = 1, Description = "Experience worry-free plumbing solutions with our expert services. From repairs to installations, our skilled plumbers are ready to tackle any plumbing issue in your home. We prioritize efficiency and reliability to ensure that your water systems, pipes, and fixtures are in optimal condition. Trust us to address leaks, clogs, and any other plumbing concerns with precision. Enjoy the convenience of a well-functioning plumbing system that keeps your home running smoothly. Choose our dedicated plumbing services for professional, prompt, and effective solutions, leaving you with peace of mind in your living space.", UrlImage = "~/Images/Home/Plumbing.png" },
                new ServiceItem { ID = 8, Name = "Smart Home", serviceID = 1, Description = "Upgrade your home with our smart solutions. From automated lighting to advanced security, we bring the latest technologies to your fingertips. Enjoy the convenience of a smarter, more efficient living space. Let us transform your home into a connected haven where innovation meets simplicity. Choose our smart home services for a modern, hassle-free lifestyle.", UrlImage = "~/Images/Home/Smart Home.png" },
                new ServiceItem { ID = 9, Name = "TV Mounting", serviceID = 1, Description = "Simplify your entertainment setup with our TV mounting service. Our skilled professionals ensure a secure and aesthetically pleasing installation, bringing your viewing experience to new heights. Experience the sleek and modern look of a wall-mounted TV without the hassle. Trust us to handle the details, from selecting the right mounting bracket to securely attaching your TV. Choose our efficient TV mounting service for a clean and polished home entertainment setup, allowing you to enjoy your favorite shows and movies in style.", UrlImage = "~/Images/Home/TV Mounting.png" },
                new ServiceItem { ID = 10, Name = "Window Treatments", serviceID = 1, Description = "Elevate your windows with our expert treatment services. Whether you prefer elegant curtains, stylish blinds, or functional shades, we provide customized solutions to enhance your space. Our skilled professionals ensure precise measurements and flawless installations for a polished and tailored look. Experience the perfect balance of privacy, natural light, and aesthetics with our window treatment services. Choose us for a seamless transformation that not only complements your decor but also adds a touch of sophistication to your living spaces", UrlImage = "~/Images/Home/Window Treatments.png" },

                //Health
                new ServiceItem { ID = 11, Name = "Caregiver support services", serviceID = 2, Description = "Ease your caregiving journey with our dedicated support services. From respite care to emotional assistance, we're here for you. Tailored to your unique needs, our services provide the help you require as you care for your loved ones. Experience peace of mind and compassionate support with our caregiver services.", UrlImage = "~/Images/Health/Caregiver support services (1).png" },
                new ServiceItem { ID = 12, Name = "Durable medical equipment (DME)", serviceID = 2, Description = "Improve your mobility with our durable medical equipment (DME) solutions. From wheelchairs to walking aids, we provide reliable devices tailored to your needs. Experience the convenience of quality equipment that enhances your daily life. Choose us for durable solutions that prioritize your well-being.", UrlImage = "~/Images/Health/Durable medical equipment (DME).png" },
                new ServiceItem { ID = 13, Name = "home health assessment", serviceID = 2, Description = "Gain insights into your health with our concise home health assessments. Tailored to your needs, our assessments provide a quick and accurate overview within the comfort of your home. Choose us for efficient and personalized insights to support your well-being.", UrlImage = "~/Images/Health/home health assessment.png" },
                new ServiceItem { ID = 14, Name = "home health care", serviceID = 2, Description = "Receive personalized care at home with our home health services. Our dedicated team of professionals brings medical assistance and support to your doorstep. Choose comfort and convenience for your well-being.", UrlImage = "~/Images/Health/home health care edit.png" },
                new ServiceItem { ID = 15, Name = "Hospice care", serviceID = 2, Description = "Experience compassionate end-of-life care with our hospice services. We prioritize comfort and support for both patients and families during this sensitive time. Choose our empathetic care to enhance the quality of life in a peaceful environment.", UrlImage = "~/Images/Health/Hospice care.png" },
                new ServiceItem { ID = 16, Name = "Medication management", serviceID = 2, Description = "Simplify your health routine with our medication management services. We offer organized and personalized solutions to ensure you take the right medication at the right time. Trust us to streamline your medication schedule for a hassle-free and effective approach to your health. Choose our services for a simplified and efficient way to manage your medications.", UrlImage = "~/Images/Health/Medication management.png" },
                new ServiceItem { ID = 17, Name = "Nutritional support services", serviceID = 2, Description = "Boost your well-being with our tailored nutritional support. Our expert guidance helps you achieve your health goals through personalized plans. Choose us for practical tips and insights, making nutrition simple and effective for you.", UrlImage = "~/Images/Health/Nutritional support services.png" },
                new ServiceItem { ID = 18, Name = "Palliative care at home", serviceID = 2, Description = "Receive compassionate palliative care at home. Our specialized services prioritize your comfort and quality of life. Choose dignified and personalized support for a peaceful and comforting experience.", UrlImage = "~/Images/Health/Palliative care at home (1).png" },
                new ServiceItem { ID = 19, Name = "Physical therapy at home", serviceID = 2, Description = "Get personalized healing at home with our physical therapy services. Our expert therapists bring rehabilitation to your doorstep, focusing on your specific needs. Choose the convenience of at-home care for improved mobility and well-being.", UrlImage = "~/Images/Health/Physical therapy at home.png" },
                new ServiceItem { ID = 20, Name = "Rehabilitation services at home", serviceID = 2, Description = "Experience rehab at home with our personalized services. Our experts bring tailored rehabilitation to your doorstep for enhanced well-being. Choose the convenience of at-home care for a focused approach to your recovery.", UrlImage = "~/Images/Health/Rehabilitation services at home.png" },
                new ServiceItem { ID = 21, Name = "Speech therapy at home", serviceID = 2, Description = "Enhance your communication skills at home with our personalized speech therapy. Our expert therapists bring tailored sessions to you, focusing on your specific needs. Choose the convenience of at-home care for effective and comfortable progress.", UrlImage = "~/Images/Health/Speech therapy at home.png" },
                new ServiceItem { ID = 22, Name = "telehealth services", serviceID = 2, Description = "Experience remote healthcare with our telehealth services. Connect with professionals from the comfort of your space. Choose convenient, virtual care for effective and personalized support.", UrlImage = "~/Images/Health/telehealth services.png" },

                //Mechanical

                new ServiceItem { ID = 23, Name = "Air Conditioning and Heating Repairs ", serviceID = 3, Description = "Keep your home cozy with our swift HVAC repairs. We fix air conditioning and heating issues promptly, ensuring your comfort year-round. Choose us for efficient and reliable solutions to maintain your ideal indoor climate.", UrlImage = "~/Images/Mechanical/Air Conditioning and Heating Repairs.png" },
                new ServiceItem { ID = 24, Name = "Brake Repairs ", serviceID = 3, Description = "Drive confidently with our swift brake repairs. Our skilled technicians prioritize your safety, delivering efficient solutions to keep your vehicle in top condition. Choose us for reliable brake repairs that ensure a smooth and secure driving experience.", UrlImage = "~/Images/Mechanical/Brake Repairs.png" },
                new ServiceItem { ID = 25, Name = "Diagnostic Services ", serviceID = 3, Description = "Pinpoint vehicle issues with our precise diagnostic services. Our skilled mechanics use advanced technology for efficient problem identification. Trust us for accurate insights, streamlining repairs and keeping your vehicle running smoothly.", UrlImage = "~/Images/Mechanical/Diagnostic Services.png" },
                new ServiceItem { ID = 26, Name = "Electrical Problems ", serviceID = 3, Description = "Address car electrical issues promptly with our skilled mechanics. Trust us for fast and reliable solutions to ensure your vehicle's electrical system is running smoothly. Choose expert repairs for your automotive electrical problems, bringing you peace of mind on the road.", UrlImage = "~/Images/Mechanical/Electrical Problems.png" },
                new ServiceItem { ID = 27, Name = "Engine Trouble ", serviceID = 3, Description = "Resolve engine issues with our skilled mechanics for efficient and reliable solutions. Choose us for expert repairs to ensure optimal performance and a smoothly running engine.", UrlImage = "~/Images/Mechanical/Engine Trouble.png" },
                new ServiceItem { ID = 28, Name = "Fluid Leaks ", serviceID = 3, Description = "Fix fluid leaks with our expert solutions. Our skilled technicians swiftly identify and repair issues for a smoothly running vehicle. Choose us for prompt and precise resolution, ensuring your vehicle stays in top condition.", UrlImage = "~/Images/Mechanical/Fluid Leaks.png" },
                new ServiceItem { ID = 29, Name = "Routine Maintenance ", serviceID = 3, Description = "Maintain your vehicle's health with our reliable routine maintenance. Our skilled technicians provide efficient checks for optimal performance. Choose hassle-free maintenance for peace of mind on the road. Trust us for expert service to keep your vehicle running smoothly.", UrlImage = "~/Images/Mechanical/Routine Maintenance.png" },
                new ServiceItem { ID = 30, Name = "Suspension and Steering Repairs ", serviceID = 3, Description = "Ensure a smooth ride with our expert suspension and steering repairs. Our skilled technicians specialize in efficient solutions to keep your vehicle handling with precision. Choose us for reliable repairs that prioritize your safety and restore optimal driving performanc", UrlImage = "~/Images/Mechanical/Suspension and Steering Repairs.png" },
                new ServiceItem { ID = 31, Name = "Tire Services ", serviceID = 3, Description = "Keep your journey smooth with our expert tire services. Our skilled technicians offer efficient solutions for tire repairs, rotations, and replacements. Choose us for reliable and prompt tire services, ensuring your safety and the longevity of your tires.", UrlImage = "~/Images/Mechanical/Tire Services.png" },
                new ServiceItem { ID = 32, Name = "Transmission Concerns ", serviceID = 3, Description = "Resolve transmission concerns efficiently with our expert services. Our skilled technicians specialize in diagnosing and repairing transmission issues to keep your vehicle running smoothly. Choose us for reliable and prompt solutions, ensuring optimal performance and longevity for your transmission", UrlImage = "~/Images/Mechanical/Transmission Concerns.png" },

                // Electrical

                new ServiceItem { ID = 33, Name = "Emergency Electrical Services", serviceID = 4, Description = "Count on us for prompt Emergency Electrical Services. Our skilled electricians are ready to address urgent electrical issues, ensuring the safety and functionality of your home or business. Trust us for reliable and efficient solutions to restore power and resolve electrical emergencies swiftly. Choose our Emergency Electrical Services for peace of mind during critical situations.", UrlImage = "~/Images/Electrical/Emergency Electrical Services.png" },
                new ServiceItem { ID = 34, Name = "Energy-Efficient Solutions", serviceID = 4, Description = "Enhance energy efficiency with our expert solutions. Our professionals specialize in tailored strategies for cost-effective and sustainable results. Choose us for streamlined energy solutions that benefit your home or business.", UrlImage = "~/Images/Electrical/Energy-Efficient Solutions.png" },
                new ServiceItem { ID = 35, Name = "Generator Installation and Repair", serviceID = 4, Description = "Ensure reliable power with our expert Generator Installation and Repair services. Our skilled technicians specialize in efficient installations and timely repairs to keep your generator ready for any power needs. Choose us for reliable solutions that prioritize seamless operation and backup power when you need it most.", UrlImage = "~/Images/Electrical/Generator Installation and Repair.png" },
                new ServiceItem { ID = 36, Name = "Installation Services", serviceID = 4, Description = "Experience seamless installations with our expert services. Our skilled professionals specialize in efficient setup to meet your specific needs. Choose us for reliable and hassle-free installation solutions tailored to enhance your systems and equipment.", UrlImage = "~/Images/Electrical/Installation Services.png" },
                new ServiceItem { ID = 37, Name = "Outdoor Lighting", serviceID = 4, Description = "Brighten your outdoors with our expert Outdoor Lighting. Our skilled professionals ensure efficient installation and maintenance for enhanced aesthetics and security. Choose us for reliable solutions that illuminate your outdoor spaces with style.", UrlImage = "~/Images/Electrical/Outdoor Lighting copy.png" },
                new ServiceItem { ID = 38, Name = "Panel Upgrades", serviceID = 4, Description = "Elevate your power capacity with our Panel Upgrades. Our skilled electricians efficiently enhance your electrical system for modern demands. Choose us for reliable solutions that ensure a more robust and efficient power supply.", UrlImage = "~/Images/Electrical/Panel Upgrades.png" },
                new ServiceItem { ID = 39, Name = "Security System Wiring", serviceID = 4, Description = "Secure your space with our expert Security System Wiring services. Our skilled technicians specialize in efficient and discreet wiring installations to ensure the seamless operation of your security systems. Choose us for reliable solutions that prioritize the safety and protection of your home or business. Enhance your security infrastructure with our expert Security System Wiring services.", UrlImage = "~/Images/Electrical/Security System Wiring.png" },
                new ServiceItem { ID = 40, Name = "Smart Home Electrical Integration", serviceID = 4, Description = "\r\nUpgrade to a smarter home with our expert Smart Home Integration. Our skilled technicians ensure seamless installations for enhanced convenience and connectivity. Choose us for reliable solutions that bring intelligence to every corner of your living space.", UrlImage = "~/Images/Electrical/Smart Home Electrical Integration.png" },
                new ServiceItem { ID = 41, Name = "Wiring and Rewiring", serviceID = 4, Description = "Ensure efficient electrical connectivity with our expert Wiring and Rewiring services. Our skilled technicians specialize in reliable installations and rewiring to meet the electrical needs of your home or business. Choose us for seamless solutions that prioritize safety, efficiency, and optimal functionality. Trust our experts to handle your wiring and rewiring needs with precision and care.", UrlImage = "~/Images/Electrical/Wiring and Rewiring.png" },

                //electronic

                new ServiceItem { ID = 42, Name = "Battery Replacements", serviceID = 5, Description = "Keep your electronic devices powered with our expert Battery Replacement services. Our skilled technicians specialize in swift and reliable battery replacements for various gadgets and devices. Choose us for hassle-free solutions that ensure your electronics stay powered and functional. Trust our experts to provide timely and efficient battery replacements to keep your electronic devices running smoothly.", UrlImage = "~/Images/Electronic/Battery Replacements.png" },
                new ServiceItem { ID = 43, Name = "Device Troubleshooting", serviceID = 5, Description = "Resolve device issues with our expert Troubleshooting services. Our skilled technicians swiftly identify and fix problems with various devices. Choose us for reliable solutions to ensure optimal device performance. Trust our experts for efficient troubleshooting that keeps your gadgets running smoothly.", UrlImage = "~/Images/Electronic/Device Troubleshooting.png" },
                new ServiceItem { ID = 44, Name = "Device Upgrades", serviceID = 5, Description = "Elevate your devices with our expert Upgrade services. Our skilled technicians specialize in enhancing the performance and features of your gadgets. Choose us for reliable and efficient upgrades that bring your devices to the next level. Trust our experts to provide seamless and customized solutions to optimize the functionality of your electronic equipment.", UrlImage = "~/Images/Electronic/Device Upgrades.png" },
                new ServiceItem { ID = 45, Name = "Gaming Console Repairs", serviceID = 5, Description = "Revive your gaming experience with our expert Gaming Console Repair services. Our skilled technicians specialize in diagnosing and fixing issues to get your console back in action. Choose us for reliable solutions that prioritize a swift and efficient repair process. Trust our experts to provide effective Gaming Console Repairs, ensuring you can resume your gaming adventures without disruption.", UrlImage = "~/Images/Electronic/Gaming Console Repairs.png" },
                new ServiceItem { ID = 46, Name = "Network Connectivity Issues", serviceID = 5, Description = "Tackle network connectivity issues with our expert solutions. Our skilled technicians specialize in diagnosing and resolving problems to ensure seamless connectivity. Choose us for reliable solutions that prioritize a swift and efficient resolution to your network issues. Trust our experts to provide effective troubleshooting, ensuring your devices stay connected and operational.", UrlImage = "~/Images/Electronic/Network Connectivity Issues.png" },
                new ServiceItem { ID = 47, Name = "Screen Repairs", serviceID = 5, Description = "Revitalize your screens with our expert Screen Repair services. Our skilled technicians efficiently address screen issues on various devices. Choose us for reliable solutions that prioritize swift and precise repairs. Trust our experts to bring your screens back to life for an enhanced viewing experience.", UrlImage = "~/Images/Electronic/Screen Repairs.png" },
                new ServiceItem { ID = 48, Name = "Software Glitches", serviceID = 5, Description = "Resolve software glitches with our expert solutions. Our skilled technicians specialize in identifying and fixing software issues on various devices. Choose us for reliable solutions that prioritize swift and efficient resolution to software glitches. Trust our experts to provide effective troubleshooting, ensuring your devices run smoothly and efficiently.", UrlImage = "~/Images/Electronic/Software Glitches.png" },
                new ServiceItem { ID = 49, Name = "Virus and Malware Removal", serviceID = 5, Description = "Ensure device security with our Virus and Malware Removal. Our skilled technicians swiftly eliminate threats for safe and efficient operation. Choose us for reliable solutions that prioritize swift removal of viruses and malware. Trust our experts for effective security measures to keep your devices safe.", UrlImage = "~/Images/Electronic/Virus and Malware Removal.png" }
                );

            /// providers

            modelBuilder.Entity<Provider>().HasData(

              /// home 1
              new Provider
              {
                  ID = 1,
                  Name = "provider1",
                  Email = "provider1@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 2",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-1.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 1
              },
              new Provider
              {
                  ID = 2,
                  Name = "provider2",
                  Email = "provider2@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 2",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 1
              },

              // home 2
              new Provider
              {
                  ID = 3,
                  Name = "provider3",
                  Email = "provider3@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 3",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-3.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 2
              },
              new Provider
              {
                  ID = 4,
                  Name = "provider4",
                  Email = "provider4@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 4",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 2
              },

              // home 3

              new Provider
              {
                  ID = 5,
                  Name = "provider5",
                  Email = "provider5@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 5",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 3
              },
              new Provider
              {
                  ID = 6,
                  Name = "provider6",
                  Email = "provider6@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 6",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-3.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 3
              },

              // health 1
              new Provider
              {
                  ID = 7,
                  Name = "provider7",
                  Email = "provider7@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 7",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 11
              },
              new Provider
              {
                  ID = 8,
                  Name = "provider8",
                  Email = "provider8@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 8",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-3.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 11
              },

              // health 2
              new Provider
              {
                  ID = 9,
                  Name = "provider9",
                  Email = "provider9@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 9",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-1.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 12
              },
              new Provider
              {
                  ID = 10,
                  Name = "provider10",
                  Email = "provider10@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 10",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 12
              },

              //health 3

              new Provider
              {
                  ID = 11,
                  Name = "provider11",
                  Email = "provider11@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 11",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-1.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 13
              },
              new Provider
              {
                  ID = 12,
                  Name = "provider12",
                  Email = "provider12@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 12",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 13
              },

              //mechanical 1
              new Provider
              {
                  ID = 13,
                  Name = "provider13",
                  Email = "provider13@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 13",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-1.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 23
              },
              new Provider
              {
                  ID = 14,
                  Name = "provider14",
                  Email = "provider14@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 14",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 23
              },

              // mechanic 2
              new Provider
              {
                  ID = 15,
                  Name = "provider15",
                  Email = "provider15@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 15",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-1.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 24
              },
              new Provider
              {
                  ID = 16,
                  Name = "provider16",
                  Email = "provider16@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 16",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 24
              },

              // mechanic 3
              new Provider
              {
                  ID = 17,
                  Name = "provider17",
                  Email = "provider17@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 17",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 25
              },
              new Provider
              {
                  ID = 18,
                  Name = "provider18",
                  Email = "provider18@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 18",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-1.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 25
              },

              //electric 1

              new Provider
              {
                  ID = 19,
                  Name = "provider19",
                  Email = "provider19@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 19",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-1.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 33
              },
              new Provider
              {
                  ID = 20,
                  Name = "provider20",
                  Email = "provider20@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 20",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 33
              },


              //electric 2

              new Provider
              {
                  ID = 21,
                  Name = "provider21",
                  Email = "provider21@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 21",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-3.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 34
              },
              new Provider
              {
                  ID = 22,
                  Name = "provider22",
                  Email = "provider22@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 22",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 34
              },

               // electric 3

               new Provider
               {
                   ID = 23,
                   Name = "provider23",
                   Email = "provider23@provider.com",
                   Password = "12",
                   Phone = 0777848419,
                   Position = "position 23",
                   City = "Irbid",
                   Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                   ImageUrl = "~/Customer/team-1.jpg",
                   Role = Role.Provider,
                   SubscriptionStartDate = DateTime.Now,
                   SubscriptionEndDate = DateTime.Now.AddMonths(2),
                   IsActive = true,
                   IsSubscriptionActive = true,
                   serviceID = 35
               },
              new Provider
              {
                  ID = 24,
                  Name = "provider24",
                  Email = "provider24@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 24",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 35
              },

              // electronic 1

              new Provider
              {
                  ID = 25,
                  Name = "provider25",
                  Email = "provider25@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 25",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 42
              },
              new Provider
              {
                  ID = 26,
                  Name = "provider26",
                  Email = "provider26@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 26",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-3.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 42
              },

              // electronic 2

              new Provider
              {
                  ID = 27,
                  Name = "provider27",
                  Email = "provider27@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 27",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-3.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 43
              },
              new Provider
              {
                  ID = 28,
                  Name = "provider28",
                  Email = "provider28@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 28",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 43
              },

              // electronic 3

              new Provider
              {
                  ID = 29,
                  Name = "provider29",
                  Email = "provider29@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 29",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 44
              },
              new Provider
              {
                  ID = 30,
                  Name = "provider30",
                  Email = "provider30@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 30",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now.AddMonths(2),
                  IsActive = true,
                  IsSubscriptionActive = true,
                  serviceID = 44
              },

              /// not subscriptionActive
              /// 

              new Provider
              {
                  ID = 31,
                  Name = "provider31",
                  Email = "provider31@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 31",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-4.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now,
                  IsActive = true,
                  IsSubscriptionActive = false,
                  serviceID = 1
              },
              new Provider
              {
                  ID = 32,
                  Name = "provider32",
                  Email = "provider32@provider.com",
                  Password = "12",
                  Phone = 0777848419,
                  Position = "position 32",
                  City = "Irbid",
                  Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                  ImageUrl = "~/Customer/team-2.jpg",
                  Role = Role.Provider,
                  SubscriptionStartDate = DateTime.Now,
                  SubscriptionEndDate = DateTime.Now,
                  IsActive = false,
                  IsSubscriptionActive = false,
                  serviceID = 1
              }
              );

            ///// customer and admin

            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   ID = 1,
                   Name = "Abedelhameed Alshorafa",
                   Email = "abed@admin.com",
                   Password = "12",
                   Phone = 0777848419,
                   City = "Irbid",
                   Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                   ImageUrl = "~/Images/0708f78a-44fa-417b-8804-6e993de3f51fdf.png",
                   Role = Role.Admin
               },
               new Customer
               {
                   ID = 2,
                   Name = "Abedelhameed Alshorafa",
                   Email = "abed@customer.com",
                   Password = "12",
                   Phone = 0777848419,
                   City = "Irbid",
                   Location = "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu",
                   ImageUrl = "~/Images/5ca3e71a-bf4c-4f55-84dc-1913ff189962RMI_8341.JPG",
                   Role = Role.Customer
               }
               );


            //// feedbacks for providers
            ///
            ///"Prompt and Reliable"
            //            "Efficient Service"
            //"Exceptional Care"
            //"Excellent Work"
            //"Professional Support"
            //"Timely Solutions"
            //"Outstanding Performance"
            //"Top-notch Service"
            //"Reliable Experts"
            //"Quality Workmanship
            modelBuilder.Entity<FeedbackForProvider>().HasData(
                // provider 1

                new FeedbackForProvider { ID = 1, Text = "Prompt and Reliable", customerID = 2, providerID = 1, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 2, Text = "Exceptional Care", customerID = 2, providerID = 1, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 3, Text = "Timely Solutions", customerID = 2, providerID = 1, Status = feedbackStatus.Accepted },

                // provider 2

                new FeedbackForProvider { ID = 4, Text = "Excellent Work", customerID = 2, providerID = 2, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 5, Text = "Exceptional Care", customerID = 2, providerID = 2, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 6, Text = "Top-notch Service", customerID = 2, providerID = 2, Status = feedbackStatus.Accepted },

                // provider 3

                new FeedbackForProvider { ID = 7, Text = "Top-notch Service", customerID = 2, providerID = 3, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 8, Text = "Exceptional Care", customerID = 2, providerID = 3, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 9, Text = "Timely Solutions", customerID = 2, providerID = 3, Status = feedbackStatus.Accepted },

                // provider 4

                new FeedbackForProvider { ID = 10, Text = "Professional Support", customerID = 2, providerID = 4, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 11, Text = "Exceptional Care", customerID = 2, providerID = 4, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 12, Text = "Timely Solutions", customerID = 2, providerID = 4, Status = feedbackStatus.Accepted },


                // provider 5

                new FeedbackForProvider { ID = 13, Text = "Outstanding Performance", customerID = 2, providerID = 5, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 14, Text = "Exceptional Care", customerID = 2, providerID = 5, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 15, Text = "Timely Solutions", customerID = 2, providerID = 5, Status = feedbackStatus.Accepted },

                // provider 6

                new FeedbackForProvider { ID = 16, Text = "Professional Support", customerID = 2, providerID = 6, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 17, Text = "Outstanding Performance", customerID = 2, providerID = 6, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 18, Text = "Timely Solutions", customerID = 2, providerID = 6, Status = feedbackStatus.Accepted },

                // provider 7

                new FeedbackForProvider { ID = 19, Text = "Outstanding Performance", customerID = 2, providerID = 7, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 20, Text = "Exceptional Care", customerID = 2, providerID = 7, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 21, Text = "Timely Solutions", customerID = 2, providerID = 7, Status = feedbackStatus.Accepted },

                // provider 8

                new FeedbackForProvider { ID = 22, Text = "Outstanding Performance", customerID = 2, providerID = 8, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 23, Text = "Exceptional Care", customerID = 2, providerID = 8, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 24, Text = "Timely Solutions", customerID = 2, providerID = 8, Status = feedbackStatus.Accepted },

                // provider 9

                new FeedbackForProvider { ID = 25, Text = "Professional Support", customerID = 2, providerID = 9, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 26, Text = "Exceptional Care", customerID = 2, providerID = 9, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 27, Text = "Timely Solutions", customerID = 2, providerID = 9, Status = feedbackStatus.Accepted },

                // provider 10

                new FeedbackForProvider { ID = 28, Text = "Outstanding Performance", customerID = 2, providerID = 10, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 29, Text = "Exceptional Care", customerID = 2, providerID = 10, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 30, Text = "Timely Solutions", customerID = 2, providerID = 10, Status = feedbackStatus.Accepted },


                // provider 11

                new FeedbackForProvider { ID = 31, Text = "Professional Support", customerID = 2, providerID = 11, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 32, Text = "Exceptional Care", customerID = 2, providerID = 11, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 33, Text = "Timely Solutions", customerID = 2, providerID = 11, Status = feedbackStatus.Accepted },


                // provider 12

                new FeedbackForProvider { ID = 34, Text = "Outstanding Performance", customerID = 2, providerID = 12, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 35, Text = "Exceptional Care", customerID = 2, providerID = 12, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 36, Text = "Timely Solutions", customerID = 2, providerID = 12, Status = feedbackStatus.Accepted },


                // provider 13

                new FeedbackForProvider { ID = 37, Text = "Professional Support", customerID = 2, providerID = 13, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 38, Text = "Exceptional Care", customerID = 2, providerID = 13, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 39, Text = "Timely Solutions", customerID = 2, providerID = 13, Status = feedbackStatus.Accepted },


                // provider 14

                new FeedbackForProvider { ID = 40, Text = "Exceptional Care", customerID = 2, providerID = 14, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 41, Text = "Professional Support", customerID = 2, providerID = 14, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 42, Text = "Timely Solutions", customerID = 2, providerID = 14, Status = feedbackStatus.Accepted },


                // provider 15

                new FeedbackForProvider { ID = 43, Text = "Professional Support", customerID = 2, providerID = 15, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 45, Text = "Exceptional Care", customerID = 2, providerID = 15, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 46, Text = "Timely Solutions", customerID = 2, providerID = 15, Status = feedbackStatus.Accepted },

                // provider 16

                new FeedbackForProvider { ID = 47, Text = "Exceptional Care", customerID = 2, providerID = 16, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 48, Text = "Professional Support", customerID = 2, providerID = 16, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 49, Text = "Timely Solutions", customerID = 2, providerID = 16, Status = feedbackStatus.Accepted },


                // provider 17

                new FeedbackForProvider { ID = 50, Text = "Professional Support", customerID = 2, providerID = 17, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 51, Text = "Exceptional Care", customerID = 2, providerID = 17, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 52, Text = "Timely Solutions", customerID = 2, providerID = 17, Status = feedbackStatus.Accepted },


                // provider 18

                new FeedbackForProvider { ID = 53, Text = "Professional Support", customerID = 2, providerID = 18, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 54, Text = "Exceptional Care", customerID = 2, providerID = 18, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 56, Text = "Timely Solutions", customerID = 2, providerID = 18, Status = feedbackStatus.Accepted },


                // provider 19

                new FeedbackForProvider { ID = 57, Text = "Professional Support", customerID = 2, providerID = 19, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 58, Text = "Exceptional Care", customerID = 2, providerID = 19, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 59, Text = "Timely Solutions", customerID = 2, providerID = 19, Status = feedbackStatus.Accepted },


                // provider 20

                new FeedbackForProvider { ID = 60, Text = "Professional Support", customerID = 2, providerID = 20, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 61, Text = "Exceptional Care", customerID = 2, providerID = 20, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 62, Text = "Timely Solutions", customerID = 2, providerID = 20, Status = feedbackStatus.Accepted },


                // provider 21

                new FeedbackForProvider { ID = 63, Text = "Professional Support", customerID = 2, providerID = 21, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 64, Text = "Exceptional Care", customerID = 2, providerID = 21, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 65, Text = "Timely Solutions", customerID = 2, providerID = 21, Status = feedbackStatus.Accepted },


                // provider 22

                new FeedbackForProvider { ID = 66, Text = "Professional Support", customerID = 2, providerID = 22, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 67, Text = "Exceptional Care", customerID = 2, providerID = 22, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 68, Text = "Timely Solutions", customerID = 2, providerID = 22, Status = feedbackStatus.Accepted },


                // provider 23

                new FeedbackForProvider { ID = 69, Text = "Professional Support", customerID = 2, providerID = 23, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 70, Text = "Exceptional Care", customerID = 2, providerID = 23, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 71, Text = "Timely Solutions", customerID = 2, providerID = 23, Status = feedbackStatus.Accepted },


                // provider 24

                new FeedbackForProvider { ID = 72, Text = "Professional Support", customerID = 2, providerID = 24, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 73, Text = "Exceptional Care", customerID = 2, providerID = 24, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 74, Text = "Timely Solutions", customerID = 2, providerID = 24, Status = feedbackStatus.Accepted },

                // provider 25

                new FeedbackForProvider { ID = 75, Text = "Professional Support", customerID = 2, providerID = 25, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 76, Text = "Exceptional Care", customerID = 2, providerID = 25, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 77, Text = "Timely Solutions", customerID = 2, providerID = 25, Status = feedbackStatus.Accepted },

                // provider 26

                new FeedbackForProvider { ID = 78, Text = "Professional Support", customerID = 2, providerID = 26, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 79, Text = "Exceptional Care", customerID = 2, providerID = 26, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 80, Text = "Timely Solutions", customerID = 2, providerID = 26, Status = feedbackStatus.Accepted },


                // provider 27

                new FeedbackForProvider { ID = 81, Text = "Professional Support", customerID = 2, providerID = 27, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 82, Text = "Exceptional Care", customerID = 2, providerID = 27, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 83, Text = "Timely Solutions", customerID = 2, providerID = 27, Status = feedbackStatus.Accepted },


                // provider 28

                new FeedbackForProvider { ID = 84, Text = "Professional Support", customerID = 2, providerID = 28, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 85, Text = "Exceptional Care", customerID = 2, providerID = 28, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 86, Text = "Timely Solutions", customerID = 2, providerID = 28, Status = feedbackStatus.Accepted },


                // provider 29

                new FeedbackForProvider { ID = 87, Text = "Professional Support", customerID = 2, providerID = 29, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 88, Text = "Exceptional Care", customerID = 2, providerID = 29, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 89, Text = "Timely Solutions", customerID = 2, providerID = 29, Status = feedbackStatus.Accepted },

                // provider 30

                new FeedbackForProvider { ID = 90, Text = "Professional Support", customerID = 2, providerID = 30, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 91, Text = "Exceptional Care", customerID = 2, providerID = 30, Status = feedbackStatus.Accepted },
                new FeedbackForProvider { ID = 92, Text = "Timely Solutions", customerID = 2, providerID = 30, Status = feedbackStatus.Accepted }


            );


            modelBuilder.Entity<FeedbackForWeb>().HasData(
                new FeedbackForWeb { ID = 1, Text = "Great service!", Status = feedbackStatus.Accepted, customerID = 2 },
                new FeedbackForWeb { ID = 2, Text = "Had an issue, but resolved quickly.", Status = feedbackStatus.Accepted, customerID = 2 },
                new FeedbackForWeb { ID = 3, Text = "Product was damaged.", Status = feedbackStatus.Accepted, customerID = 2 },
                new FeedbackForWeb { ID = 4, Text = "Fast shipping, good quality.", Status = feedbackStatus.Accepted, customerID = 2 },
                new FeedbackForWeb { ID = 5, Text = "Easy returns process.", Status = feedbackStatus.Accepted, customerID = 2 }

                );

            modelBuilder.Entity<Payment>().HasData(
                new Payment { ID = 1, cardNo = "12", Password = "12" },
                new Payment { ID = 2, cardNo = "123", Password = "123" }
                );
        }
    }
}
