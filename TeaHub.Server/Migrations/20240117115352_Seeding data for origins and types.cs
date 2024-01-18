using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeaHub.Server.Migrations
{
    /// <inheritdoc />
    public partial class Seedingdatafororiginsandtypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("24778741-c9a9-4109-b3f0-c8fd0a331211"), "India" },
                    { new Guid("4640705a-c3a8-4322-a0ff-cdcb7f4d9168"), "Taiwan" },
                    { new Guid("5600c9b5-3a70-40e0-9e04-9b476b10071d"), "China" },
                    { new Guid("86457340-1456-44c1-a80a-2a9b0e0ad64e"), "Japan" },
                    { new Guid("cd29ae67-690a-48b4-b315-57f06d8759eb"), "Nepal" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0d8c977a-e5a6-42c6-808f-5b1d8fff61c2"), "Oolong" },
                    { new Guid("1fd3cbbb-0b22-42b1-bf17-3417d16c53c0"), "Black" },
                    { new Guid("3ec436ab-47a0-449a-9d19-1a9d8f34c3bd"), "White" },
                    { new Guid("d8402d0c-9578-4d54-a4e3-d1a915d8c59a"), "Yellow" },
                    { new Guid("ed5b839f-4a58-459c-ae3c-10f997b5174c"), "Green" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Origins",
                keyColumn: "Id",
                keyValue: new Guid("24778741-c9a9-4109-b3f0-c8fd0a331211"));

            migrationBuilder.DeleteData(
                table: "Origins",
                keyColumn: "Id",
                keyValue: new Guid("4640705a-c3a8-4322-a0ff-cdcb7f4d9168"));

            migrationBuilder.DeleteData(
                table: "Origins",
                keyColumn: "Id",
                keyValue: new Guid("5600c9b5-3a70-40e0-9e04-9b476b10071d"));

            migrationBuilder.DeleteData(
                table: "Origins",
                keyColumn: "Id",
                keyValue: new Guid("86457340-1456-44c1-a80a-2a9b0e0ad64e"));

            migrationBuilder.DeleteData(
                table: "Origins",
                keyColumn: "Id",
                keyValue: new Guid("cd29ae67-690a-48b4-b315-57f06d8759eb"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("0d8c977a-e5a6-42c6-808f-5b1d8fff61c2"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("1fd3cbbb-0b22-42b1-bf17-3417d16c53c0"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("3ec436ab-47a0-449a-9d19-1a9d8f34c3bd"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("d8402d0c-9578-4d54-a4e3-d1a915d8c59a"));

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: new Guid("ed5b839f-4a58-459c-ae3c-10f997b5174c"));
        }
    }
}
