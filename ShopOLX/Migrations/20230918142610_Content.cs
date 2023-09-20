using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopOLX.Migrations
{
    /// <inheritdoc />
    public partial class Content : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsUsed", "Mail", "Phone" },
                values: new object[] { false, "some@mail.com", "+380000000000" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "IsUsed", "Mail", "Phone" },
                values: new object[] { "Kyiv", true, "some@mail.com", "+380000000000" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "City", "IsUsed", "Mail", "Phone" },
                values: new object[] { "Lviv", true, "some@mail.com", "+380000000000" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "City", "IsUsed", "Mail", "Phone" },
                values: new object[] { "Lutsk", false, "some@mail.com", "+380000000000" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "City", "IsUsed", "Mail", "Phone" },
                values: new object[] { "Odessa", false, "some@mail.com", "+380000000000" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "City", "IsUsed", "Mail", "Phone" },
                values: new object[] { "Zhutomur", true, "some@mail.com", "+380000000000" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "Rivne");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "City",
                value: "Rivne");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "City",
                value: "Rivne");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "City",
                value: "Rivne");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "City",
                value: "Rivne");
        }
    }
}
