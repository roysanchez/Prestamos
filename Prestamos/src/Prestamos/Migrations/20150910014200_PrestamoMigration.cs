using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace Prestamos.Migrations
{
    public partial class PrestamoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    Cedula = table.Column<string>(isNullable: false),
                    PrimerApellido = table.Column<string>(isNullable: false),
                    PrimerNombre = table.Column<string>(isNullable: false),
                    SegundoApellido = table.Column<string>(isNullable: true),
                    SegundoNombre = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn),
                    CantCuotas = table.Column<int>(isNullable: false),
                    CodeudorId = table.Column<int>(isNullable: true),
                    DeudorId = table.Column<int>(isNullable: false),
                    FechaDesembolso = table.Column<DateTime>(isNullable: false),
                    FechaFin = table.Column<DateTime>(isNullable: false),
                    FechaInicio = table.Column<DateTime>(isNullable: false),
                    FormaPago = table.Column<int>(isNullable: false),
                    Moneda = table.Column<int>(isNullable: false),
                    Monto = table.Column<decimal>(isNullable: false),
                    PorcMora = table.Column<int>(isNullable: false),
                    Porciento = table.Column<int>(isNullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamo_Cliente_CodeudorId",
                        column: x => x.CodeudorId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prestamo_Cliente_DeudorId",
                        column: x => x.DeudorId,
                        principalTable: "Cliente",
                        principalColumn: "Id");
                });
            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cedula",
                table: "Cliente",
                column: "Cedula",
                isUnique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Prestamo");
            migrationBuilder.DropTable("Cliente");
        }
    }
}
