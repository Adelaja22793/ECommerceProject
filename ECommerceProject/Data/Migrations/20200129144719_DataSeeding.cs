using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceProject.Data.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e1e36958-8ee5-4220-8210-f12ca32a65bb", "8c2a10ec-79f6-4fbc-9974-dd64b1bbd148", "Custermer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc94f19e-3fa8-41fc-8474-55af86df078b", "bcee0059-6fc3-4316-b9fd-f35eb4a2f9ce", "staff", "STAFF" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc94f19e-3fa8-41fc-8474-55af86df078b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e1e36958-8ee5-4220-8210-f12ca32a65bb");
        }
    }
}
