using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class BetterCalmDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Playlists",
                columns: table => new
                {
                    PlaylistDtoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlists", x => x.PlaylistDtoID);
                });

            migrationBuilder.CreateTable(
                name: "Problematics",
                columns: table => new
                {
                    ProblematicDtoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problematics", x => x.ProblematicDtoID);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    SongDtoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlAudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaylistDtoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.SongDtoID);
                    table.ForeignKey(
                        name: "FK_Songs_Playlists_PlaylistDtoID",
                        column: x => x.PlaylistDtoID,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistDtoID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryDtoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SongDtoID = table.Column<int>(type: "int", nullable: true),
                    PlaylistDtoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryDtoID);
                    table.ForeignKey(
                        name: "FK_Categories_Playlists_PlaylistDtoID",
                        column: x => x.PlaylistDtoID,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistDtoID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Categories_Songs_SongDtoID",
                        column: x => x.SongDtoID,
                        principalTable: "Songs",
                        principalColumn: "SongDtoID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PlaylistDtoID",
                table: "Categories",
                column: "PlaylistDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_SongDtoID",
                table: "Categories",
                column: "SongDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistDtoID",
                table: "Songs",
                column: "PlaylistDtoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Problematics");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
