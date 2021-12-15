using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leave_Management_NET6.Data.Migrations
{
    public partial class AddedLeaveRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "leaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    DateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RequestComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    Cancelled = table.Column<bool>(type: "bit", nullable: false),
                    RequestingEmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leaveRequests_leaveTypes_LeaveTypeId",
                        column: x => x.LeaveTypeId,
                        principalTable: "leaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_leaveRequests_LeaveTypeId",
                table: "leaveRequests",
                column: "LeaveTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "leaveRequests");

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
    }
}
