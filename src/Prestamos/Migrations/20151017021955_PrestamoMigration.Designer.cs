using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Prestamos.Models;

namespace Prestamos.Migrations
{
    [DbContext(typeof(PrestamoContext))]
    [Migration("20151017021955_PrestamoMigration")]
    partial class PrestamoMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta8-15964");

            modelBuilder.Entity("Negocios.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .Annotation("MaxLength", 11);

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("PrimerApellido")
                        .IsRequired();

                    b.Property<string>("PrimerNombre")
                        .IsRequired();

                    b.Property<string>("SegundoApellido");

                    b.Property<string>("SegundoNombre");

                    b.HasKey("Id");

                    b.Index("Cedula")
                        .Unique();
                });

            modelBuilder.Entity("Negocios.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantCuotas");

                    b.Property<int>("ClienteId");

                    b.Property<int?>("CodeudorId");

                    b.Property<DateTime>("FechaDesembolso");

                    b.Property<DateTime>("FechaFin");

                    b.Property<DateTime>("FechaInicio");

                    b.Property<int>("FormaPago");

                    b.Property<int>("Moneda");

                    b.Property<decimal>("Monto");

                    b.Property<int>("PorcMora");

                    b.Property<int>("Porciento");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Negocios.Prestamo", b =>
                {
                    b.HasOne("Negocios.Cliente")
                        .WithMany()
                        .ForeignKey("ClienteId");

                    b.HasOne("Negocios.Cliente")
                        .WithMany()
                        .ForeignKey("CodeudorId");
                });
        }
    }
}
