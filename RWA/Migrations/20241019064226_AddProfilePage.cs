using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RWA.Migrations
{
    /// <inheritdoc />
    public partial class AddProfilePage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TenantDetails_TenantIdOriginal",
                table: "TenantDetails");

            migrationBuilder.AlterColumn<string>(
                name: "TenantIdOriginal",
                table: "TenantDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_TenantDetails_TenantIdOriginal",
                table: "TenantDetails",
                column: "TenantIdOriginal");

            migrationBuilder.CreateTable(
                name: "ProfilePages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantIdOriginal = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CoverPic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Work = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfilePages_TenantDetails_TenantIdOriginal",
                        column: x => x.TenantIdOriginal,
                        principalTable: "TenantDetails",
                        principalColumn: "TenantIdOriginal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePages_TenantIdOriginal",
                table: "ProfilePages",
                column: "TenantIdOriginal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfilePages");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_TenantDetails_TenantIdOriginal",
                table: "TenantDetails");

            migrationBuilder.AlterColumn<string>(
                name: "TenantIdOriginal",
                table: "TenantDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_TenantDetails_TenantIdOriginal",
                table: "TenantDetails",
                column: "TenantIdOriginal");
        }
    }
}
