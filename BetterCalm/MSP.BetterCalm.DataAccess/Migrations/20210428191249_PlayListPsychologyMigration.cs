using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class PlayListPsychologyMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Playlists_PlaylistDtoID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Songs_SongDtoID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Playlists_PlaylistDtoID",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_PlaylistDtoID",
                table: "Songs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PlaylistDtoID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_SongDtoID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PlaylistDtoID",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "PlaylistDtoID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SongDtoID",
                table: "Categories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                columns: new[] { "PsychologistId", "PatientId", "DateTime" });

            migrationBuilder.CreateTable(
                name: "PlaylistCategoryDto",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    PlaylistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistCategoryDto", x => new { x.PlaylistID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_PlaylistCategoryDto_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryDtoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistCategoryDto_Playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistDtoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistSongDto",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "int", nullable: false),
                    PlaylistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistSongDto", x => new { x.PlaylistID, x.SongID });
                    table.ForeignKey(
                        name: "FK_PlaylistSongDto_Playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistDtoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistSongDto_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongDtoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongCategoryDto",
                columns: table => new
                {
                    SongID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongCategoryDto", x => new { x.SongID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_SongCategoryDto_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryDtoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongCategoryDto_Songs_SongID",
                        column: x => x.SongID,
                        principalTable: "Songs",
                        principalColumn: "SongDtoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistCategoryDto_CategoryID",
                table: "PlaylistCategoryDto",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistSongDto_SongID",
                table: "PlaylistSongDto",
                column: "SongID");

            migrationBuilder.CreateIndex(
                name: "IX_SongCategoryDto_CategoryID",
                table: "SongCategoryDto",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistCategoryDto");

            migrationBuilder.DropTable(
                name: "PlaylistSongDto");

            migrationBuilder.DropTable(
                name: "SongCategoryDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistDtoID",
                table: "Songs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistDtoID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SongDtoID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                columns: new[] { "PsychologistId", "PatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistDtoID",
                table: "Songs",
                column: "PlaylistDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PlaylistDtoID",
                table: "Categories",
                column: "PlaylistDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SongDtoID",
                table: "Categories",
                column: "SongDtoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Playlists_PlaylistDtoID",
                table: "Categories",
                column: "PlaylistDtoID",
                principalTable: "Playlists",
                principalColumn: "PlaylistDtoID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Songs_SongDtoID",
                table: "Categories",
                column: "SongDtoID",
                principalTable: "Songs",
                principalColumn: "SongDtoID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Playlists_PlaylistDtoID",
                table: "Songs",
                column: "PlaylistDtoID",
                principalTable: "Playlists",
                principalColumn: "PlaylistDtoID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
