using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_NET6.Data.Migrations
{
    public partial class AddingPreiodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "leaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6dd538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "780a0269-7486-4f80-b3b4-23180bdb067a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "vv694538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "6b47f45a-3651-4f9f-93db-c1d0eb93925a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3df3467-0144-4da4-b70f-d9394744e01a", "AQAAAAEAACcQAAAAENjS+jF8HSq4PFhrhUMUZJqPM6sloEhpW4LaVPgIzxxrts77ZKb0YbMH7kasM+iQUA==", "c839b082-4d0c-4faf-bc25-a96c48cb07e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1976086d-2016-4f2a-ade2-24fc89d93f37", "AQAAAAEAACcQAAAAENg0nHHWogAVV/nv5XtTqK3Kz/Y3ZW55sj0gCIvmtxHrLMVDMZQL0jQJe/0iJe9oKQ==", "ad9fb300-8360-4bca-ad4e-c21639ecef3e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "leaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24924fdd-8ff3-4963-a625-9793a45fce1c", "AQAAAAEAACcQAAAAEA6kyLl56W0M44rq3+ubb8DuFIcOUmtGpFXatIYdNzsgve5z+fVd0Hxa+C47bI0l0A==", "1534877c-37cf-4961-bc79-43afcb5fb969" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa7805fe-f00c-4d7f-828b-b65c459e0912", "AQAAAAEAACcQAAAAEC5FM3kC7k3wXI2sOM+O4q6OY653myMFyKIsxSZw40sztiwsjT6yTjysprafdauy/A==", "8b6d0799-0671-428b-86ad-08cc1b31cc25" });
        }
    }
}
