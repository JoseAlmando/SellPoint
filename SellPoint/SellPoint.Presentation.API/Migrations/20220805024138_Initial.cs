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
                name: "GrupoEntidad",
                columns: table => new
                {
                    IdGruposEntidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoEliminable = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrupoEntidad", x => x.IdGruposEntidad);
                });

            migrationBuilder.CreateTable(
                name: "TipoEntidad",
                columns: table => new
                {
                    IdTipoEntidad = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoEliminable = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdGrupoEntidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoEntidad", x => x.IdTipoEntidad);
                    table.ForeignKey(
                        name: "FK_TipoEntidad_GrupoEntidad_IdGrupoEntidad",
                        column: x => x.IdGrupoEntidad,
                        principalTable: "GrupoEntidad",
                        principalColumn: "IdGruposEntidad",
                        onDelete: ReferentialAction.NoAction);
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
                    UserNameEntidad = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    PasswordEntidad = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RolUserEntidad = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NoEliminable = table.Column<bool>(type: "bit", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdGrupoEntidad = table.Column<int>(type: "int", nullable: false),
                    IdTipoEntidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.IdEntidad);
                    table.ForeignKey(
                        name: "FK_Entidades_GrupoEntidad_IdGrupoEntidad",
                        column: x => x.IdGrupoEntidad,
                        principalTable: "GrupoEntidad",
                        principalColumn: "IdGruposEntidad",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Entidades_TipoEntidad_IdTipoEntidad",
                        column: x => x.IdTipoEntidad,
                        principalTable: "TipoEntidad",
                        principalColumn: "IdTipoEntidad",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_Descripcion",
                table: "Entidades",
                column: "Descripcion");

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_IdGrupoEntidad",
                table: "Entidades",
                column: "IdGrupoEntidad");

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_IdTipoEntidad",
                table: "Entidades",
                column: "IdTipoEntidad");

            migrationBuilder.CreateIndex(
                name: "IX_TipoEntidad_IdGrupoEntidad",
                table: "TipoEntidad",
                column: "IdGrupoEntidad");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "TipoEntidad");

            migrationBuilder.DropTable(
                name: "GrupoEntidad");
        }
    }
}
