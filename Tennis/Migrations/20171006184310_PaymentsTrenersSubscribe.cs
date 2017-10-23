using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tennis.Migrations
{
    public partial class PaymentsTrenersSubscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscribeTreners_Players_PlayerId",
                table: "SubscribeTreners");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "SubscribeTreners",
                newName: "TrenerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubscribeTreners_PlayerId",
                table: "SubscribeTreners",
                newName: "IX_SubscribeTreners_TrenerId");

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false),
                    TrenerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payments_Treners_TrenerId",
                        column: x => x.TrenerId,
                        principalTable: "Treners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PlayerId",
                table: "Payments",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_TrenerId",
                table: "Payments",
                column: "TrenerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscribeTreners_Treners_TrenerId",
                table: "SubscribeTreners",
                column: "TrenerId",
                principalTable: "Treners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscribeTreners_Treners_TrenerId",
                table: "SubscribeTreners");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.RenameColumn(
                name: "TrenerId",
                table: "SubscribeTreners",
                newName: "PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_SubscribeTreners_TrenerId",
                table: "SubscribeTreners",
                newName: "IX_SubscribeTreners_PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscribeTreners_Players_PlayerId",
                table: "SubscribeTreners",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
