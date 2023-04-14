using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moment.Migrations
{
    public partial class TCC_07_04_23_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Convention",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("178cefdb-e576-4c6f-ae15-a8ff01c15de2"), "Igaraçu do Tiête", "SP" },
                    { new Guid("630ab994-296e-4706-b068-4f53bed6641b"), "Pederneiras", "SP" },
                    { new Guid("77eae789-58ed-412b-8e89-40f78d60c47f"), "Macatuba", "SP" },
                    { new Guid("8648112e-a91f-4b3d-86d4-c4801ed4b320"), "Jau", "SP" },
                    { new Guid("9a8d85ae-6e9a-4755-b23e-46872a3e2b87"), "Lençois Paulista", "SP" },
                    { new Guid("d7f6542a-a7f1-4e23-9fac-240e44c44000"), "Barra Bonita", "SP" }
                });

            migrationBuilder.InsertData(
                table: "conventioncategory",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("141e3200-118a-4c56-9be6-00ba53243844"), "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!", "\\img\\conventionCategory\\festaseshows.jpg", "Festas e Shows" },
                    { new Guid("24d1280c-55fc-4561-a68b-09a9f2dceac1"), "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.", "\\img\\conventionCategory\\tecnologia.jpg", "Tecnologia" },
                    { new Guid("6f8ac949-0cc7-43ca-95b4-e6ecc047b039"), "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.", "\\img\\conventionCategory\\passeiosetours.jpg", "Passeios e Tours" },
                    { new Guid("886376e7-1334-42a4-a79b-48d492c92dd0"), "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.", "\\img\\conventionCategory\\teatroseespetaculos.jpg", "Teatros e Espetáculos" },
                    { new Guid("936206ae-59e2-480b-99f0-b8c60a4da652"), "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!", "\\img\\conventionCategory\\standupcomedy.jpg", "Stand up Comedy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("178cefdb-e576-4c6f-ae15-a8ff01c15de2"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("630ab994-296e-4706-b068-4f53bed6641b"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("77eae789-58ed-412b-8e89-40f78d60c47f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("8648112e-a91f-4b3d-86d4-c4801ed4b320"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("9a8d85ae-6e9a-4755-b23e-46872a3e2b87"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("d7f6542a-a7f1-4e23-9fac-240e44c44000"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("141e3200-118a-4c56-9be6-00ba53243844"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("24d1280c-55fc-4561-a68b-09a9f2dceac1"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("6f8ac949-0cc7-43ca-95b4-e6ecc047b039"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("886376e7-1334-42a4-a79b-48d492c92dd0"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("936206ae-59e2-480b-99f0-b8c60a4da652"));

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Convention");

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
    }
}
