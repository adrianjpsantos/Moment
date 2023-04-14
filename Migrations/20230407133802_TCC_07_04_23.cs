using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moment.Migrations
{
    public partial class TCC_07_04_23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Convention",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("4fb3371c-334f-4ace-aeea-af03753a835c"), "Macatuba", "SP" },
                    { new Guid("6eaa1d0d-f918-4711-9b4b-781425e242e3"), "Igaraçu do Tiête", "SP" },
                    { new Guid("7722b5b4-b5ba-4397-87c5-7c8eaa8d328e"), "Barra Bonita", "SP" },
                    { new Guid("ad9bff44-01eb-4453-a7be-20ad6a066239"), "Jau", "SP" },
                    { new Guid("d308b9d9-c257-4cbe-91aa-26f3447f76f7"), "Pederneiras", "SP" },
                    { new Guid("e54b0dfc-705c-4836-a639-879fe35c31b4"), "Lençois Paulista", "SP" }
                });

            migrationBuilder.InsertData(
                table: "conventioncategory",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("019debe7-18e6-40e8-894c-d55e2f08ebe8"), "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.", "\\img\\conventionCategory\\tecnologia.jpg", "Tecnologia" },
                    { new Guid("08b11e72-09c2-4401-b30e-47ee63530c79"), "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.", "\\img\\conventionCategory\\teatroseespetaculos.jpg", "Teatros e Espetáculos" },
                    { new Guid("1aabb448-ba9f-4333-a37f-569e037f0b46"), "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.", "\\img\\conventionCategory\\passeiosetours.jpg", "Passeios e Tours" },
                    { new Guid("cb473245-b5f0-4703-a734-6d65aeabe9fc"), "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!", "\\img\\conventionCategory\\festaseshows.jpg", "Festas e Shows" },
                    { new Guid("d5ab0930-a9c1-4a5c-88fb-cae620a1fc8e"), "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!", "\\img\\conventionCategory\\standupcomedy.jpg", "Stand up Comedy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("4fb3371c-334f-4ace-aeea-af03753a835c"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("6eaa1d0d-f918-4711-9b4b-781425e242e3"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("7722b5b4-b5ba-4397-87c5-7c8eaa8d328e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("ad9bff44-01eb-4453-a7be-20ad6a066239"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("d308b9d9-c257-4cbe-91aa-26f3447f76f7"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("e54b0dfc-705c-4836-a639-879fe35c31b4"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("019debe7-18e6-40e8-894c-d55e2f08ebe8"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("08b11e72-09c2-4401-b30e-47ee63530c79"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("1aabb448-ba9f-4333-a37f-569e037f0b46"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("cb473245-b5f0-4703-a734-6d65aeabe9fc"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("d5ab0930-a9c1-4a5c-88fb-cae620a1fc8e"));

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Convention");

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
    }
}
