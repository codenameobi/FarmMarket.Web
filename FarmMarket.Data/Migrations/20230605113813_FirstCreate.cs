using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmMarket.Data.Migrations
{
    /// <inheritdoc />
    public partial class FirstCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FarmProducts",
                table: "FarmProducts");

            migrationBuilder.RenameTable(
                name: "FarmProducts",
                newName: "farmproducts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "farmproducts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_farmproducts",
                table: "farmproducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_farmproducts_Name",
                table: "farmproducts",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_farmproducts",
                table: "farmproducts");

            migrationBuilder.DropIndex(
                name: "IX_farmproducts_Name",
                table: "farmproducts");

            migrationBuilder.RenameTable(
                name: "farmproducts",
                newName: "FarmProducts");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "FarmProducts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FarmProducts",
                table: "FarmProducts",
                column: "Id");
        }
    }
}
