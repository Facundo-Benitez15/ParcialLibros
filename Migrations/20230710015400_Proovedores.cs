using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParcialLibros.Migrations
{
    /// <inheritdoc />
    public partial class Proovedores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proovedor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proovedor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LibrosProovedores",
                columns: table => new
                {
                    LibrosId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProovedoresId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibrosProovedores", x => new { x.LibrosId, x.ProovedoresId });
                    table.ForeignKey(
                        name: "FK_LibrosProovedores_Libro_LibrosId",
                        column: x => x.LibrosId,
                        principalTable: "Libro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibrosProovedores_Proovedor_ProovedoresId",
                        column: x => x.ProovedoresId,
                        principalTable: "Proovedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LibrosProovedores_ProovedoresId",
                table: "LibrosProovedores",
                column: "ProovedoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibrosProovedores");

            migrationBuilder.DropTable(
                name: "Proovedor");
        }
    }
}
