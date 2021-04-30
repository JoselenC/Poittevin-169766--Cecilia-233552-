using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorDtoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserDtoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorDtoId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientDtoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cellphone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserDtoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientDtoId);
                });

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
                name: "Psychologists",
                columns: table => new
                {
                    PsychologistDtoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorksOnline = table.Column<bool>(type: "bit", nullable: false),
                    UserDtoId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologists", x => x.PsychologistDtoId);
                });

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    AudioDtoID = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Audios", x => x.AudioDtoID);
                    table.ForeignKey(
                        name: "FK_Audios_Playlists_PlaylistDtoID",
                        column: x => x.PlaylistDtoID,
                        principalTable: "Playlists",
                        principalColumn: "PlaylistDtoID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistProblematic",
                columns: table => new
                {
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    ProblematicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistProblematic", x => new { x.PsychologistId, x.ProblematicId });
                    table.ForeignKey(
                        name: "FK_PsychologistProblematic_Problematics_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Problematics",
                        principalColumn: "ProblematicDtoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistProblematic_Psychologists_ProblematicId",
                        column: x => x.ProblematicId,
                        principalTable: "Psychologists",
                        principalColumn: "PsychologistDtoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryDtoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AudioDtoID = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_Categories_Audios_AudioDtoID",
                        column: x => x.AudioDtoID,
                        principalTable: "Audios",
                        principalColumn: "AudioDtoID",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_PlaylistDtoID",
                table: "Categories",
                column: "PlaylistDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_AudioDtoID",
                table: "Categories",
                column: "AudioDtoID");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistProblematic_ProblematicId",
                table: "PsychologistProblematic",
                column: "ProblematicId");

            migrationBuilder.CreateIndex(
                name: "IX_Audios_PlaylistDtoID",
                table: "Audios",
                column: "PlaylistDtoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "PsychologistProblematic");

            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.DropTable(
                name: "Problematics");

            migrationBuilder.DropTable(
                name: "Psychologists");

            migrationBuilder.DropTable(
                name: "Playlists");
        }
    }
}
