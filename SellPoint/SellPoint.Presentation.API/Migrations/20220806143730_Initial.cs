using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SellPoint.Presentation.API.Migrations
{
    public partial class Initial : Migration
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
                    PasswordEntidad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
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
                    Descripcion = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localidad = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TipoEntidad = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    NumeroDocumento = table.Column<long>(type: "bigint", maxLength: 15, nullable: false),
                    Telefonos = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    URLPaginaWeb = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    URLFacebook = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    URLInstagram = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    URLTwitter = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    URLTiktok = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CoordenadasGPS = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LimiteCredito = table.Column<double>(type: "float", maxLength: 15, nullable: false),
                    RolUserEntidad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_Descripcion",
                table: "Entidades",
                column: "Descripcion");

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_IdUser",
                table: "Entidades",
                column: "IdUser");
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
