﻿// <auto-generated />
using System;
using HormonaCrecimiento.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HormonaCrecimiento.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.HistoriaClinica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Diagnostico")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Historias");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.PatronCrecimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("int");

                    b.Property<int?>("TipoPatron")
                        .HasColumnType("int");

                    b.Property<float?>("Valor")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("PacienteId");

                    b.ToTable("PatronesCrecimiento");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Documento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Tratamiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaHoraTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaClinicaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaClinicaId");

                    b.ToTable("Tratamientos");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Familiar", b =>
                {
                    b.HasBaseType("HormonaCrecimiento.App.Dominio.Persona");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parentesco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Familiar_Telefono");

                    b.HasDiscriminator().HasValue("Familiar");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Medico", b =>
                {
                    b.HasBaseType("HormonaCrecimiento.App.Dominio.Persona");

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Especializacion")
                        .HasColumnType("int");

                    b.Property<string>("RegistroRetThus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Medico");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Paciente", b =>
                {
                    b.HasBaseType("HormonaCrecimiento.App.Dominio.Persona");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FamiliarId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<int?>("HistoriaClinicaId")
                        .HasColumnType("int");

                    b.Property<float?>("Latitud")
                        .HasColumnType("real");

                    b.Property<float?>("Longitud")
                        .HasColumnType("real");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("int");

                    b.HasIndex("FamiliarId");

                    b.HasIndex("HistoriaClinicaId");

                    b.HasIndex("MedicoId");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.PatronCrecimiento", b =>
                {
                    b.HasOne("HormonaCrecimiento.App.Dominio.Paciente", null)
                        .WithMany("PatronesCrecimiento")
                        .HasForeignKey("PacienteId");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Tratamiento", b =>
                {
                    b.HasOne("HormonaCrecimiento.App.Dominio.HistoriaClinica", null)
                        .WithMany("Tratamientos")
                        .HasForeignKey("HistoriaClinicaId");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Paciente", b =>
                {
                    b.HasOne("HormonaCrecimiento.App.Dominio.Familiar", "Familiar")
                        .WithMany()
                        .HasForeignKey("FamiliarId");

                    b.HasOne("HormonaCrecimiento.App.Dominio.HistoriaClinica", "HistoriaClinica")
                        .WithMany()
                        .HasForeignKey("HistoriaClinicaId");

                    b.HasOne("HormonaCrecimiento.App.Dominio.Medico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId");

                    b.Navigation("Familiar");

                    b.Navigation("HistoriaClinica");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.HistoriaClinica", b =>
                {
                    b.Navigation("Tratamientos");
                });

            modelBuilder.Entity("HormonaCrecimiento.App.Dominio.Paciente", b =>
                {
                    b.Navigation("PatronesCrecimiento");
                });
#pragma warning restore 612, 618
        }
    }
}
