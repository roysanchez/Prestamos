using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Prestamos.Models;
using Microsoft.Data.Entity.SqlServer.Metadata;

namespace Prestamos.Migrations
{
    [DbContext(typeof(PrestamoContext))]
    partial class PrestamoMigration
    {
        public override string Id
        {
            get { return "20150910043658_PrestamoMigration"; }
        }

        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540")
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerIdentityStrategy.IdentityColumn);

            modelBuilder.Entity("Negocios.Cliente", b =>
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

            modelBuilder.Entity("Negocios.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantCuotas");

                    b.Property<int?>("CodeudorId");

                    b.Property<int?>("DeudorId")
                        .Required();

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

            modelBuilder.Entity("Negocios.Prestamo", b =>
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
