﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeededTeams : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamId", "CreatedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 24, 20, 34, 52, 233, DateTimeKind.Local).AddTicks(9446), "Tivoli Gardens FC" },
                    { 2, new DateTime(2024, 7, 24, 20, 34, 52, 233, DateTimeKind.Local).AddTicks(9456), "Waterhouse FC" },
                    { 3, new DateTime(2024, 7, 24, 20, 34, 52, 233, DateTimeKind.Local).AddTicks(9457), "Humble Lions FC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "TeamId",
                keyValue: 3);
        }
    }
}
