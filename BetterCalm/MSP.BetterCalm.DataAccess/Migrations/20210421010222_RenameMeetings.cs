using Microsoft.EntityFrameworkCore.Migrations;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    public partial class RenameMeetings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MeetingDto_Patients_PatientId",
                table: "MeetingDto");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingDto_Psychologists_PsychologistId",
                table: "MeetingDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeetingDto",
                table: "MeetingDto");

            migrationBuilder.RenameTable(
                name: "MeetingDto",
                newName: "Meeting");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingDto_PatientId",
                table: "Meeting",
                newName: "IX_Meeting_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting",
                columns: new[] { "PsychologistId", "PatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Patients_PatientId",
                table: "Meeting",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientDtoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meeting_Psychologists_PsychologistId",
                table: "Meeting",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "PsychologistDtoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Patients_PatientId",
                table: "Meeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Meeting_Psychologists_PsychologistId",
                table: "Meeting");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meeting",
                table: "Meeting");

            migrationBuilder.RenameTable(
                name: "Meeting",
                newName: "MeetingDto");

            migrationBuilder.RenameIndex(
                name: "IX_Meeting_PatientId",
                table: "MeetingDto",
                newName: "IX_MeetingDto_PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeetingDto",
                table: "MeetingDto",
                columns: new[] { "PsychologistId", "PatientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingDto_Patients_PatientId",
                table: "MeetingDto",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientDtoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingDto_Psychologists_PsychologistId",
                table: "MeetingDto",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "PsychologistDtoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
