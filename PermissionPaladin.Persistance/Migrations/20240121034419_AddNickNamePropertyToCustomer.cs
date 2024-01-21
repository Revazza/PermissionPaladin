using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionPaladin.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddNickNamePropertyToCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "59637d0d-5571-4ba3-83e4-f0e595819a7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "94a6d748-1efb-4cd0-9a6b-84a9cba90bfa");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "87de5db2-e072-4ef6-a9be-cf0cd2e67826");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bdb66dfb-f5c8-4a27-8e7b-c327610be691", "AFTFPJsEHY1JTFmHEzXRIaft6kT7cNODKRYxDw9hDCKMGv8arc3fbKjTwT/Uu0mJ2Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6368328d-0d09-4c3f-a4d7-553da69f3710");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a076b4f1-3564-4501-8472-1e6dc6ef5952");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "4ad9ffde-48d8-4fb1-9636-b2470efcff30");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4ae2c2e-2751-4536-af30-9b506cb5babe", "AEWAQSi6X81gHoVntJI3a6mQEuNvaqJFPa6EeNkCGq9eEsJ0e8hr+18+CA/B2/zcwA==" });
        }
    }
}
