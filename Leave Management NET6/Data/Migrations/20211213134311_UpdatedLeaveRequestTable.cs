using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_NET6.Data.Migrations
{
    public partial class UpdatedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "leaveRequests",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6dd538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "bb6cecb3-d517-4de0-a39d-e265d33c0a80");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "vv694538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "93b0c515-b580-4779-b491-69de749f40d4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "101682db-c31b-43a9-ace5-06c8e90e9734", "AQAAAAEAACcQAAAAEOknYUqj16GuV797/Y5HeRxsG7GN5xwZNNujqQpMSB2bdFV8wcafCtPM57frYtKzVQ==", "94f3d800-9950-4985-a7ae-85ae652a5e7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8c76c76-21a2-41c1-9c52-d3f0c48442fc", "AQAAAAEAACcQAAAAENfdb2hw+qfyrvKD/6PQWi89S4urUp+B2gscvhfjDr1FCHF9HLPlx9eFCienTn7MoQ==", "02adb902-83e9-449b-b751-bb1ca143d94a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequestComments",
                table: "leaveRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b6dd538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "dc4dd77b-efbd-4ce9-a6e4-dc7bd46b2793");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "vv694538-33ff-7755-93c5-f8b7799d7a07",
                column: "ConcurrencyStamp",
                value: "031e849e-78ea-4c55-8ae6-d8bb76e9bd26");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1de2f6b4-cbf1-4f54-a867-f952d267c438", "AQAAAAEAACcQAAAAEKsCPuiru8bqdJUpFZ9ScaSat6AwdXsg0diEAUhs57GF8eemXQg9ondhJYM5SZ08NA==", "43d7b8af-730d-4465-83d8-44fef8eeb68d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44694538-33ff-4f55-93c5-f8bf732d7a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "903d53db-4646-4da6-b682-b5f8b8a8cf74", "AQAAAAEAACcQAAAAEF/CBgsbrEV3GHQcFv68bvcGzJbM0e3YIts7VspZjh86qEUQ/8vVatQ/Xilow28q2g==", "128461f0-da3b-48ef-ab6c-c44ab5f3e2e2" });
        }
    }
}
