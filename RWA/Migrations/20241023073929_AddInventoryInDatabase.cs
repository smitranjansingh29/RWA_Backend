using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RWA.Migrations
{
    /// <inheritdoc />
    public partial class AddInventoryInDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InvId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvProduct = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvProductDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvProductPrice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchaseWhere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseWarranty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchasePrice = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InvId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
