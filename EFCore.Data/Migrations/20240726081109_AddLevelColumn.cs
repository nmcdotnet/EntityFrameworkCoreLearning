using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLevelColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Teams",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Level" },
                values: new object[] { new DateTime(2024, 7, 26, 15, 11, 9, 67, DateTimeKind.Local).AddTicks(517), "City" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Level" },
                values: new object[] { new DateTime(2024, 7, 26, 15, 11, 9, 67, DateTimeKind.Local).AddTicks(528), "City" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Level" },
                values: new object[] { new DateTime(2024, 7, 26, 15, 11, 9, 67, DateTimeKind.Local).AddTicks(529), "Nation" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Teams");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 24, 20, 34, 52, 233, DateTimeKind.Local).AddTicks(9446));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 24, 20, 34, 52, 233, DateTimeKind.Local).AddTicks(9456));

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 7, 24, 20, 34, 52, 233, DateTimeKind.Local).AddTicks(9457));
        }
    }
}
