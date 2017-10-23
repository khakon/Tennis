using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tennis.Migrations
{
    public partial class RenameSubscribe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescribePlayers");

            migrationBuilder.DropTable(
                name: "DescribeTreners");

            migrationBuilder.CreateTable(
                name: "SubscribePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscribePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscribePlayers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscribeTreners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribeTreners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscribeTreners_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscribeTreners_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscribePlayers_PlayerId",
                table: "SubscribePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribePlayers_ReservationId",
                table: "SubscribePlayers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribeTreners_PlayerId",
                table: "SubscribeTreners",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribeTreners_ReservationId",
                table: "SubscribeTreners",
                column: "ReservationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscribePlayers");

            migrationBuilder.DropTable(
                name: "SubscribeTreners");

            migrationBuilder.CreateTable(
                name: "DescribePlayers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescribePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescribePlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescribePlayers_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescribeTreners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(nullable: false),
                    ReservationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescribeTreners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescribeTreners_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DescribeTreners_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DescribePlayers_PlayerId",
                table: "DescribePlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_DescribePlayers_ReservationId",
                table: "DescribePlayers",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_DescribeTreners_PlayerId",
                table: "DescribeTreners",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_DescribeTreners_ReservationId",
                table: "DescribeTreners",
                column: "ReservationId");
        }
    }
}
