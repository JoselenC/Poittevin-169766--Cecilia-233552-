using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class AddMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematic_Problematics_PsychologistId",
                table: "PsychologistProblematic");

            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematic_Psychologists_ProblematicId",
                table: "PsychologistProblematic");

            migrationBuilder.CreateTable(
                name: "MeetingDto",
                columns: table => new
                {
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetingDto", x => new { x.PsychologistId, x.PatientId });
                    table.ForeignKey(
                        name: "FK_MeetingDto_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientDtoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeetingDto_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "PsychologistDtoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetingDto_PatientId",
                table: "MeetingDto",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematic_Problematics_ProblematicId",
                table: "PsychologistProblematic",
                column: "ProblematicId",
                principalTable: "Problematics",
                principalColumn: "ProblematicDtoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematic_Psychologists_PsychologistId",
                table: "PsychologistProblematic",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "PsychologistDtoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematic_Problematics_ProblematicId",
                table: "PsychologistProblematic");

            migrationBuilder.DropForeignKey(
                name: "FK_PsychologistProblematic_Psychologists_PsychologistId",
                table: "PsychologistProblematic");

            migrationBuilder.DropTable(
                name: "MeetingDto");

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematic_Problematics_PsychologistId",
                table: "PsychologistProblematic",
                column: "PsychologistId",
                principalTable: "Problematics",
                principalColumn: "ProblematicDtoID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PsychologistProblematic_Psychologists_ProblematicId",
                table: "PsychologistProblematic",
                column: "ProblematicId",
                principalTable: "Psychologists",
                principalColumn: "PsychologistDtoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
