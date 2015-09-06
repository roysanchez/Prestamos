using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace PrestamosMigrations
{
    public partial class PrestamoMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Cedula = table.Column(type: "nvarchar(11)", nullable: false),
                    PrimerApellido = table.Column(type: "nvarchar(max)", nullable: false),
                    PrimerNombre = table.Column(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
            migration.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    CantCuotas = table.Column(type: "int", nullable: false),
                    CodeudorId = table.Column(type: "int", nullable: true),
                    DeudorId = table.Column(type: "int", nullable: true),
                    FechaDesembolso = table.Column(type: "datetime2", nullable: false),
                    FechaFin = table.Column(type: "datetime2", nullable: false),
                    FechaInicio = table.Column(type: "datetime2", nullable: false),
                    FormaPago = table.Column(type: "int", nullable: false),
                    Moneda = table.Column(type: "int", nullable: false),
                    Monto = table.Column(type: "decimal(18, 2)", nullable: false),
                    PorcMora = table.Column(type: "int", nullable: false),
                    Porciento = table.Column(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestamo_Cliente_CodeudorId",
                        columns: x => x.CodeudorId,
                        referencedTable: "Cliente",
                        referencedColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prestamo_Cliente_DeudorId",
                        columns: x => x.DeudorId,
                        referencedTable: "Cliente",
                        referencedColumn: "Id");
                });
            migration.CreateIndex(
                name: "IX_Cliente_Cedula",
                table: "Cliente",
                column: "Cedula",
                unique: true);
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Prestamo");
            migration.DropTable("Cliente");
        }
    }
}
