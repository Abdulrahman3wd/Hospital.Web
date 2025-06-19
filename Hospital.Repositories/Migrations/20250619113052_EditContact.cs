using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class EditContact : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Hospitals_HospitalId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "HospitalId",
                table: "Contacts",
                newName: "HospitalInfoId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_HospitalId",
                table: "Contacts",
                newName: "IX_Contacts_HospitalInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Hospitals_HospitalInfoId",
                table: "Contacts",
                column: "HospitalInfoId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Hospitals_HospitalInfoId",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "HospitalInfoId",
                table: "Contacts",
                newName: "HospitalId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_HospitalInfoId",
                table: "Contacts",
                newName: "IX_Contacts_HospitalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Hospitals_HospitalId",
                table: "Contacts",
                column: "HospitalId",
                principalTable: "Hospitals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
