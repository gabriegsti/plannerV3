﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Planner.Dados;

#nullable disable

namespace Planner.Dados.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Planner.Entidades.Anotacao", b =>
                {
                    b.Property<int>("Id_Anotacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Anotacao"), 1L, 1);

                    b.Property<int>("AulaId")
                        .HasColumnType("int");

                    b.Property<string>("Campo_Texto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Anotacao");

                    b.HasIndex("AulaId");

                    b.ToTable("Anotacao");
                });

            modelBuilder.Entity("Planner.Entidades.Aula", b =>
                {
                    b.Property<int>("Id_Aula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Aula"), 1L, 1);

                    b.Property<DateTime>("Data_Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Materia")
                        .HasColumnType("int");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Aula");

                    b.ToTable("Aula");
                });

            modelBuilder.Entity("Planner.Entidades.Avaliacao", b =>
                {
                    b.Property<int>("Id_Avaliacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Avaliacao"), 1L, 1);

                    b.Property<DateTime?>("Data_Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Evento")
                        .HasColumnType("int");

                    b.Property<int>("Id_Materia")
                        .HasColumnType("int");

                    b.Property<double?>("Nota")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Avaliacao");

                    b.ToTable("Avaliacao");
                });

            modelBuilder.Entity("Planner.Entidades.Evento", b =>
                {
                    b.Property<int>("Id_Evento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Evento"), 1L, 1);

                    b.Property<DateTime?>("Data_Hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Evento");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Planner.Entidades.Materia", b =>
                {
                    b.Property<int>("Id_Materia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Materia"), 1L, 1);

                    b.Property<DateTime?>("Data_Fim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Data_Inicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("int");

                    b.Property<string>("Professor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Materia");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("Planner.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Usuario"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id_Usuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Planner.Entidades.Anotacao", b =>
                {
                    b.HasOne("Planner.Entidades.Aula", "Aula")
                        .WithMany("LstAnotacoes")
                        .HasForeignKey("AulaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aula");
                });

            modelBuilder.Entity("Planner.Entidades.Aula", b =>
                {
                    b.Navigation("LstAnotacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
