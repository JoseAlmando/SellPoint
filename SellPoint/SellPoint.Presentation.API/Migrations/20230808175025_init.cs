using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellPoint.Presentation.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserNameEntidad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PasswordEntidad = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    IdEntidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Localidad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    TipoEntidad = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    TipoDocumento = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: true),
                    NumeroDocumento = table.Column<long>(type: "bigint", nullable: true),
                    Telefonos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    URLPaginaWeb = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    URLFacebook = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    URLInstagram = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    URLTwitter = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    URLTiktok = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    CodPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CoordenadasGPS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    LimiteCredito = table.Column<double>(type: "float", nullable: true),
                    RolUserEntidad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    NoEliminable = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.IdEntidad);
                    table.ForeignKey(
                        name: "FK_Entidades_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_Descripcion",
                table: "Entidades",
                column: "Descripcion");

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_IdUser",
                table: "Entidades",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserNameEntidad",
                table: "User",
                column: "UserNameEntidad",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
