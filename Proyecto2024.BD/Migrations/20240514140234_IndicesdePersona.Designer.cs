﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proyecto2024.BD.Data;

#nullable disable

namespace Proyecto2024.BD.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240514140234_IndicesdePersona")]
    partial class IndicesdePersona
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NumDoc")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Apellido", "Nombre" }, "Persona_Apellido_Nombre");

                    b.HasIndex(new[] { "TDocumentoId", "NumDoc" }, "Persona_UQ")
                        .IsUnique();

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.TDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TDocumentos");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Persona", b =>
                {
                    b.HasOne("Proyecto2024.BD.Data.Entity.TDocumento", "TDocumento")
                        .WithMany()
                        .HasForeignKey("TDocumentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TDocumento");
                });
#pragma warning restore 612, 618
        }
    }
}
