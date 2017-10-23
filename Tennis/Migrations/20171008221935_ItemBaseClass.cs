using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tennis.Migrations
{
    public partial class ItemBaseClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Treners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TimeTables",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SubscribeTreners",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SubscribePlayers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Reservations",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Regions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Prices",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Players",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Payments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Courts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Treners");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TimeTables");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SubscribeTreners");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SubscribePlayers");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Prices");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Courts");
        }
    }
}
