using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceProject.Data.Migrations
{
    public partial class ProductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prduct_Image1",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prduct_Image2",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prduct_Image3",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prduct_Image4",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prduct_Image5",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prduct_Image1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Prduct_Image2",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Prduct_Image3",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Prduct_Image4",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Prduct_Image5",
                table: "Products");
        }
    }
}
