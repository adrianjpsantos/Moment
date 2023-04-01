using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moment.Migrations
{
    public partial class TCC_01_04_23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("3f5c5146-ac1f-428a-aa8a-bdae229aa925"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("5b87ae48-e2a3-45e3-9bce-0a4deced1bd7"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("688e8c28-bedf-44f4-b376-4c420434d855"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("cfca3e02-76bd-4add-8ef5-d981ea911b7a"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("e9282395-20e9-44d9-be61-eea8c2763945"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("fe0f66f7-df55-4222-831c-369c7c3f431c"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("3cb7558b-dfcf-47a3-aaf6-c69f1b1a7fc6"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("66536762-fae5-4063-9dfb-9a6735ef547c"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("6a3f8969-8441-4c26-823d-c0ed896f39d5"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("77e64fb9-44d2-4ada-975a-0a9aebe27222"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("b5ce44da-6872-418b-ab6f-c5774e328569"));

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailPath",
                table: "Convention",
                type: "varchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldMaxLength: 40)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundPath",
                table: "Convention",
                type: "varchar(60)",
                maxLength: 60,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(40)",
                oldMaxLength: 40,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("0076c742-fbf7-4b96-b3a3-73fcb73d8de3"), "Barra Bonita", "SP" },
                    { new Guid("45d64687-bf8b-458e-b5ac-5e14fc0f200c"), "Lençois Paulista", "SP" },
                    { new Guid("4bf72a52-6b43-4a40-b84f-937b8f76d03f"), "Jau", "SP" },
                    { new Guid("b213d456-d6b8-4943-8048-553bd032cdf4"), "Igaraçu do Tiête", "SP" },
                    { new Guid("c110aa30-9374-4619-8f7a-c879c5e5e537"), "Pederneiras", "SP" },
                    { new Guid("eef3fcb5-ceea-4386-b457-1b85ddf2201e"), "Macatuba", "SP" }
                });

            migrationBuilder.InsertData(
                table: "conventioncategory",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("03227377-116f-413b-814e-b691ffa510ea"), "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!", "\\img\\conventionCategory\\standupcomedy.jpg", "Stand up Comedy" },
                    { new Guid("3baa09c6-1f73-46c2-aa51-2ee678f79c98"), "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!", "\\img\\conventionCategory\\festaseshows.jpg", "Festas e Shows" },
                    { new Guid("496e6ff5-9153-4be0-9186-ba6bbf3a7247"), "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.", "\\img\\conventionCategory\\tecnologia.jpg", "Tecnologia" },
                    { new Guid("afbef800-48d8-48ee-9aa5-916c2c026d14"), "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.", "\\img\\conventionCategory\\passeiosetours.jpg", "Passeios e Tours" },
                    { new Guid("f4eb8add-8195-4af9-8acb-fbef5bb28032"), "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.", "\\img\\conventionCategory\\tours.jpg", "Teatros e Espetáculos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("0076c742-fbf7-4b96-b3a3-73fcb73d8de3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("45d64687-bf8b-458e-b5ac-5e14fc0f200c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("4bf72a52-6b43-4a40-b84f-937b8f76d03f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("b213d456-d6b8-4943-8048-553bd032cdf4"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("c110aa30-9374-4619-8f7a-c879c5e5e537"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("eef3fcb5-ceea-4386-b457-1b85ddf2201e"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("03227377-116f-413b-814e-b691ffa510ea"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("3baa09c6-1f73-46c2-aa51-2ee678f79c98"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("496e6ff5-9153-4be0-9186-ba6bbf3a7247"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("afbef800-48d8-48ee-9aa5-916c2c026d14"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("f4eb8add-8195-4af9-8acb-fbef5bb28032"));

            migrationBuilder.AlterColumn<string>(
                name: "ThumbnailPath",
                table: "Convention",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BackgroundPath",
                table: "Convention",
                type: "varchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldMaxLength: 60,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("3f5c5146-ac1f-428a-aa8a-bdae229aa925"), "Barra Bonita", "SP" },
                    { new Guid("5b87ae48-e2a3-45e3-9bce-0a4deced1bd7"), "Jau", "SP" },
                    { new Guid("688e8c28-bedf-44f4-b376-4c420434d855"), "Pederneiras", "SP" },
                    { new Guid("cfca3e02-76bd-4add-8ef5-d981ea911b7a"), "Macatuba", "SP" },
                    { new Guid("e9282395-20e9-44d9-be61-eea8c2763945"), "Igaraçu do Tiête", "SP" },
                    { new Guid("fe0f66f7-df55-4222-831c-369c7c3f431c"), "Lençois Paulista", "SP" }
                });

            migrationBuilder.InsertData(
                table: "conventioncategory",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("3cb7558b-dfcf-47a3-aaf6-c69f1b1a7fc6"), "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.", "\\img\\conventionCategory\\tecnologia.jpg", "Tecnologia" },
                    { new Guid("66536762-fae5-4063-9dfb-9a6735ef547c"), "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!", "\\img\\conventionCategory\\standupcomedy.jpg", "Stand up Comedy" },
                    { new Guid("6a3f8969-8441-4c26-823d-c0ed896f39d5"), "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!", "\\img\\conventionCategory\\festaseshows.jpg", "Festas e Shows" },
                    { new Guid("77e64fb9-44d2-4ada-975a-0a9aebe27222"), "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.", "\\img\\conventionCategory\\tours.jpg", "Teatros e Espetáculos" },
                    { new Guid("b5ce44da-6872-418b-ab6f-c5774e328569"), "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.", "\\img\\conventionCategory\\passeiosetours.jpg", "Passeios e Tours" }
                });
        }
    }
}
