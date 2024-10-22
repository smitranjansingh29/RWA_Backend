using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RWA.Migrations
{
    /// <inheritdoc />
    public partial class AddFileFieldsToTenantDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "tenPerAddress",
                table: "TenantDetails",
                newName: "TenPerAddress");

            migrationBuilder.RenameColumn(
                name: "tenPOI",
                table: "TenantDetails",
                newName: "TenPOI");

            migrationBuilder.RenameColumn(
                name: "tenOcc",
                table: "TenantDetails",
                newName: "TenOcc");

            migrationBuilder.RenameColumn(
                name: "tenDOB",
                table: "TenantDetails",
                newName: "TenDOB");

            migrationBuilder.RenameColumn(
                name: "tenCorAddress",
                table: "TenantDetails",
                newName: "TenCorAddress");

            migrationBuilder.RenameColumn(
                name: "tenCaste",
                table: "TenantDetails",
                newName: "TenCaste");

            migrationBuilder.RenameColumn(
                name: "nameOfTenFather",
                table: "TenantDetails",
                newName: "NameOfTenFather");

            migrationBuilder.AddColumn<string>(
                name: "AmtOfAnnFee",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AmtOfMemFee",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnnFav",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnnFeesNumber",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AnnYear",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CasteCert",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateOfAnnFee",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DateOfMemFee",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionDate",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionMemberAddress",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionMemberAge",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionMemberFather",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionMemberName",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionMemberType",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DecisionPlace",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeedCopy",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemAddress",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemAge",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemFatherName",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemFav",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemFeesNumber",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MemName",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProofDOBDoc",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RDate",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RMemName",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RMemNumber",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RPlace",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ResolutionNumber",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenPOA",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenPhoto",
                table: "TenantDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmtOfAnnFee",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "AmtOfMemFee",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "AnnFav",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "AnnFeesNumber",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "AnnYear",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "CasteCert",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DateOfAnnFee",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DateOfMemFee",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DecisionDate",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DecisionMemberAddress",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DecisionMemberAge",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DecisionMemberFather",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DecisionMemberName",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DecisionMemberType",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DecisionPlace",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "DeedCopy",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "MemAddress",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "MemAge",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "MemFatherName",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "MemFav",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "MemFeesNumber",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "MemName",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "ProofDOBDoc",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "RDate",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "RMemName",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "RMemNumber",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "RPlace",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "ResolutionNumber",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "TenPOA",
                table: "TenantDetails");

            migrationBuilder.DropColumn(
                name: "TenPhoto",
                table: "TenantDetails");

            migrationBuilder.RenameColumn(
                name: "TenPerAddress",
                table: "TenantDetails",
                newName: "tenPerAddress");

            migrationBuilder.RenameColumn(
                name: "TenPOI",
                table: "TenantDetails",
                newName: "tenPOI");

            migrationBuilder.RenameColumn(
                name: "TenOcc",
                table: "TenantDetails",
                newName: "tenOcc");

            migrationBuilder.RenameColumn(
                name: "TenDOB",
                table: "TenantDetails",
                newName: "tenDOB");

            migrationBuilder.RenameColumn(
                name: "TenCorAddress",
                table: "TenantDetails",
                newName: "tenCorAddress");

            migrationBuilder.RenameColumn(
                name: "TenCaste",
                table: "TenantDetails",
                newName: "tenCaste");

            migrationBuilder.RenameColumn(
                name: "NameOfTenFather",
                table: "TenantDetails",
                newName: "nameOfTenFather");
        }
    }
}
