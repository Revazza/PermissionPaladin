using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionPaladin.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddUserMenuAccessPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "408cc78d-e6ee-40f7-a47f-8b4c4da421c9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b9fdcbc1-4dd6-4b40-a620-6c520249c7d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "58f54277-ffcc-4638-b471-91c19fdbce0e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3614cf11-37a1-42e4-9387-dce00aed30ea", "AIh2APkd0+bJG7MPSbGtzpyqMCnYPYf7ODf5Bnjk7QjdelFoXWLCbmC/xzCbvmzOfA==" });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "AccessUserMenu" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 6, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "b1abbcba-1c75-42f9-8a34-015949d7c492");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "233d63f2-4ddd-48f3-a78a-3328150de79e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "41cb3298-bdaa-4f56-9860-d6a8b3b31b32");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0103cd91-19d1-405d-80d9-08d639f34983", "AA4PnlN3XwrF/s9vvPup8d7l1s363rU1KQkKlfGnZkoHZsJuIU/vI5k2SGIGcFUfcg==" });
        }
    }
}
