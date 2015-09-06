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
                        .Required()
                        .Annotation("MaxLength", 11);

                    b.Property<string>("PrimerApellido")
                        .Required();

                    b.Property<string>("PrimerNombre")
                        .Required();

                    b.Property<string>("SegundoApellido");

                    b.Property<string>("SegundoNombre");

                    b.Key("Id");

                    b.Index("Cedula")
                        .Unique();
                });

            builder.Entity("Negocios.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantCuotas");

                    b.Property<int?>("CodeudorId");

                    b.Property<int?>("DeudorId");

                    b.Property<DateTime>("FechaDesembolso");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<int>("FormaPago");

                    b.Property<int>("Moneda");

                    b.Property<decimal>("Monto");

                    b.Property<int>("PorcMora");

                    b.Property<int>("Porciento");

                    b.Key("Id");
                });

            builder.Entity("Negocios.Prestamo", b =>
                {
                    b.Reference("Negocios.Cliente")
                        .InverseCollection()
                        .ForeignKey("CodeudorId");

                    b.Reference("Negocios.Cliente")
                        .InverseCollection()
                        .ForeignKey("DeudorId");
                });
        }
    }
}
