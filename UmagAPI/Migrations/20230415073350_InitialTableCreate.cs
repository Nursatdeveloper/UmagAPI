using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UmagAPI.Migrations
{
    public partial class InitialTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "application");

            migrationBuilder.CreateTable(
                name: "tbsales",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Barcode = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    SaleTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbsales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbsupplies",
                schema: "application",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Barcode = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    SupplyTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbsupplies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbsales_Barcode_SaleTime",
                schema: "application",
                table: "tbsales",
                columns: new[] { "Barcode", "SaleTime" });

            migrationBuilder.CreateIndex(
                name: "IX_tbsupplies_Barcode_SupplyTime",
                schema: "application",
                table: "tbsupplies",
                columns: new[] { "Barcode", "SupplyTime" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbsales",
                schema: "application");

            migrationBuilder.DropTable(
                name: "tbsupplies",
                schema: "application");
        }
    }
}
