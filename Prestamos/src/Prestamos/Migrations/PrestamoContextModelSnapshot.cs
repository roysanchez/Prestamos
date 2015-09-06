using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Prestamos.Models;

namespace PrestamosMigrations
{
    [ContextType(typeof(PrestamoContext))]
    partial class PrestamoContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815")
                .Annotation("SqlServer:ValueGenerationStrategy", "IdentityColumn");

            builder.Entity("Negocios.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cedula")
                        .Required();

                    b.Property<string>("PrimerApellido")
                        .Required();

                    b.Property<string>("PrimerNombre")
                        .Required();

                    b.Property<string>("SegundoApellido");

                    b.Property<string>("SegundoNombre");

                    b.Key("Id");
                });
        }
    }
}
