using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Kolokwium_30_06_2024_w66049.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "KolokwiumAPIDb");

            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DruzynyPilkarskie",
                schema: "KolokwiumAPIDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Aktywny = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DruzynyPilkarskie", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mecze",
                schema: "KolokwiumAPIDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NazwaRozgrywki = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Druzyna1Id = table.Column<int>(type: "int", nullable: false),
                    DruzynaPilkarska1Id = table.Column<int>(type: "int", nullable: false),
                    Druzyna2Id = table.Column<int>(type: "int", nullable: false),
                    DruzynaPilkarska2Id = table.Column<int>(type: "int", nullable: false),
                    DataMeczu = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GodzinaMeczuOd = table.Column<TimeOnly>(type: "time", nullable: false),
                    GodzinaMeczuDo = table.Column<TimeOnly>(type: "time", nullable: false),
                    AnulowanyMecz = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mecze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mecze_DruzynyPilkarskie_DruzynaPilkarska1Id",
                        column: x => x.DruzynaPilkarska1Id,
                        principalSchema: "KolokwiumAPIDb",
                        principalTable: "DruzynyPilkarskie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mecze_DruzynyPilkarskie_DruzynaPilkarska2Id",
                        column: x => x.DruzynaPilkarska2Id,
                        principalSchema: "KolokwiumAPIDb",
                        principalTable: "DruzynyPilkarskie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Mecze_DruzynaPilkarska1Id",
                schema: "KolokwiumAPIDb",
                table: "Mecze",
                column: "DruzynaPilkarska1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Mecze_DruzynaPilkarska2Id",
                schema: "KolokwiumAPIDb",
                table: "Mecze",
                column: "DruzynaPilkarska2Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mecze",
                schema: "KolokwiumAPIDb");

            migrationBuilder.DropTable(
                name: "DruzynyPilkarskie",
                schema: "KolokwiumAPIDb");
        }
    }
}
