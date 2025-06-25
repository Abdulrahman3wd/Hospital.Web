using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class EditApplicationUset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDoctor",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientReports_ApplicationUserId",
                table: "PatientReports",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_ApplicationUserId",
                table: "PatientReports",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_ApplicationUserId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports");

            migrationBuilder.DropIndex(
                name: "IX_PatientReports_ApplicationUserId",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "PatientReports");

            migrationBuilder.DropColumn(
                name: "IsDoctor",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "PatientReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
