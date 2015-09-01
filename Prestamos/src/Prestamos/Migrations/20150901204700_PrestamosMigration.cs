using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace PrestamosMigrations
{
    public partial class PrestamosMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn"),
                    Cedula = table.Column(type: "nvarchar(max)", nullable: false),
                    PrimerApellido = table.Column(type: "nvarchar(max)", nullable: false),
                    PrimerNombre = table.Column(type: "nvarchar(max)", nullable: false),
                    SegundoApellido = table.Column(type: "nvarchar(max)", nullable: false),
                    SegundoNombre = table.Column(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Cliente");
        }
    }
}
