using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moment.Migrations
{
    public partial class TCC_01_05_23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("0d7de41e-8d04-4ebc-a7f3-731a8909a683"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("2c04eddf-7852-4c3c-b7de-2d8c90305812"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("49efcc45-e339-401e-b87d-7de3764bdbde"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("517a9153-ab87-4570-b607-fa52a0faf303"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("5dedba3b-d02e-48f8-bc64-79d34586c98f"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("977daa4b-396c-4d4d-802b-d6900c6ccfbd"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("1f8b5582-5b5e-4637-9830-a817248272b7"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("49c9b7a5-e01a-4583-b768-c789f658935f"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("52f22ade-63b5-4d6d-b8a6-6638a6992c6d"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("a6af579d-0854-4fee-b1e0-094a3482a165"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("bb71a95e-c3d7-4fa6-a6fd-6e34be0f3cb7"));

            migrationBuilder.AlterColumn<string>(
                name: "ComplementAddress",
                table: "Convention",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "LocalNameAddress",
                table: "Convention",
                type: "varchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("15658332-ed9f-4600-992a-13620311a9ea"), "Barra Bonita", "SP" },
                    { new Guid("5127e0d1-fc9f-4f0a-af4d-b37b0046b56e"), "Pederneiras", "SP" },
                    { new Guid("91a7b309-cfe4-4cf7-9771-4ea713a31481"), "Macatuba", "SP" },
                    { new Guid("c973b6f8-b062-4dd7-a054-026b39333f5e"), "Lençois Paulista", "SP" },
                    { new Guid("ea93dc61-e7fa-4a22-a1b3-c8d9ec0d1b59"), "Jau", "SP" },
                    { new Guid("f7499280-ca4a-4ada-b0fc-09edb4fbf732"), "Igaraçu do Tiête", "SP" }
                });

            migrationBuilder.InsertData(
                table: "conventioncategory",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("328b98a2-ff97-4679-b795-8c984993d367"), "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.", "\\img\\conventionCategory\\tecnologia.jpg", "Tecnologia" },
                    { new Guid("427e4302-3dde-4e43-a389-662d0697cba8"), "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.", "\\img\\conventionCategory\\passeiosetours.jpg", "Passeios e Tours" },
                    { new Guid("8cc80661-086e-4e03-880b-8618fcb58966"), "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!", "\\img\\conventionCategory\\festaseshows.jpg", "Festas e Shows" },
                    { new Guid("a97de121-11e1-4a44-8e2d-6b1a114d5ba2"), "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.", "\\img\\conventionCategory\\teatroseespetaculos.jpg", "Teatros e Espetáculos" },
                    { new Guid("bc5e775f-46f2-4393-9bee-157df5d4b47a"), "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!", "\\img\\conventionCategory\\standupcomedy.jpg", "Stand up Comedy" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("15658332-ed9f-4600-992a-13620311a9ea"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("5127e0d1-fc9f-4f0a-af4d-b37b0046b56e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("91a7b309-cfe4-4cf7-9771-4ea713a31481"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("c973b6f8-b062-4dd7-a054-026b39333f5e"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("ea93dc61-e7fa-4a22-a1b3-c8d9ec0d1b59"));

            migrationBuilder.DeleteData(
                table: "city",
                keyColumn: "Id",
                keyValue: new Guid("f7499280-ca4a-4ada-b0fc-09edb4fbf732"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("328b98a2-ff97-4679-b795-8c984993d367"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("427e4302-3dde-4e43-a389-662d0697cba8"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("8cc80661-086e-4e03-880b-8618fcb58966"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("a97de121-11e1-4a44-8e2d-6b1a114d5ba2"));

            migrationBuilder.DeleteData(
                table: "conventioncategory",
                keyColumn: "Id",
                keyValue: new Guid("bc5e775f-46f2-4393-9bee-157df5d4b47a"));

            migrationBuilder.DropColumn(
                name: "LocalNameAddress",
                table: "Convention");

            migrationBuilder.UpdateData(
                table: "Convention",
                keyColumn: "ComplementAddress",
                keyValue: null,
                column: "ComplementAddress",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "ComplementAddress",
                table: "Convention",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "city",
                columns: new[] { "Id", "Name", "State" },
                values: new object[,]
                {
                    { new Guid("0d7de41e-8d04-4ebc-a7f3-731a8909a683"), "Macatuba", "SP" },
                    { new Guid("2c04eddf-7852-4c3c-b7de-2d8c90305812"), "Jau", "SP" },
                    { new Guid("49efcc45-e339-401e-b87d-7de3764bdbde"), "Lençois Paulista", "SP" },
                    { new Guid("517a9153-ab87-4570-b607-fa52a0faf303"), "Barra Bonita", "SP" },
                    { new Guid("5dedba3b-d02e-48f8-bc64-79d34586c98f"), "Igaraçu do Tiête", "SP" },
                    { new Guid("977daa4b-396c-4d4d-802b-d6900c6ccfbd"), "Pederneiras", "SP" }
                });

            migrationBuilder.InsertData(
                table: "conventioncategory",
                columns: new[] { "Id", "Description", "ImagePath", "Name" },
                values: new object[,]
                {
                    { new Guid("1f8b5582-5b5e-4637-9830-a817248272b7"), "Viva algo novo! Confira as opções de passeios turísticos, atividades ao ar livre, tours, museus, exposições... Experiências culturais para todos os gostos.", "\\img\\conventionCategory\\passeiosetours.jpg", "Passeios e Tours" },
                    { new Guid("49c9b7a5-e01a-4583-b768-c789f658935f"), "Encontrar os amigos na balada, curtir música boa em um festival ou ver o show do seu artista favorito na sua cidade: escolha sua festa na Moment e aproveite!", "\\img\\conventionCategory\\festaseshows.jpg", "Festas e Shows" },
                    { new Guid("52f22ade-63b5-4d6d-b8a6-6638a6992c6d"), "Encontre a programação dos melhores shows de stand up comedy que estão em cartaz na sua cidade e se divirta com a Sympla. Aproveite com os amigos essa experiência!", "\\img\\conventionCategory\\standupcomedy.jpg", "Stand up Comedy" },
                    { new Guid("a6af579d-0854-4fee-b1e0-094a3482a165"), "Do básico ao avançado, da informática à programação. Encontre aqui cursos, palestras, treinamentos, hackathon e diversos eventos de tecnologia.", "\\img\\conventionCategory\\tecnologia.jpg", "Tecnologia" },
                    { new Guid("bb71a95e-c3d7-4fa6-a6fd-6e34be0f3cb7"), "Apreciar uma peça de teatro, admirar um espetáculo em um teatro histórico ou conhecer uma cultura diferente da sua. Descubra os melhores eventos culturais da sua cidade e viva novas experiências.", "\\img\\conventionCategory\\teatroseespetaculos.jpg", "Teatros e Espetáculos" }
                });
        }
    }
}
