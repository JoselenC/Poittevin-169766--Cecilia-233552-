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
                name: "FK_Categories_Audios_AudioDtoID",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Audios_Playlists_PlaylistDtoID",
                table: "Audios");

            migrationBuilder.DropIndex(
                name: "IX_Audios_PlaylistDtoID",
                table: "Audios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.DropIndex(
                name: "IX_Categories_PlaylistDtoID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_AudioDtoID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "PlaylistDtoID",
                table: "Audios");

            migrationBuilder.DropColumn(
                name: "PlaylistDtoID",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AudioDtoID",
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
                name: "PlaylistAudioDto",
                columns: table => new
                {
                    AudioID = table.Column<int>(type: "int", nullable: false),
                    PlaylistID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistAudioDto", x => new { x.PlaylistID, x.AudioID });
                    table.ForeignKey(
                        name: "FK_PlaylistAudioDto_Playlists_PlaylistID",
                        column: x => x.PlaylistID,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistDtoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistAudioDto_Audios_AudioID",
                        column: x => x.AudioID,
                        principalTable: "Audios",
                        principalColumn: "AudioDtoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioCategoryDto",
                columns: table => new
                {
                    AudioID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioCategoryDto", x => new { x.AudioID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_AudioCategoryDto_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryDtoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AudioCategoryDto_Audios_AudioID",
                        column: x => x.AudioID,
                        principalTable: "Audios",
                        principalColumn: "AudioDtoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistCategoryDto_CategoryID",
                table: "PlaylistCategoryDto",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistAudioDto_AudioID",
                table: "PlaylistAudioDto",
                column: "AudioID");

            migrationBuilder.CreateIndex(
                name: "IX_AudioCategoryDto_CategoryID",
                table: "AudioCategoryDto",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaylistCategoryDto");

            migrationBuilder.DropTable(
                name: "PlaylistAudioDto");

            migrationBuilder.DropTable(
                name: "AudioCategoryDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.AddColumn<int>(
                name: "PlaylistDtoID",
                table: "Audios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlaylistDtoID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AudioDtoID",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                columns: new[] { "PsychologistId", "PatientId" });

            migrationBuilder.CreateIndex(
                name: "IX_Audios_PlaylistDtoID",
                table: "Audios",
                column: "PlaylistDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PlaylistDtoID",
                table: "Categories",
                column: "PlaylistDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AudioDtoID",
                table: "Categories",
                column: "AudioDtoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Playlists_PlaylistDtoID",
                table: "Categories",
                column: "PlaylistDtoID",
                principalTable: "Playlists",
                principalColumn: "PlaylistDtoID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Audios_AudioDtoID",
                table: "Categories",
                column: "AudioDtoID",
                principalTable: "Audios",
                principalColumn: "AudioDtoID",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Audios_Playlists_PlaylistDtoID",
                table: "Audios",
                column: "PlaylistDtoID",
                principalTable: "Playlists",
                principalColumn: "PlaylistDtoID",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
