using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace TiendaServicios.Api.Autor.Migrations
{
    public partial class MigracionPostgresInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AutorLibro",
                columns: table => new
                {
                    AutorLibroId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: true),
                    AutorLibroGuid = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLibro", x => x.AutorLibroId);
                });

            migrationBuilder.CreateTable(
                name: "GradoAcademico",
                columns: table => new
                {
                    GradoAcademicoId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    CentroAcademico = table.Column<string>(nullable: true),
                    FechaGrado = table.Column<DateTime>(nullable: true),
                    AutorLibroID = table.Column<int>(nullable: false),
                    GradoAcademicoGuid = table.Column<string>(nullable: true),
                    GradoAcademicoId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradoAcademico", x => x.GradoAcademicoId);
                    table.ForeignKey(
                        name: "FK_GradoAcademico_AutorLibro_AutorLibroID",
                        column: x => x.AutorLibroID,
                        principalTable: "AutorLibro",
                        principalColumn: "AutorLibroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GradoAcademico_GradoAcademico_GradoAcademicoId1",
                        column: x => x.GradoAcademicoId1,
                        principalTable: "GradoAcademico",
                        principalColumn: "GradoAcademicoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GradoAcademico_AutorLibroID",
                table: "GradoAcademico",
                column: "AutorLibroID");

            migrationBuilder.CreateIndex(
                name: "IX_GradoAcademico_GradoAcademicoId1",
                table: "GradoAcademico",
                column: "GradoAcademicoId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GradoAcademico");

            migrationBuilder.DropTable(
                name: "AutorLibro");
        }
    }
}
