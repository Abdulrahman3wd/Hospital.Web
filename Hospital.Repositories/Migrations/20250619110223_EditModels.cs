using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class EditModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hospitals_HospitalId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "HospitalId",
                table: "Rooms",
                newName: "HospitalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HospitalId",
                table: "Rooms",
                newName: "IX_Rooms_HospitalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hospitals_HospitalInfoId",
                table: "Rooms",
                column: "HospitalInfoId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Hospitals_HospitalInfoId",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "HospitalInfoId",
                table: "Rooms",
                newName: "HospitalId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_HospitalInfoId",
                table: "Rooms",
                newName: "IX_Rooms_HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Hospitals_HospitalId",
                table: "Rooms",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
