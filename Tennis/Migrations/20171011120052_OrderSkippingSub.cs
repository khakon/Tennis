using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tennis.Migrations
{
    public partial class OrderSkippingSub : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Order",
                table: "SubscribePlayers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Skipping",
                table: "SubscribePlayers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "SubscribePlayers");

            migrationBuilder.DropColumn(
                name: "Skipping",
                table: "SubscribePlayers");
        }
    }
}
