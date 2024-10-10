using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RWA.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTenantDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantDetails_Tenants_TenantId",
                table: "TenantDetails");

            migrationBuilder.DropIndex(
                name: "IX_TenantDetails_TenantId",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "TenantDetails");

            migrationBuilder.AlterColumn<string>(
                name: "TenantIdOriginal",
                table: "Tenants",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "TenantIdOriginal",
                table: "TenantDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Tenants_TenantIdOriginal",
                table: "Tenants",
                column: "TenantIdOriginal");

            migrationBuilder.CreateIndex(
                name: "IX_TenantDetails_TenantIdOriginal",
                table: "TenantDetails",
                column: "TenantIdOriginal");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantDetails_Tenants_TenantIdOriginal",
                table: "TenantDetails",
                column: "TenantIdOriginal",
                principalTable: "Tenants",
                principalColumn: "TenantIdOriginal",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TenantDetails_Tenants_TenantIdOriginal",
                table: "TenantDetails");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Tenants_TenantIdOriginal",
                table: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_TenantDetails_TenantIdOriginal",
                table: "TenantDetails");

            migrationBuilder.AlterColumn<string>(
                name: "TenantIdOriginal",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "TenantIdOriginal",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "TenantDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TenantDetails_TenantId",
                table: "TenantDetails",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantDetails_Tenants_TenantId",
                table: "TenantDetails",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
