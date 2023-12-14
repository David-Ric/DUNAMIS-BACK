using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunamis_API.Migrations
{
    public partial class Create_Table_Motorista_Insert_Cadastros_Defaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nome = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fone = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Motorista",
                columns: new[] { "Id", "Cpf", "Email", "Fone", "Nome" },
                values: new object[,]
                {
                    { 1, "93245678954", "julio_rob@gmail.com", "21998765439", "Julio Roberto Torres" },
                    { 2, "94215678943", "paulo7789@gmail.com", "11987432167", "Paulo Morais Torres" },
                    { 3, "94943256789", "jose_mata@gmail.com", "85986541234", "Jose da Mata Mourinho" }
                });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 184, 119, 147, 10, 147, 7, 46, 150, 182, 87, 175, 0, 140, 169, 232, 64, 180, 28, 105, 166, 28, 184, 237, 118, 188, 40, 41, 221, 58, 174, 166, 126, 208, 184, 13, 177, 20, 189, 23, 69, 109, 245, 30, 179, 231, 180, 50, 57, 171, 17, 29, 103, 187, 217, 69, 122, 88, 102, 63, 9, 26, 207, 73, 153 }, new byte[] { 123, 50, 46, 18, 45, 148, 163, 136, 13, 27, 173, 253, 143, 245, 123, 87, 99, 132, 62, 197, 144, 183, 66, 82, 140, 28, 156, 182, 106, 199, 141, 99 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 195, 2, 74, 43, 172, 86, 212, 181, 114, 51, 61, 133, 103, 130, 56, 160, 46, 204, 86, 10, 178, 162, 36, 133, 157, 118, 90, 2, 239, 249, 78, 30, 196, 200, 134, 168, 240, 52, 229, 167, 79, 239, 71, 208, 159, 253, 121, 6, 138, 110, 230, 32, 201, 30, 97, 123, 5, 27, 33, 205, 154, 75, 58, 164 }, new byte[] { 62, 251, 188, 218, 115, 169, 220, 159, 91, 151, 209, 27, 248, 225, 243, 23, 182, 2, 93, 245, 198, 19, 28, 43, 74, 6, 51, 246, 6, 74, 125, 170 } });
        }
    }
}
