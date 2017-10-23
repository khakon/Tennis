using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tennis.Migrations
{
    public partial class AdressCourt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Courts",
                newName: "Adress");

            migrationBuilder.AddColumn<long>(
                name: "TimeStamp",
                table: "SubscribeTreners",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TimeStamp",
                table: "SubscribePlayers",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "SubscribeTreners");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "SubscribePlayers");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Courts",
                newName: "Address");
        }
    }
}
