using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Migrations
{
    /// <inheritdoc />
    public partial class AddProductGroupProductRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "products",
                newName: "ProductID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "productGroups",
                newName: "ProductGroupID");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupID",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductGroupID",
                table: "products",
                column: "ProductGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productGroups_ProductGroupID",
                table: "products",
                column: "ProductGroupID",
                principalTable: "productGroups",
                principalColumn: "ProductGroupID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productGroups_ProductGroupID",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_ProductGroupID",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ProductGroupID",
                table: "products");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "products",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ProductGroupID",
                table: "productGroups",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
