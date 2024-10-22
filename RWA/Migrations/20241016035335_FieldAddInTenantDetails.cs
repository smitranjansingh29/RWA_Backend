using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RWA.Migrations
{
    /// <inheritdoc />
    public partial class FieldAddInTenantDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nameOfTenFather",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tenCaste",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tenCorAddress",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "tenDOB",
                table: "TenantDetails",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "tenOcc",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "tenPOI",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tenPerAddress",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "nameOfTenFather",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "tenCaste",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "tenCorAddress",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "tenDOB",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "tenOcc",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "tenPOI",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "tenPerAddress",
                table: "TenantDetails");
        }
    }
}
