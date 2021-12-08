using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_NET6.Data.Migrations
{
    public partial class AddedDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b6dd538-33ff-7755-93c5-f8b7799d7a07", "c5329db0-dfa2-420e-8832-34217d86aeb6", "User", "USER" },
                    { "vv694538-33ff-7755-93c5-f8b7799d7a07", "3918ee41-0c09-46c6-8372-d75d71b83bca", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3b694538-33ff-4f55-93c5-f8bf732d7a07", 0, "af9cc0ff-46b0-4d41-9c14-1702e3c90dc1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAECqhuZlSgFR2zFvUVUpk7jBbATsrreHRo2jiUJpZVexU32sw9BXP4c5gB8tWeCFhcw==", null, false, "b708222f-607c-45e9-b166-08acc581226e", null, false, null },
                    { "44694538-33ff-4f55-93c5-f8bf732d7a07", 0, "93bf6075-e649-4fcd-afd9-d35ecd30b1b7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user1@localhost.com", false, "System", "User1", false, null, "USER1@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEBybO0Orcpj68JycogkSLtFV34ioSQNOqu7u5i/OMfW3i/GzFGeapvaxZfv3EHmQGw==", null, false, "07aab191-45e2-41cb-b722-8198543eea1d", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "vv694538-33ff-7755-93c5-f8b7799d7a07", "3b694538-33ff-4f55-93c5-f8bf732d7a07" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3b6dd538-33ff-7755-93c5-f8b7799d7a07", "44694538-33ff-4f55-93c5-f8bf732d7a07" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "vv694538-33ff-7755-93c5-f8b7799d7a07", "3b694538-33ff-4f55-93c5-f8bf732d7a07" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3b6dd538-33ff-7755-93c5-f8b7799d7a07", "44694538-33ff-4f55-93c5-f8bf732d7a07" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6dd538-33ff-7755-93c5-f8b7799d7a07");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "vv694538-33ff-7755-93c5-f8b7799d7a07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b694538-33ff-4f55-93c5-f8bf732d7a07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44694538-33ff-4f55-93c5-f8bf732d7a07");
        }
    }
}
