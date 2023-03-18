using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moment.Migrations
{
    public partial class EntitysMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convention",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resume = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Terms = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdUserPromoter = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ThumbnailPath = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BackgroundPath = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LatitudeAdress = table.Column<decimal>(type: "decimal(8,6)", nullable: false),
                    LongitudeAdress = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convention", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Convention_AspNetUsers_IdUserPromoter",
                        column: x => x.IdUserPromoter,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdConvention = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Lot = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    LaunchDay = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClosingDay = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_Convention_IdConvention",
                        column: x => x.IdConvention,
                        principalTable: "Convention",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "itempurchase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPurchase = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdTicket = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itempurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_itempurchase_ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdPurchase = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Provider = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Paid = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "purchase",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdUser = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    IdPayment = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchase_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_payment_IdPayment",
                        column: x => x.IdPayment,
                        principalTable: "payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "voucher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdConvention = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    IdUser = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdPurchase = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DateOfUse = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_voucher_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_voucher_Convention_IdConvention",
                        column: x => x.IdConvention,
                        principalTable: "Convention",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_voucher_purchase_IdPurchase",
                        column: x => x.IdPurchase,
                        principalTable: "purchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Convention_IdUserPromoter",
                table: "Convention",
                column: "IdUserPromoter");

            migrationBuilder.CreateIndex(
                name: "IX_itempurchase_IdPurchase",
                table: "itempurchase",
                column: "IdPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_itempurchase_IdTicket",
                table: "itempurchase",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_payment_IdPurchase",
                table: "payment",
                column: "IdPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_IdPayment",
                table: "purchase",
                column: "IdPayment");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_IdUser",
                table: "purchase",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_IdConvention",
                table: "ticket",
                column: "IdConvention");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_IdConvention",
                table: "voucher",
                column: "IdConvention");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_IdPurchase",
                table: "voucher",
                column: "IdPurchase");

            migrationBuilder.CreateIndex(
                name: "IX_voucher_IdUser",
                table: "voucher",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_itempurchase_purchase_IdPurchase",
                table: "itempurchase",
                column: "IdPurchase",
                principalTable: "purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_payment_purchase_IdPurchase",
                table: "payment",
                column: "IdPurchase",
                principalTable: "purchase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payment_purchase_IdPurchase",
                table: "payment");

            migrationBuilder.DropTable(
                name: "itempurchase");

            migrationBuilder.DropTable(
                name: "voucher");

            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "Convention");

            migrationBuilder.DropTable(
                name: "purchase");

            migrationBuilder.DropTable(
                name: "payment");
        }
    }
}
