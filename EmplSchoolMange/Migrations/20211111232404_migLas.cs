using Microsoft.EntityFrameworkCore.Migrations;

namespace EmplSchoolMange.Migrations
{
    public partial class migLas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_District_DistrictIdd",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DistrictIdd",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DistrictIdd",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DistrictId",
                table: "Employee",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_District_DistrictId",
                table: "Employee",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_District_DistrictId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DistrictId",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "DistrictIdd",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DistrictIdd",
                table: "Employee",
                column: "DistrictIdd");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_District_DistrictIdd",
                table: "Employee",
                column: "DistrictIdd",
                principalTable: "District",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
