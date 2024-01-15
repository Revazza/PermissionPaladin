using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionPaladin.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4f6a5216-be70-4324-9c42-7ebac7e1d7ab");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0284b460-07b7-4805-a57e-04f5748791dd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "8608fb2c-9084-404e-9e32-5bad37b450eb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "5c148838-71c5-4afe-8baa-519a12468154", "User", "srevaza1236@gmail.com", false, false, null, "SREVAZA1236@GMAIL.COM", "SANDRO", "AOo6r/Aj92kHioMqHB9LRHm68TZGCZAzv8Si4N6QHUVKx3BTtwvf9oMnuWkPd1JqKA==", "1234567890", false, null, false, "sandro" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6fab3833-1f98-4db9-84cb-803ba2a99552");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "dc852375-3f4a-4058-b4c5-735b1461d994");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "adc7147c-1933-4efc-85cf-08a79a5c4fe9");
        }
    }
}
