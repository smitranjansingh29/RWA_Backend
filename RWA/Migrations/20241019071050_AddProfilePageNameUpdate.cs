using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RWA.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePageNameUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePic",
                table: "ProfilePages",
                newName: "ProfilePhoto");

            migrationBuilder.RenameColumn(
                name: "Interest",
                table: "ProfilePages",
                newName: "Interests");

            migrationBuilder.RenameColumn(
                name: "CoverPic",
                table: "ProfilePages",
                newName: "CoverPhoto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfilePhoto",
                table: "ProfilePages",
                newName: "ProfilePic");

            migrationBuilder.RenameColumn(
                name: "Interests",
                table: "ProfilePages",
                newName: "Interest");

            migrationBuilder.RenameColumn(
                name: "CoverPhoto",
                table: "ProfilePages",
                newName: "CoverPic");
        }
    }
}
