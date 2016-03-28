using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Prestamos.Models;

namespace Prestamos.Migrations.Prestamo
{
    [DbContext(typeof(PrestamoContext))]
    [Migration("20160328224015_PrestamoMigration")]
    partial class PrestamoMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("Negocios.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cedula")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 11);

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("PrimerApellido")
                        .IsRequired();

                    b.Property<string>("PrimerNombre")
                        .IsRequired();

                    b.Property<string>("SegundoApellido");

                    b.Property<string>("SegundoNombre");

                    b.HasKey("Id");

                    b.HasIndex("Cedula")
                        .IsUnique();
                });

            modelBuilder.Entity("Negocios.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CantCuotas");

                    b.Property<int?>("CodeudorId");

                    b.Property<int?>("DeudorId")
                        .IsRequired();

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
                        .HasForeignKey("CodeudorId");

                    b.HasOne("Negocios.Cliente")
                        .WithMany()
                        .HasForeignKey("DeudorId");
                });
        }
    }
}
