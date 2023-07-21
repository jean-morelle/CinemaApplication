using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaApplication.Migrations
{
    public partial class Debut : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieDuFilms",
                columns: table => new
                {
                    CategorieDuFilmId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreDuFilm = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieDuFilms", x => x.CategorieDuFilmId);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnneeDeSortie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategorieDeFilm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixDAchatDuFilm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategorieDuFilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_CategorieDuFilms_CategorieDuFilmId",
                        column: x => x.CategorieDuFilmId,
                        principalTable: "CategorieDuFilms",
                        principalColumn: "CategorieDuFilmId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategorieDuFilmId",
                table: "Films",
                column: "CategorieDuFilmId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "CategorieDuFilms");
        }
    }
}
