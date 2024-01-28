using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServiceProvider.Migrations
{
    /// <inheritdoc />
    public partial class lastMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ForDelete",
                table: "customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "ID", "City", "Email", "ForDelete", "ImageUrl", "Location", "Name", "Password", "Phone", "Role" },
                values: new object[,]
                {
                    { 1, "Irbid", "abed@admin.com", false, "~/Images/0708f78a-44fa-417b-8804-6e993de3f51fdf.png", "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", "Abedelhameed Alshorafa", "12", 777848419, 0 },
                    { 2, "Irbid", "abed@customer.com", false, "~/Images/5ca3e71a-bf4c-4f55-84dc-1913ff189962RMI_8341.JPG", "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", "Abedelhameed Alshorafa", "12", 777848419, 2 }
                });

            migrationBuilder.InsertData(
                table: "payments",
                columns: new[] { "ID", "Password", "cardNo" },
                values: new object[,]
                {
                    { 1, "12", "12" },
                    { 2, "123", "123" }
                });

            migrationBuilder.InsertData(
                table: "services",
                columns: new[] { "ID", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Revitalize your home with our quick and efficient services. From cleaning to repairs, we've got it handled. Enjoy a hassle-free, comfortable living space with our expert touch.", "~/Images/Home.png", "Home" },
                    { 2, "Boost your health with our swift services. From check-ups to treatments, we've got it covered. Experience hassle-free, personalized care for a vibrant life.", "~/Images/Health.png", "Health" },
                    { 3, "Enhance your devices with our swift services. From repairs to upgrades, we've got it covered. Experience hassle-free, expert solutions for optimal performance..", "~/Images/Mechanical.png", "Mechanical" },
                    { 4, "Elevate your electrical well-being with our prompt services. From comprehensive assessments to expert solutions, we've got your electrical needs covered. Enjoy seamless, customized care for a powered-up and resilient system.", "~/Images/Electrical.jpg", "Electrical" },
                    { 5, "Revitalize your electronic systems with our efficient services. From diagnostics to tailored solutions, we've got your electronic requirements fully addressed. Experience a hassle-free journey to optimize and enhance your electronic devices for a seamlessly connected and empowered technological lifestyle.", "~/Images/Electronic.jpg", "Electronic" }
                });

            migrationBuilder.InsertData(
                table: "feedbackForWebs",
                columns: new[] { "ID", "Rating", "Status", "Text", "customerID" },
                values: new object[,]
                {
                    { 1, 0.0, 1, "Great service!", 2 },
                    { 2, 0.0, 1, "Had an issue, but resolved quickly.", 2 },
                    { 3, 0.0, 1, "Product was damaged.", 2 },
                    { 4, 0.0, 1, "Fast shipping, good quality.", 2 },
                    { 5, 0.0, 1, "Easy returns process.", 2 }
                });

            migrationBuilder.InsertData(
                table: "serviceItems",
                columns: new[] { "ID", "Description", "Name", "UrlImage", "serviceID" },
                values: new object[,]
                {
                    { 1, "Streamline your home setup with our assembly service. From furniture to electronics, we've got the assembly covered. Enjoy the ease of a quick and expertly assembled home, leaving you with more time to relax and enjoy your space. Our efficient service ensures your items come together seamlessly, making your home functional and cozy in no time.", "Assembly", "~/Images/Home/Assembly.png", 1 },
                    { 2, "Revitalize your home's electricity with our expert services. From installations to repairs, we've got you covered. Experience the ease of a safer and more efficient home. Trust us for quick, reliable electrical services to brighten up your living space.", "Electrical Service", "~/Images/Home/Electrical Service.png", 1 },
                    { 3, "Simplify your to-do list with our general handyman services. From small repairs to odd jobs, we've got the expertise to tackle a variety of tasks around your home. Enjoy the convenience of a skilled professional handling everything from fixing leaks to assembling furniture. Let us take care of the details, so you can relax and make the most of your time. With our reliable and efficient services, your home will be in top shape in no time.", "General Handyman", "~/Images/Home/General Handyman.png", 1 },
                    { 4, "Experience the luxury of a spotless home with our impeccable cleaning services. From meticulous dusting to thorough vacuuming, we take care of every detail to ensure your living space is fresh and inviting. Our dedicated team of professionals is committed to delivering a deep and comprehensive clean, leaving no corner untouched. Enjoy the convenience of a pristine home without the hassle. Let us transform your space into a sanctuary of cleanliness, providing you with the peace of mind and comfort you deserve.", "Home Cleaning", "~/Images/Home/Home Cleaning.png", 1 },
                    { 5, "Transform your living space with our expert interior painting services. Our skilled team is committed to adding a splash of color and vibrancy to your home. From meticulous preparation to flawless execution, we ensure a smooth and professional paint job for your walls, ceilings, and trim. Choose from our wide range of quality paints and finishes to suit your style and preferences. Experience the joy of a freshly painted interior that not only enhances the aesthetics but also adds a sense of newness to your home. Let us bring your vision to life with our top-notch interior painting services.", "Interior Painting", "~/Images/Home/Interior Painting.png", 1 },
                    { 6, "Streamline your move with our hassle-free home moving service. We handle all aspects of your relocation, from careful packing to efficient transportation and unpacking. Our experienced team ensures a smooth transition to your new home, prioritizing the safety and security of your belongings. Sit back and relax while we take care of the logistics, making your move a stress-free experience. Choose our reliable and professional home moving service for a seamless transition to your new living space.", "Moving ", "~/Images/Home/Moving.png", 1 },
                    { 7, "Experience worry-free plumbing solutions with our expert services. From repairs to installations, our skilled plumbers are ready to tackle any plumbing issue in your home. We prioritize efficiency and reliability to ensure that your water systems, pipes, and fixtures are in optimal condition. Trust us to address leaks, clogs, and any other plumbing concerns with precision. Enjoy the convenience of a well-functioning plumbing system that keeps your home running smoothly. Choose our dedicated plumbing services for professional, prompt, and effective solutions, leaving you with peace of mind in your living space.", "Plumbing ", "~/Images/Home/Plumbing.png", 1 },
                    { 8, "Upgrade your home with our smart solutions. From automated lighting to advanced security, we bring the latest technologies to your fingertips. Enjoy the convenience of a smarter, more efficient living space. Let us transform your home into a connected haven where innovation meets simplicity. Choose our smart home services for a modern, hassle-free lifestyle.", "Smart Home", "~/Images/Home/Smart Home.png", 1 },
                    { 9, "Simplify your entertainment setup with our TV mounting service. Our skilled professionals ensure a secure and aesthetically pleasing installation, bringing your viewing experience to new heights. Experience the sleek and modern look of a wall-mounted TV without the hassle. Trust us to handle the details, from selecting the right mounting bracket to securely attaching your TV. Choose our efficient TV mounting service for a clean and polished home entertainment setup, allowing you to enjoy your favorite shows and movies in style.", "TV Mounting", "~/Images/Home/TV Mounting.png", 1 },
                    { 10, "Elevate your windows with our expert treatment services. Whether you prefer elegant curtains, stylish blinds, or functional shades, we provide customized solutions to enhance your space. Our skilled professionals ensure precise measurements and flawless installations for a polished and tailored look. Experience the perfect balance of privacy, natural light, and aesthetics with our window treatment services. Choose us for a seamless transformation that not only complements your decor but also adds a touch of sophistication to your living spaces", "Window Treatments", "~/Images/Home/Window Treatments.png", 1 },
                    { 11, "Ease your caregiving journey with our dedicated support services. From respite care to emotional assistance, we're here for you. Tailored to your unique needs, our services provide the help you require as you care for your loved ones. Experience peace of mind and compassionate support with our caregiver services.", "Caregiver support services", "~/Images/Health/Caregiver support services (1).png", 2 },
                    { 12, "Improve your mobility with our durable medical equipment (DME) solutions. From wheelchairs to walking aids, we provide reliable devices tailored to your needs. Experience the convenience of quality equipment that enhances your daily life. Choose us for durable solutions that prioritize your well-being.", "Durable medical equipment (DME)", "~/Images/Health/Durable medical equipment (DME).png", 2 },
                    { 13, "Gain insights into your health with our concise home health assessments. Tailored to your needs, our assessments provide a quick and accurate overview within the comfort of your home. Choose us for efficient and personalized insights to support your well-being.", "home health assessment", "~/Images/Health/home health assessment.png", 2 },
                    { 14, "Receive personalized care at home with our home health services. Our dedicated team of professionals brings medical assistance and support to your doorstep. Choose comfort and convenience for your well-being.", "home health care", "~/Images/Health/home health care edit.png", 2 },
                    { 15, "Experience compassionate end-of-life care with our hospice services. We prioritize comfort and support for both patients and families during this sensitive time. Choose our empathetic care to enhance the quality of life in a peaceful environment.", "Hospice care", "~/Images/Health/Hospice care.png", 2 },
                    { 16, "Simplify your health routine with our medication management services. We offer organized and personalized solutions to ensure you take the right medication at the right time. Trust us to streamline your medication schedule for a hassle-free and effective approach to your health. Choose our services for a simplified and efficient way to manage your medications.", "Medication management", "~/Images/Health/Medication management.png", 2 },
                    { 17, "Boost your well-being with our tailored nutritional support. Our expert guidance helps you achieve your health goals through personalized plans. Choose us for practical tips and insights, making nutrition simple and effective for you.", "Nutritional support services", "~/Images/Health/Nutritional support services.png", 2 },
                    { 18, "Receive compassionate palliative care at home. Our specialized services prioritize your comfort and quality of life. Choose dignified and personalized support for a peaceful and comforting experience.", "Palliative care at home", "~/Images/Health/Palliative care at home (1).png", 2 },
                    { 19, "Get personalized healing at home with our physical therapy services. Our expert therapists bring rehabilitation to your doorstep, focusing on your specific needs. Choose the convenience of at-home care for improved mobility and well-being.", "Physical therapy at home", "~/Images/Health/Physical therapy at home.png", 2 },
                    { 20, "Experience rehab at home with our personalized services. Our experts bring tailored rehabilitation to your doorstep for enhanced well-being. Choose the convenience of at-home care for a focused approach to your recovery.", "Rehabilitation services at home", "~/Images/Health/Rehabilitation services at home.png", 2 },
                    { 21, "Enhance your communication skills at home with our personalized speech therapy. Our expert therapists bring tailored sessions to you, focusing on your specific needs. Choose the convenience of at-home care for effective and comfortable progress.", "Speech therapy at home", "~/Images/Health/Speech therapy at home.png", 2 },
                    { 22, "Experience remote healthcare with our telehealth services. Connect with professionals from the comfort of your space. Choose convenient, virtual care for effective and personalized support.", "telehealth services", "~/Images/Health/telehealth services.png", 2 },
                    { 23, "Keep your home cozy with our swift HVAC repairs. We fix air conditioning and heating issues promptly, ensuring your comfort year-round. Choose us for efficient and reliable solutions to maintain your ideal indoor climate.", "Air Conditioning and Heating Repairs ", "~/Images/Mechanical/Air Conditioning and Heating Repairs.png", 3 },
                    { 24, "Drive confidently with our swift brake repairs. Our skilled technicians prioritize your safety, delivering efficient solutions to keep your vehicle in top condition. Choose us for reliable brake repairs that ensure a smooth and secure driving experience.", "Brake Repairs ", "~/Images/Mechanical/Brake Repairs.png", 3 },
                    { 25, "Pinpoint vehicle issues with our precise diagnostic services. Our skilled mechanics use advanced technology for efficient problem identification. Trust us for accurate insights, streamlining repairs and keeping your vehicle running smoothly.", "Diagnostic Services ", "~/Images/Mechanical/Diagnostic Services.png", 3 },
                    { 26, "Address car electrical issues promptly with our skilled mechanics. Trust us for fast and reliable solutions to ensure your vehicle's electrical system is running smoothly. Choose expert repairs for your automotive electrical problems, bringing you peace of mind on the road.", "Electrical Problems ", "~/Images/Mechanical/Electrical Problems.png", 3 },
                    { 27, "Resolve engine issues with our skilled mechanics for efficient and reliable solutions. Choose us for expert repairs to ensure optimal performance and a smoothly running engine.", "Engine Trouble ", "~/Images/Mechanical/Engine Trouble.png", 3 },
                    { 28, "Fix fluid leaks with our expert solutions. Our skilled technicians swiftly identify and repair issues for a smoothly running vehicle. Choose us for prompt and precise resolution, ensuring your vehicle stays in top condition.", "Fluid Leaks ", "~/Images/Mechanical/Fluid Leaks.png", 3 },
                    { 29, "Maintain your vehicle's health with our reliable routine maintenance. Our skilled technicians provide efficient checks for optimal performance. Choose hassle-free maintenance for peace of mind on the road. Trust us for expert service to keep your vehicle running smoothly.", "Routine Maintenance ", "~/Images/Mechanical/Routine Maintenance.png", 3 },
                    { 30, "Ensure a smooth ride with our expert suspension and steering repairs. Our skilled technicians specialize in efficient solutions to keep your vehicle handling with precision. Choose us for reliable repairs that prioritize your safety and restore optimal driving performanc", "Suspension and Steering Repairs ", "~/Images/Mechanical/Suspension and Steering Repairs.png", 3 },
                    { 31, "Keep your journey smooth with our expert tire services. Our skilled technicians offer efficient solutions for tire repairs, rotations, and replacements. Choose us for reliable and prompt tire services, ensuring your safety and the longevity of your tires.", "Tire Services ", "~/Images/Mechanical/Tire Services.png", 3 },
                    { 32, "Resolve transmission concerns efficiently with our expert services. Our skilled technicians specialize in diagnosing and repairing transmission issues to keep your vehicle running smoothly. Choose us for reliable and prompt solutions, ensuring optimal performance and longevity for your transmission", "Transmission Concerns ", "~/Images/Mechanical/Transmission Concerns.png", 3 },
                    { 33, "Count on us for prompt Emergency Electrical Services. Our skilled electricians are ready to address urgent electrical issues, ensuring the safety and functionality of your home or business. Trust us for reliable and efficient solutions to restore power and resolve electrical emergencies swiftly. Choose our Emergency Electrical Services for peace of mind during critical situations.", "Emergency Electrical Services", "~/Images/Electrical/Emergency Electrical Services.png", 4 },
                    { 34, "Enhance energy efficiency with our expert solutions. Our professionals specialize in tailored strategies for cost-effective and sustainable results. Choose us for streamlined energy solutions that benefit your home or business.", "Energy-Efficient Solutions", "~/Images/Electrical/Energy-Efficient Solutions.png", 4 },
                    { 35, "Ensure reliable power with our expert Generator Installation and Repair services. Our skilled technicians specialize in efficient installations and timely repairs to keep your generator ready for any power needs. Choose us for reliable solutions that prioritize seamless operation and backup power when you need it most.", "Generator Installation and Repair", "~/Images/Electrical/Generator Installation and Repair.png", 4 },
                    { 36, "Experience seamless installations with our expert services. Our skilled professionals specialize in efficient setup to meet your specific needs. Choose us for reliable and hassle-free installation solutions tailored to enhance your systems and equipment.", "Installation Services", "~/Images/Electrical/Installation Services.png", 4 },
                    { 37, "Brighten your outdoors with our expert Outdoor Lighting. Our skilled professionals ensure efficient installation and maintenance for enhanced aesthetics and security. Choose us for reliable solutions that illuminate your outdoor spaces with style.", "Outdoor Lighting", "~/Images/Electrical/Outdoor Lighting copy.png", 4 },
                    { 38, "Elevate your power capacity with our Panel Upgrades. Our skilled electricians efficiently enhance your electrical system for modern demands. Choose us for reliable solutions that ensure a more robust and efficient power supply.", "Panel Upgrades", "~/Images/Electrical/Panel Upgrades.png", 4 },
                    { 39, "Secure your space with our expert Security System Wiring services. Our skilled technicians specialize in efficient and discreet wiring installations to ensure the seamless operation of your security systems. Choose us for reliable solutions that prioritize the safety and protection of your home or business. Enhance your security infrastructure with our expert Security System Wiring services.", "Security System Wiring", "~/Images/Electrical/Security System Wiring.png", 4 },
                    { 40, "\r\nUpgrade to a smarter home with our expert Smart Home Integration. Our skilled technicians ensure seamless installations for enhanced convenience and connectivity. Choose us for reliable solutions that bring intelligence to every corner of your living space.", "Smart Home Electrical Integration", "~/Images/Electrical/Smart Home Electrical Integration.png", 4 },
                    { 41, "Ensure efficient electrical connectivity with our expert Wiring and Rewiring services. Our skilled technicians specialize in reliable installations and rewiring to meet the electrical needs of your home or business. Choose us for seamless solutions that prioritize safety, efficiency, and optimal functionality. Trust our experts to handle your wiring and rewiring needs with precision and care.", "Wiring and Rewiring", "~/Images/Electrical/Wiring and Rewiring.png", 4 },
                    { 42, "Keep your electronic devices powered with our expert Battery Replacement services. Our skilled technicians specialize in swift and reliable battery replacements for various gadgets and devices. Choose us for hassle-free solutions that ensure your electronics stay powered and functional. Trust our experts to provide timely and efficient battery replacements to keep your electronic devices running smoothly.", "Battery Replacements", "~/Images/Electronic/Battery Replacements.png", 5 },
                    { 43, "Resolve device issues with our expert Troubleshooting services. Our skilled technicians swiftly identify and fix problems with various devices. Choose us for reliable solutions to ensure optimal device performance. Trust our experts for efficient troubleshooting that keeps your gadgets running smoothly.", "Device Troubleshooting", "~/Images/Electronic/Device Troubleshooting.png", 5 },
                    { 44, "Elevate your devices with our expert Upgrade services. Our skilled technicians specialize in enhancing the performance and features of your gadgets. Choose us for reliable and efficient upgrades that bring your devices to the next level. Trust our experts to provide seamless and customized solutions to optimize the functionality of your electronic equipment.", "Device Upgrades", "~/Images/Electronic/Device Upgrades.png", 5 },
                    { 45, "Revive your gaming experience with our expert Gaming Console Repair services. Our skilled technicians specialize in diagnosing and fixing issues to get your console back in action. Choose us for reliable solutions that prioritize a swift and efficient repair process. Trust our experts to provide effective Gaming Console Repairs, ensuring you can resume your gaming adventures without disruption.", "Gaming Console Repairs", "~/Images/Electronic/Gaming Console Repairs.png", 5 },
                    { 46, "Tackle network connectivity issues with our expert solutions. Our skilled technicians specialize in diagnosing and resolving problems to ensure seamless connectivity. Choose us for reliable solutions that prioritize a swift and efficient resolution to your network issues. Trust our experts to provide effective troubleshooting, ensuring your devices stay connected and operational.", "Network Connectivity Issues", "~/Images/Electronic/Network Connectivity Issues.png", 5 },
                    { 47, "Revitalize your screens with our expert Screen Repair services. Our skilled technicians efficiently address screen issues on various devices. Choose us for reliable solutions that prioritize swift and precise repairs. Trust our experts to bring your screens back to life for an enhanced viewing experience.", "Screen Repairs", "~/Images/Electronic/Screen Repairs.png", 5 },
                    { 48, "Resolve software glitches with our expert solutions. Our skilled technicians specialize in identifying and fixing software issues on various devices. Choose us for reliable solutions that prioritize swift and efficient resolution to software glitches. Trust our experts to provide effective troubleshooting, ensuring your devices run smoothly and efficiently.", "Software Glitches", "~/Images/Electronic/Software Glitches.png", 5 },
                    { 49, "Ensure device security with our Virus and Malware Removal. Our skilled technicians swiftly eliminate threats for safe and efficient operation. Choose us for reliable solutions that prioritize swift removal of viruses and malware. Trust our experts for effective security measures to keep your devices safe.", "Virus and Malware Removal", "~/Images/Electronic/Virus and Malware Removal.png", 5 }
                });

            migrationBuilder.InsertData(
                table: "providers",
                columns: new[] { "ID", "City", "Email", "ImageUrl", "IsActive", "IsSubscriptionActive", "Location", "MonthlyPrice", "Name", "Password", "Phone", "Position", "Rate", "Role", "SubscriptionEndDate", "SubscriptionStartDate", "serviceID" },
                values: new object[,]
                {
                    { 1, "Irbid", "provider1@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider1", "12", 777848419, "position 2", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2656), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2645), 1 },
                    { 2, "Irbid", "provider2@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider2", "12", 777848419, "position 2", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2666), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2666), 1 },
                    { 3, "Irbid", "provider3@provider.com", "~/Customer/team-3.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider3", "12", 777848419, "position 3", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2670), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2670), 2 },
                    { 4, "Irbid", "provider4@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider4", "12", 777848419, "position 4", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2677), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2676), 2 },
                    { 5, "Irbid", "provider5@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider5", "12", 777848419, "position 5", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2681), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2680), 3 },
                    { 6, "Irbid", "provider6@provider.com", "~/Customer/team-3.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider6", "12", 777848419, "position 6", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2684), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2684), 3 },
                    { 7, "Irbid", "provider7@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider7", "12", 777848419, "position 7", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2687), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2687), 11 },
                    { 8, "Irbid", "provider8@provider.com", "~/Customer/team-3.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider8", "12", 777848419, "position 8", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2690), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2690), 11 },
                    { 9, "Irbid", "provider9@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider9", "12", 777848419, "position 9", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2693), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2693), 12 },
                    { 10, "Irbid", "provider10@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider10", "12", 777848419, "position 10", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2710), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2709), 12 },
                    { 11, "Irbid", "provider11@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider11", "12", 777848419, "position 11", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2713), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2713), 13 },
                    { 12, "Irbid", "provider12@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider12", "12", 777848419, "position 12", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2716), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2716), 13 },
                    { 13, "Irbid", "provider13@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider13", "12", 777848419, "position 13", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2720), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2719), 23 },
                    { 14, "Irbid", "provider14@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider14", "12", 777848419, "position 14", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2723), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2722), 23 },
                    { 15, "Irbid", "provider15@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider15", "12", 777848419, "position 15", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2726), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2725), 24 },
                    { 16, "Irbid", "provider16@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider16", "12", 777848419, "position 16", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2729), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2728), 24 },
                    { 17, "Irbid", "provider17@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider17", "12", 777848419, "position 17", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2732), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2731), 25 },
                    { 18, "Irbid", "provider18@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider18", "12", 777848419, "position 18", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2735), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2734), 25 },
                    { 19, "Irbid", "provider19@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider19", "12", 777848419, "position 19", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2738), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2737), 33 },
                    { 20, "Irbid", "provider20@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider20", "12", 777848419, "position 20", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2742), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2741), 33 },
                    { 21, "Irbid", "provider21@provider.com", "~/Customer/team-3.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider21", "12", 777848419, "position 21", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2745), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2744), 34 },
                    { 22, "Irbid", "provider22@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider22", "12", 777848419, "position 22", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2748), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2747), 34 },
                    { 23, "Irbid", "provider23@provider.com", "~/Customer/team-1.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider23", "12", 777848419, "position 23", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2751), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2750), 35 },
                    { 24, "Irbid", "provider24@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider24", "12", 777848419, "position 24", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2754), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2753), 35 },
                    { 25, "Irbid", "provider25@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider25", "12", 777848419, "position 25", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2758), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2757), 42 },
                    { 26, "Irbid", "provider26@provider.com", "~/Customer/team-3.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider26", "12", 777848419, "position 26", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2761), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2760), 42 },
                    { 27, "Irbid", "provider27@provider.com", "~/Customer/team-3.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider27", "12", 777848419, "position 27", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2764), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2763), 43 },
                    { 28, "Irbid", "provider28@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider28", "12", 777848419, "position 28", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2767), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2766), 43 },
                    { 29, "Irbid", "provider29@provider.com", "~/Customer/team-4.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider29", "12", 777848419, "position 29", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2770), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2769), 44 },
                    { 30, "Irbid", "provider30@provider.com", "~/Customer/team-2.jpg", true, true, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider30", "12", 777848419, "position 30", 0.0, 1, new DateTime(2024, 3, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2773), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2772), 44 },
                    { 31, "Irbid", "provider31@provider.com", "~/Customer/team-4.jpg", true, false, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider31", "12", 777848419, "position 31", 0.0, 1, new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2776), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2775), 1 },
                    { 32, "Irbid", "provider32@provider.com", "~/Customer/team-2.jpg", false, false, "https://www.google.com/maps/place/%D9%84%D9%88%D8%A7%D8%A1+%D8%A7%D9%84%D9%83%D9%88%D8%B1%D8%A9%E2%80%AD/@32.5126615,35.6878611,17z/data=!3m1!4b1!4m15!1m8!3m7!1s0x151c6fff37d056ab:0x8d45f28b1b2623ef!2z2K_ZitixINij2KjZiiDYs9i52YrYrw!3b1!8m2!3d32.4984964!4d35.6837977!16s%2Fm%2F0kbhjd9!3m5!1s0x151c65bcba3f0d0f:0x8050a8b00b1a63ec!8m2!3d32.5126615!4d35.6852862!16s%2Fg%2F11mvnp286r?entry=ttu", 40.0, "provider32", "12", 777848419, "position 32", 0.0, 1, new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2778), new DateTime(2024, 1, 27, 18, 30, 11, 528, DateTimeKind.Local).AddTicks(2778), 1 }
                });

            migrationBuilder.InsertData(
                table: "feedbackForProviders",
                columns: new[] { "ID", "Rating", "Status", "Text", "customerID", "providerID" },
                values: new object[,]
                {
                    { 1, 0.0, 1, "Prompt and Reliable", 2, 1 },
                    { 2, 0.0, 1, "Exceptional Care", 2, 1 },
                    { 3, 0.0, 1, "Timely Solutions", 2, 1 },
                    { 4, 0.0, 1, "Excellent Work", 2, 2 },
                    { 5, 0.0, 1, "Exceptional Care", 2, 2 },
                    { 6, 0.0, 1, "Top-notch Service", 2, 2 },
                    { 7, 0.0, 1, "Top-notch Service", 2, 3 },
                    { 8, 0.0, 1, "Exceptional Care", 2, 3 },
                    { 9, 0.0, 1, "Timely Solutions", 2, 3 },
                    { 10, 0.0, 1, "Professional Support", 2, 4 },
                    { 11, 0.0, 1, "Exceptional Care", 2, 4 },
                    { 12, 0.0, 1, "Timely Solutions", 2, 4 },
                    { 13, 0.0, 1, "Outstanding Performance", 2, 5 },
                    { 14, 0.0, 1, "Exceptional Care", 2, 5 },
                    { 15, 0.0, 1, "Timely Solutions", 2, 5 },
                    { 16, 0.0, 1, "Professional Support", 2, 6 },
                    { 17, 0.0, 1, "Outstanding Performance", 2, 6 },
                    { 18, 0.0, 1, "Timely Solutions", 2, 6 },
                    { 19, 0.0, 1, "Outstanding Performance", 2, 7 },
                    { 20, 0.0, 1, "Exceptional Care", 2, 7 },
                    { 21, 0.0, 1, "Timely Solutions", 2, 7 },
                    { 22, 0.0, 1, "Outstanding Performance", 2, 8 },
                    { 23, 0.0, 1, "Exceptional Care", 2, 8 },
                    { 24, 0.0, 1, "Timely Solutions", 2, 8 },
                    { 25, 0.0, 1, "Professional Support", 2, 9 },
                    { 26, 0.0, 1, "Exceptional Care", 2, 9 },
                    { 27, 0.0, 1, "Timely Solutions", 2, 9 },
                    { 28, 0.0, 1, "Outstanding Performance", 2, 10 },
                    { 29, 0.0, 1, "Exceptional Care", 2, 10 },
                    { 30, 0.0, 1, "Timely Solutions", 2, 10 },
                    { 31, 0.0, 1, "Professional Support", 2, 11 },
                    { 32, 0.0, 1, "Exceptional Care", 2, 11 },
                    { 33, 0.0, 1, "Timely Solutions", 2, 11 },
                    { 34, 0.0, 1, "Outstanding Performance", 2, 12 },
                    { 35, 0.0, 1, "Exceptional Care", 2, 12 },
                    { 36, 0.0, 1, "Timely Solutions", 2, 12 },
                    { 37, 0.0, 1, "Professional Support", 2, 13 },
                    { 38, 0.0, 1, "Exceptional Care", 2, 13 },
                    { 39, 0.0, 1, "Timely Solutions", 2, 13 },
                    { 40, 0.0, 1, "Exceptional Care", 2, 14 },
                    { 41, 0.0, 1, "Professional Support", 2, 14 },
                    { 42, 0.0, 1, "Timely Solutions", 2, 14 },
                    { 43, 0.0, 1, "Professional Support", 2, 15 },
                    { 45, 0.0, 1, "Exceptional Care", 2, 15 },
                    { 46, 0.0, 1, "Timely Solutions", 2, 15 },
                    { 47, 0.0, 1, "Exceptional Care", 2, 16 },
                    { 48, 0.0, 1, "Professional Support", 2, 16 },
                    { 49, 0.0, 1, "Timely Solutions", 2, 16 },
                    { 50, 0.0, 1, "Professional Support", 2, 17 },
                    { 51, 0.0, 1, "Exceptional Care", 2, 17 },
                    { 52, 0.0, 1, "Timely Solutions", 2, 17 },
                    { 53, 0.0, 1, "Professional Support", 2, 18 },
                    { 54, 0.0, 1, "Exceptional Care", 2, 18 },
                    { 56, 0.0, 1, "Timely Solutions", 2, 18 },
                    { 57, 0.0, 1, "Professional Support", 2, 19 },
                    { 58, 0.0, 1, "Exceptional Care", 2, 19 },
                    { 59, 0.0, 1, "Timely Solutions", 2, 19 },
                    { 60, 0.0, 1, "Professional Support", 2, 20 },
                    { 61, 0.0, 1, "Exceptional Care", 2, 20 },
                    { 62, 0.0, 1, "Timely Solutions", 2, 20 },
                    { 63, 0.0, 1, "Professional Support", 2, 21 },
                    { 64, 0.0, 1, "Exceptional Care", 2, 21 },
                    { 65, 0.0, 1, "Timely Solutions", 2, 21 },
                    { 66, 0.0, 1, "Professional Support", 2, 22 },
                    { 67, 0.0, 1, "Exceptional Care", 2, 22 },
                    { 68, 0.0, 1, "Timely Solutions", 2, 22 },
                    { 69, 0.0, 1, "Professional Support", 2, 23 },
                    { 70, 0.0, 1, "Exceptional Care", 2, 23 },
                    { 71, 0.0, 1, "Timely Solutions", 2, 23 },
                    { 72, 0.0, 1, "Professional Support", 2, 24 },
                    { 73, 0.0, 1, "Exceptional Care", 2, 24 },
                    { 74, 0.0, 1, "Timely Solutions", 2, 24 },
                    { 75, 0.0, 1, "Professional Support", 2, 25 },
                    { 76, 0.0, 1, "Exceptional Care", 2, 25 },
                    { 77, 0.0, 1, "Timely Solutions", 2, 25 },
                    { 78, 0.0, 1, "Professional Support", 2, 26 },
                    { 79, 0.0, 1, "Exceptional Care", 2, 26 },
                    { 80, 0.0, 1, "Timely Solutions", 2, 26 },
                    { 81, 0.0, 1, "Professional Support", 2, 27 },
                    { 82, 0.0, 1, "Exceptional Care", 2, 27 },
                    { 83, 0.0, 1, "Timely Solutions", 2, 27 },
                    { 84, 0.0, 1, "Professional Support", 2, 28 },
                    { 85, 0.0, 1, "Exceptional Care", 2, 28 },
                    { 86, 0.0, 1, "Timely Solutions", 2, 28 },
                    { 87, 0.0, 1, "Professional Support", 2, 29 },
                    { 88, 0.0, 1, "Exceptional Care", 2, 29 },
                    { 89, 0.0, 1, "Timely Solutions", 2, 29 },
                    { 90, 0.0, 1, "Professional Support", 2, 30 },
                    { 91, 0.0, 1, "Exceptional Care", 2, 30 },
                    { 92, 0.0, 1, "Timely Solutions", 2, 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "feedbackForProviders",
                keyColumn: "ID",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "feedbackForWebs",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "payments",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "payments",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "customers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "providers",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "serviceItems",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "services",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "ForDelete",
                table: "customers");
        }
    }
}
