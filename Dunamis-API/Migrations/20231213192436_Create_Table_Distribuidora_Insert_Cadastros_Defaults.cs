using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunamis_API.Migrations
{
    public partial class Create_Table_Distribuidora_Insert_Cadastros_Defaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Distribuidora",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cnpj = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Razao_Social = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fone = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Logradouro = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Municipio = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distribuidora", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Distribuidora",
                columns: new[] { "Id", "Cnpj", "Email", "Fone", "Logradouro", "Municipio", "Razao_Social", "Uf" },
                values: new object[,]
                {
                    { 1, "16870304000140", "mirante@gmail.com", "45998761234", "Rua Ulises Cerpa,78", "São José dos Pinhais", "Mirante Distribuidora de Grâos", "PR" },
                    { 2, "17493153000110", "adailton@gmail.com", "12997323456", "Rua Pablo Goias,133 - Lote 07", "Bueguesia", "Adailto Souza de Melo", "ES" },
                    { 3, "36411834000137", "muriel324@gmail.com", "45998764532", "Rua Colina Santa", "Morteiro", "Antonio Muriel Matoso", "PR" }
                });

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 215, 196, 133, 80, 253, 244, 254, 163, 235, 7, 30, 140, 240, 182, 223, 192, 172, 203, 114, 240, 145, 124, 250, 225, 109, 221, 144, 242, 246, 125, 131, 222, 133, 127, 109, 169, 236, 25, 181, 20, 223, 64, 29, 15, 84, 231, 32, 249, 33, 41, 117, 86, 139, 61, 175, 97, 197, 98, 252, 73, 120, 25, 104, 82 }, new byte[] { 27, 167, 180, 213, 56, 69, 138, 48, 93, 159, 40, 172, 176, 80, 239, 135, 189, 41, 151, 105, 200, 224, 15, 185, 192, 135, 178, 176, 29, 15, 113, 94 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Distribuidora");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 184, 119, 147, 10, 147, 7, 46, 150, 182, 87, 175, 0, 140, 169, 232, 64, 180, 28, 105, 166, 28, 184, 237, 118, 188, 40, 41, 221, 58, 174, 166, 126, 208, 184, 13, 177, 20, 189, 23, 69, 109, 245, 30, 179, 231, 180, 50, 57, 171, 17, 29, 103, 187, 217, 69, 122, 88, 102, 63, 9, 26, 207, 73, 153 }, new byte[] { 123, 50, 46, 18, 45, 148, 163, 136, 13, 27, 173, 253, 143, 245, 123, 87, 99, 132, 62, 197, 144, 183, 66, 82, 140, 28, 156, 182, 106, 199, 141, 99 } });
        }
    }
}
