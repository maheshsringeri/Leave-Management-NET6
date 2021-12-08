using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_NET6.Data.Migrations
{
    public partial class AddedDefaultUsersUsersname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6dd538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "c4973b39-8703-4aaa-9bd5-2ff983cc82e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "vv694538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "8e749dd5-ef2a-4c57-a91a-e11b5948cae4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "24924fdd-8ff3-4963-a625-9793a45fce1c", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEA6kyLl56W0M44rq3+ubb8DuFIcOUmtGpFXatIYdNzsgve5z+fVd0Hxa+C47bI0l0A==", "1534877c-37cf-4961-bc79-43afcb5fb969", "admin@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "fa7805fe-f00c-4d7f-828b-b65c459e0912", true, "USER1@LOCALHOST.COM", "AQAAAAEAACcQAAAAEC5FM3kC7k3wXI2sOM+O4q6OY653myMFyKIsxSZw40sztiwsjT6yTjysprafdauy/A==", "8b6d0799-0671-428b-86ad-08cc1b31cc25", "user1@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6dd538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "c5329db0-dfa2-420e-8832-34217d86aeb6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "vv694538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "3918ee41-0c09-46c6-8372-d75d71b83bca");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "af9cc0ff-46b0-4d41-9c14-1702e3c90dc1", false, null, "AQAAAAEAACcQAAAAECqhuZlSgFR2zFvUVUpk7jBbATsrreHRo2jiUJpZVexU32sw9BXP4c5gB8tWeCFhcw==", "b708222f-607c-45e9-b166-08acc581226e", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "93bf6075-e649-4fcd-afd9-d35ecd30b1b7", false, null, "AQAAAAEAACcQAAAAEBybO0Orcpj68JycogkSLtFV34ioSQNOqu7u5i/OMfW3i/GzFGeapvaxZfv3EHmQGw==", "07aab191-45e2-41cb-b722-8198543eea1d", null });
        }
    }
}
