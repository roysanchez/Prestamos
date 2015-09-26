using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Prestamos.Migrations
{
    public partial class PrestamoMigrationSegunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Cliente",
                isNullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "FechaNacimiento", table: "Cliente");
        }
    }
}
