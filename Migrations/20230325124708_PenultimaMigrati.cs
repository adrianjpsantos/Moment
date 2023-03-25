using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moment.Migrations
{
    public partial class PenultimaMigrati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_purchase_payment_IdPayment",
                table: "purchase");

            migrationBuilder.DropIndex(
                name: "IX_purchase_IdPayment",
                table: "purchase");

            migrationBuilder.DropColumn(
                name: "IdPayment",
                table: "purchase");

            migrationBuilder.InsertData(
                table: "conventioncategory",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("4abb0ff8-098d-4989-abf7-e12a2d1af5c3"), "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!", "\\img\\conventionCategory\\festaseshows.jpg", "Festas e Shows" },
                    { new Guid("4e4dc372-43e3-47fe-84be-24f777a4d054"), "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!", "\\img\\conventionCategory\\standupcomedy.jpg", "Stand up Comedy" },
                    { new Guid("5d55ec93-b606-4e79-a2fb-81390e54c6da"), "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.", "\\img\\conventionCategory\\teatroseespetaculos.jpg", "Teatros e Espetáculos" },
                    { new Guid("97e8f3a7-be05-45b6-9fd4-69ad0aaae6aa"), "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.", "\\img\\conventionCategory\\tecnologia.jpg", "Tecnologia" },
                    { new Guid("bfcab34a-074f-4696-b79d-b9acbad9fe5e"), "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.", "\\img\\conventionCategory\\passeiosetours.jpg", "Passeios e Tours" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("4abb0ff8-098d-4989-abf7-e12a2d1af5c3"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("4e4dc372-43e3-47fe-84be-24f777a4d054"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("5d55ec93-b606-4e79-a2fb-81390e54c6da"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("97e8f3a7-be05-45b6-9fd4-69ad0aaae6aa"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("bfcab34a-074f-4696-b79d-b9acbad9fe5e"));

            migrationBuilder.AddColumn<Guid>(
                name: "IdPayment",
                table: "purchase",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_IdPayment",
                table: "purchase",
                column: "IdPayment");

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_payment_IdPayment",
                table: "purchase",
                column: "IdPayment",
                principalTable: "payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
