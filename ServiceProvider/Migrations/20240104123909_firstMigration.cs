using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServiceProvider.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cardNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "feedbackForWebs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackForWebs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_feedbackForWebs_customers_customerID",
                        column: x => x.customerID,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    serviceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_serviceItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_serviceItems_services_serviceID",
                        column: x => x.serviceID,
                        principalTable: "services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "providers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MonthlyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubscriptionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsSubscriptionActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    serviceID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_providers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_providers_serviceItems_serviceID",
                        column: x => x.serviceID,
                        principalTable: "serviceItems",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "feedbackForProviders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    providerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbackForProviders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_feedbackForProviders_customers_customerID",
                        column: x => x.customerID,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_feedbackForProviders_providers_providerID",
                        column: x => x.providerID,
                        principalTable: "providers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    customerID = table.Column<int>(type: "int", nullable: false),
                    providerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_orders_customers_customerID",
                        column: x => x.customerID,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orders_providers_providerID",
                        column: x => x.providerID,
                        principalTable: "providers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subscriptions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    paymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paymentAmount = table.Column<double>(type: "float", nullable: false),
                    numberOfMonths = table.Column<double>(type: "float", nullable: false),
                    cardNumber = table.Column<int>(type: "int", nullable: false),
                    cardPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    providerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subscriptions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_subscriptions_providers_providerID",
                        column: x => x.providerID,
                        principalTable: "providers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_feedbackForProviders_customerID",
                table: "feedbackForProviders",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_feedbackForProviders_providerID",
                table: "feedbackForProviders",
                column: "providerID");

            migrationBuilder.CreateIndex(
                name: "IX_feedbackForWebs_customerID",
                table: "feedbackForWebs",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customerID",
                table: "orders",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_providerID",
                table: "orders",
                column: "providerID");

            migrationBuilder.CreateIndex(
                name: "IX_providers_serviceID",
                table: "providers",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_serviceItems_serviceID",
                table: "serviceItems",
                column: "serviceID");

            migrationBuilder.CreateIndex(
                name: "IX_subscriptions_providerID",
                table: "subscriptions",
                column: "providerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "feedbackForProviders");

            migrationBuilder.DropTable(
                name: "feedbackForWebs");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "subscriptions");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "providers");

            migrationBuilder.DropTable(
                name: "serviceItems");

            migrationBuilder.DropTable(
                name: "services");
        }
    }
}
