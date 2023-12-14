using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunamis_API.Migrations
{
    public partial class Create_Table_Veiculo_Insert_Cadastros_Defaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modelo = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MotoristaId = table.Column<int>(type: "int", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 240, 172, 190, 236, 138, 147, 102, 174, 109, 12, 184, 141, 111, 180, 123, 148, 230, 178, 196, 61, 118, 178, 29, 214, 248, 80, 139, 163, 167, 33, 32, 192, 166, 135, 147, 45, 155, 149, 204, 56, 102, 31, 255, 29, 73, 7, 143, 5, 225, 231, 71, 249, 231, 144, 160, 205, 137, 168, 218, 202, 212, 208, 43, 53 }, new byte[] { 45, 177, 78, 231, 114, 251, 123, 240, 202, 161, 56, 123, 217, 222, 197, 31, 102, 165, 5, 239, 220, 241, 54, 190, 248, 35, 48, 232, 90, 215, 116, 244 } });

            migrationBuilder.InsertData(
                table: "Veiculo",
                columns: new[] { "Id", "Modelo", "MotoristaId", "Placa" },
                values: new object[,]
                {
                    { 1, "Mercedes-Benz", 1, "SBB7G54" },
                    { 2, "Scania", 3, "DMO5G97" },
                    { 3, " Volvo FH", 2, "BOO5G12" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 215, 196, 133, 80, 253, 244, 254, 163, 235, 7, 30, 140, 240, 182, 223, 192, 172, 203, 114, 240, 145, 124, 250, 225, 109, 221, 144, 242, 246, 125, 131, 222, 133, 127, 109, 169, 236, 25, 181, 20, 223, 64, 29, 15, 84, 231, 32, 249, 33, 41, 117, 86, 139, 61, 175, 97, 197, 98, 252, 73, 120, 25, 104, 82 }, new byte[] { 27, 167, 180, 213, 56, 69, 138, 48, 93, 159, 40, 172, 176, 80, 239, 135, 189, 41, 151, 105, 200, 224, 15, 185, 192, 135, 178, 176, 29, 15, 113, 94 } });
        }
    }
}
