using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Prestamos.Migrations.Prestamo
{
    public partial class PrestamoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cedula = table.Column<string>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    PrimerApellido = table.Column<string>(nullable: false),
                    PrimerNombre = table.Column<string>(nullable: false),
                    SegundoApellido = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CantCuotas = table.Column<int>(nullable: false),
                    CodeudorId = table.Column<int>(nullable: true),
                    DeudorId = table.Column<int>(nullable: false),
                    FechaDesembolso = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FormaPago = table.Column<int>(nullable: false),
                    Moneda = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    PorcMora = table.Column<int>(nullable: false),
                    Porciento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamo_Cliente_CodeudorId",
                        column: x => x.CodeudorId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prestamo_Cliente_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cedula",
                table: "Cliente",
                column: "Cedula",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Prestamo");
            migrationBuilder.DropTable("Cliente");
        }
    }
}
