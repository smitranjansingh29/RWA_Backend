using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RWA.Migrations
{
    /// <inheritdoc />
    public partial class AddNameUpdateTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenantWhatsappNumber",
                table: "Tenants",
                newName: "TenWhatsappNum");

            migrationBuilder.RenameColumn(
                name: "TenantPhoneNumber",
                table: "Tenants",
                newName: "TenPhoneNum");

            migrationBuilder.RenameColumn(
                name: "TenantName",
                table: "Tenants",
                newName: "TenName");

            migrationBuilder.RenameColumn(
                name: "TenantFlatNumber",
                table: "Tenants",
                newName: "TenMail");

            migrationBuilder.RenameColumn(
                name: "TenantEmail",
                table: "Tenants",
                newName: "TenFlatNum");

            migrationBuilder.RenameColumn(
                name: "PoliceVerification",
                table: "TenantDetails",
                newName: "TenPoliceVer");

            migrationBuilder.RenameColumn(
                name: "PAN",
                table: "TenantDetails",
                newName: "TenPAN");

            migrationBuilder.RenameColumn(
                name: "Aadhar",
                table: "TenantDetails",
                newName: "TenAdhar");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TenWhatsappNum",
                table: "Tenants",
                newName: "TenantWhatsappNumber");

            migrationBuilder.RenameColumn(
                name: "TenPhoneNum",
                table: "Tenants",
                newName: "TenantPhoneNumber");

            migrationBuilder.RenameColumn(
                name: "TenName",
                table: "Tenants",
                newName: "TenantName");

            migrationBuilder.RenameColumn(
                name: "TenMail",
                table: "Tenants",
                newName: "TenantFlatNumber");

            migrationBuilder.RenameColumn(
                name: "TenFlatNum",
                table: "Tenants",
                newName: "TenantEmail");

            migrationBuilder.RenameColumn(
                name: "TenPoliceVer",
                table: "TenantDetails",
                newName: "PoliceVerification");

            migrationBuilder.RenameColumn(
                name: "TenPAN",
                table: "TenantDetails",
                newName: "PAN");

            migrationBuilder.RenameColumn(
                name: "TenAdhar",
                table: "TenantDetails",
                newName: "Aadhar");
        }
    }
}
