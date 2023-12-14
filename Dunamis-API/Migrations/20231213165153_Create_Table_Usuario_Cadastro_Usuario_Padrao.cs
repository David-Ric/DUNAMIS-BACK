using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunamis_API.Migrations
{
    public partial class Create_Table_Usuario_Cadastro_Usuario_Padrao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NomeCompleto = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PasswordHash = table.Column<byte[]>(type: "longblob", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "longblob", nullable: false),
                    RefreshToken = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TokenCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VerificationToken = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VerifiedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResetTokenExpires = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Funcao = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Email", "Funcao", "NomeCompleto", "PasswordHash", "PasswordResetToken", "PasswordSalt", "RefreshToken", "ResetTokenExpires", "Status", "Telefone", "TokenCreated", "TokenExpires", "Username", "VerificationToken", "VerifiedAt" },
                values: new object[] { 1, "dunamis@dunamis.com.brr", "Administrador do Sistema", "Dunamis", new byte[] { 195, 2, 74, 43, 172, 86, 212, 181, 114, 51, 61, 133, 103, 130, 56, 160, 46, 204, 86, 10, 178, 162, 36, 133, 157, 118, 90, 2, 239, 249, 78, 30, 196, 200, 134, 168, 240, 52, 229, 167, 79, 239, 71, 208, 159, 253, 121, 6, 138, 110, 230, 32, 201, 30, 97, 123, 5, 27, 33, 205, 154, 75, 58, 164 }, null, new byte[] { 62, 251, 188, 218, 115, 169, 220, 159, 91, 151, 209, 27, 248, 225, 243, 23, 182, 2, 93, 245, 198, 19, 28, 43, 74, 6, 51, 246, 6, 74, 125, 170 }, "", null, "1", "(85) 3333-3333", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "dunamis", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
