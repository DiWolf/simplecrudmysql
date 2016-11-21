using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using mysqltest.Infraestructura;

namespace mysqltest.Migrations
{
    [DbContext(typeof(MySqlContexto))]
    [Migration("20161121044949_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1");

            modelBuilder.Entity("mysqltest.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.ToTable("Personas");
                });
        }
    }
}
