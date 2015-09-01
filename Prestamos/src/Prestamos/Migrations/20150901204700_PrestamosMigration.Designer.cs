using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using Prestamos.Models;

namespace PrestamosMigrations
{
    [ContextType(typeof(PrestamoContext))]
    partial class PrestamosMigration
    {
        public override string Id
        {
            get { return "20150901204700_PrestamosMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
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

                    b.Property<string>("SegundoApellido")
                        .Required();

                    b.Property<string>("SegundoNombre")
                        .Required();

                    b.Key("Id");
                });
        }
    }
}
