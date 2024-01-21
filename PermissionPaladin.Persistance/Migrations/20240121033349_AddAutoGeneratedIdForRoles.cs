﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermissionPaladin.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoGeneratedIdForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "dc9abd13-2e7f-439d-bdb0-f0422ea4185c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "02e597ce-8fbe-47e1-8e9f-4706a84dee0d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "ad79d59d-f9f5-4061-9c52-d7a0202f0718");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "02dd4d22-ba31-45fc-9a5f-cf87f27534a8", "AINnCtnA5w/e6V6goy49e+XvOmrE/kCQ3hBRqUXnAB9yfN/7qW5qYcNELPkmWFn94w==" });
        }
    }
}