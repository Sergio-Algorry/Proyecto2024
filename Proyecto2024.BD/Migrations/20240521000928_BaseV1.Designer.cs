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
    [Migration("20240521000928_BaseV1")]
    partial class BaseV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TituloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TituloId");

                    b.HasIndex(new[] { "Codigo" }, "Especialidad_UQ")
                        .IsUnique();

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("ProfesionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EspecialidadId");

                    b.HasIndex(new[] { "ProfesionId", "EspecialidadId" }, "Matricula_UQ")
                        .IsUnique();

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("NumDoc")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("TDocumentoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Apellido", "Nombre" }, "Persona_Apellido_Nombre");

                    b.HasIndex(new[] { "TDocumentoId", "NumDoc" }, "Persona_UQ")
                        .IsUnique();

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Profesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("TituloId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TituloId");

                    b.HasIndex(new[] { "PersonaId", "TituloId" }, "Profesion_UQ")
                        .IsUnique();

                    b.ToTable("Profesiones");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.TDocumento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Codigo" }, "TDocumento_UQ")
                        .IsUnique();

                    b.ToTable("TDocumentos");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Titulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Codigo" }, "Titulo_UQ")
                        .IsUnique();

                    b.ToTable("Titulos");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Especialidad", b =>
                {
                    b.HasOne("Proyecto2024.BD.Data.Entity.Titulo", "Titulo")
                        .WithMany("Especialidades")
                        .HasForeignKey("TituloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Titulo");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Matricula", b =>
                {
                    b.HasOne("Proyecto2024.BD.Data.Entity.Especialidad", "Especialidad")
                        .WithMany("Matriculas")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto2024.BD.Data.Entity.Profesion", "Profesion")
                        .WithMany()
                        .HasForeignKey("ProfesionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Profesion");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Persona", b =>
                {
                    b.HasOne("Proyecto2024.BD.Data.Entity.TDocumento", "TDocumento")
                        .WithMany("Personas")
                        .HasForeignKey("TDocumentoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TDocumento");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Profesion", b =>
                {
                    b.HasOne("Proyecto2024.BD.Data.Entity.Persona", "Persona")
                        .WithMany("Profesiones")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Proyecto2024.BD.Data.Entity.Titulo", "Titulo")
                        .WithMany("Profesiones")
                        .HasForeignKey("TituloId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Persona");

                    b.Navigation("Titulo");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Especialidad", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Persona", b =>
                {
                    b.Navigation("Profesiones");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.TDocumento", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Proyecto2024.BD.Data.Entity.Titulo", b =>
                {
                    b.Navigation("Especialidades");

                    b.Navigation("Profesiones");
                });
#pragma warning restore 612, 618
        }
    }
}
