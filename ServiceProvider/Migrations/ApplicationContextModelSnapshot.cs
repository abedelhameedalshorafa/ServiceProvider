﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceProvider.Context;

#nullable disable

namespace ServiceProvider.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ServiceProvider.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("ServiceProvider.Models.FeedbackForProvider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<int>("providerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("customerID");

                    b.HasIndex("providerID");

                    b.ToTable("feedbackForProviders");
                });

            modelBuilder.Entity("ServiceProvider.Models.FeedbackForWeb", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("customerID");

                    b.ToTable("feedbackForWebs");
                });

            modelBuilder.Entity("ServiceProvider.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("customerID")
                        .HasColumnType("int");

                    b.Property<int>("providerID")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("customerID");

                    b.HasIndex("providerID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ServiceProvider.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cardNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("ServiceProvider.Models.Provider", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubscriptionActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MonthlyPrice")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rate")
                        .HasColumnType("float");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubscriptionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SubscriptionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("serviceID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("serviceID");

                    b.ToTable("providers");
                });

            modelBuilder.Entity("ServiceProvider.Models.Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("services");
                });

            modelBuilder.Entity("ServiceProvider.Models.ServiceItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("serviceID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("serviceID");

                    b.ToTable("serviceItems");
                });

            modelBuilder.Entity("ServiceProvider.Models.Subscription", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cardPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("flagfordelete")
                        .HasColumnType("bit");

                    b.Property<int>("numberOfMonths")
                        .HasColumnType("int");

                    b.Property<double>("paymentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("paymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("providerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("providerID");

                    b.ToTable("subscriptions");
                });

            modelBuilder.Entity("ServiceProvider.Models.FeedbackForProvider", b =>
                {
                    b.HasOne("ServiceProvider.Models.Customer", "Customer")
                        .WithMany("feedbackForProviders")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceProvider.Models.Provider", "Provider")
                        .WithMany("FeedbackForProviders")
                        .HasForeignKey("providerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ServiceProvider.Models.FeedbackForWeb", b =>
                {
                    b.HasOne("ServiceProvider.Models.Customer", "Customer")
                        .WithMany("feedbackForWebs")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ServiceProvider.Models.Order", b =>
                {
                    b.HasOne("ServiceProvider.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServiceProvider.Models.Provider", "Provider")
                        .WithMany("Orders")
                        .HasForeignKey("providerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ServiceProvider.Models.Provider", b =>
                {
                    b.HasOne("ServiceProvider.Models.ServiceItem", "ServiceItem")
                        .WithMany("Providers")
                        .HasForeignKey("serviceID");

                    b.Navigation("ServiceItem");
                });

            modelBuilder.Entity("ServiceProvider.Models.ServiceItem", b =>
                {
                    b.HasOne("ServiceProvider.Models.Service", "Service")
                        .WithMany("ServiceItems")
                        .HasForeignKey("serviceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ServiceProvider.Models.Subscription", b =>
                {
                    b.HasOne("ServiceProvider.Models.Provider", "Provider")
                        .WithMany("Subscriptions")
                        .HasForeignKey("providerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("ServiceProvider.Models.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("feedbackForProviders");

                    b.Navigation("feedbackForWebs");
                });

            modelBuilder.Entity("ServiceProvider.Models.Provider", b =>
                {
                    b.Navigation("FeedbackForProviders");

                    b.Navigation("Orders");

                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("ServiceProvider.Models.Service", b =>
                {
                    b.Navigation("ServiceItems");
                });

            modelBuilder.Entity("ServiceProvider.Models.ServiceItem", b =>
                {
                    b.Navigation("Providers");
                });
#pragma warning restore 612, 618
        }
    }
}
