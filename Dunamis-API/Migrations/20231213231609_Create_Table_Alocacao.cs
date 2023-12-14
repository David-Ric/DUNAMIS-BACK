using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dunamis_API.Migrations
{
    public partial class Create_Table_Alocacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alocacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VeiculoId = table.Column<int>(type: "int", nullable: true),
                    DistribuidoraId = table.Column<int>(type: "int", nullable: true),
                    Carga = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Peso = table.Column<int>(type: "int", nullable: true),
                    Obs = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Entrada = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Checado = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Saída = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alocacao_Distribuidora_DistribuidoraId",
                        column: x => x.DistribuidoraId,
                        principalTable: "Distribuidora",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Alocacao_Veiculo_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculo",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 30, 94, 187, 34, 247, 70, 172, 0, 58, 2, 32, 17, 247, 113, 64, 68, 250, 140, 255, 70, 112, 75, 32, 215, 76, 131, 96, 35, 13, 204, 185, 248, 238, 105, 60, 35, 248, 122, 109, 95, 73, 129, 175, 234, 18, 146, 180, 65, 49, 103, 109, 213, 27, 251, 178, 40, 203, 249, 145, 15, 21, 69, 142, 80 }, new byte[] { 238, 196, 132, 205, 150, 153, 251, 176, 104, 145, 177, 227, 235, 204, 184, 151, 15, 9, 47, 85, 5, 240, 87, 72, 217, 51, 249, 133, 186, 142, 21, 20 } });

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_MotoristaId",
                table: "Veiculo",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacao_DistribuidoraId",
                table: "Alocacao",
                column: "DistribuidoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacao_VeiculoId",
                table: "Alocacao",
                column: "VeiculoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculo_Motorista_MotoristaId",
                table: "Veiculo",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Veiculo_Motorista_MotoristaId",
                table: "Veiculo");

            migrationBuilder.DropTable(
                name: "Alocacao");

            migrationBuilder.DropIndex(
                name: "IX_Veiculo_MotoristaId",
                table: "Veiculo");

            migrationBuilder.UpdateData(
                table: "Usuario",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 240, 172, 190, 236, 138, 147, 102, 174, 109, 12, 184, 141, 111, 180, 123, 148, 230, 178, 196, 61, 118, 178, 29, 214, 248, 80, 139, 163, 167, 33, 32, 192, 166, 135, 147, 45, 155, 149, 204, 56, 102, 31, 255, 29, 73, 7, 143, 5, 225, 231, 71, 249, 231, 144, 160, 205, 137, 168, 218, 202, 212, 208, 43, 53 }, new byte[] { 45, 177, 78, 231, 114, 251, 123, 240, 202, 161, 56, 123, 217, 222, 197, 31, 102, 165, 5, 239, 220, 241, 54, 190, 248, 35, 48, 232, 90, 215, 116, 244 } });
        }
    }
}
