﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFGetStarted.AspNetCore.ExistingDb.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Haandvaerker",
                columns: table => new
                {
                    HaandvaerkerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ansaettelsedato = table.Column<DateTime>(type: "date", nullable: false),
                    Efternavn = table.Column<string>(maxLength: 50, nullable: false),
                    Fagomraade = table.Column<string>(maxLength: 50, nullable: true),
                    Fornavn = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Haandvaerker", x => x.HaandvaerkerId);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoejskasse",
                columns: table => new
                {
                    VKasseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anskaffet = table.Column<DateTime>(type: "date", nullable: false),
                    Fabrikat = table.Column<string>(maxLength: 50, nullable: true),
                    EjesAf = table.Column<int>(nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Serienummer = table.Column<string>(maxLength: 50, nullable: true),
                    Farve = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoejskasse", x => x.VKasseId);
                    table.ForeignKey(
                        name: "FK_Vaerktoejskasse_ToHaandvaerker",
                        column: x => x.EjesAf,
                        principalTable: "Haandvaerker",
                        principalColumn: "HaandvaerkerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vaerktoej",
                columns: table => new
                {
                    VaerktoejsId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Anskaffet = table.Column<DateTime>(type: "date", nullable: false),
                    Fabrikat = table.Column<string>(nullable: true),
                    Model = table.Column<string>(maxLength: 50, nullable: true),
                    Serienr = table.Column<string>(maxLength: 50, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    LiggerIVTK = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaerktoej", x => x.VaerktoejsId);
                    table.ForeignKey(
                        name: "FK_Vaerktoej_Vaerktsejskasse",
                        column: x => x.LiggerIVTK,
                        principalTable: "Vaerktoejskasse",
                        principalColumn: "VKasseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoej_LiggerIVTK",
                table: "Vaerktoej",
                column: "LiggerIVTK");

            migrationBuilder.CreateIndex(
                name: "IX_Vaerktoejskasse_EjesAf",
                table: "Vaerktoejskasse",
                column: "EjesAf");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vaerktoej");

            migrationBuilder.DropTable(
                name: "Vaerktoejskasse");

            migrationBuilder.DropTable(
                name: "Haandvaerker");
        }
    }
}
