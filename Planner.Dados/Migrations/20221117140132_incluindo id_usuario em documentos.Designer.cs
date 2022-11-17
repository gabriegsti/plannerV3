﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Planner.Dados;

#nullable disable

namespace Planner.Dados.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20221117140132_incluindo id_usuario em documentos")]
    partial class incluindoid_usuarioemdocumentos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Planner.Entidades.Anotacao", b =>
                {
                    b.Property<int>("Id_Anotacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Anotacao"));

                    b.Property<string>("Campo_Texto")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int?>("Id_Usuario")
                        .HasColumnType("integer");

                    b.Property<string>("Link")
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id_Anotacao");

                    b.ToTable("Anotacao");
                });

            modelBuilder.Entity("Planner.Entidades.Documentos", b =>
                {
                    b.Property<int>("Id_Documento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Documento"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Id_Usuario")
                        .HasColumnType("integer");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<byte[]>>("documento")
                        .HasColumnType("bytea[]");

                    b.HasKey("Id_Documento");

                    b.ToTable("Documentos");
                });

            modelBuilder.Entity("Planner.Entidades.Evento", b =>
                {
                    b.Property<int>("Id_Evento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Evento"));

                    b.Property<DateTime?>("Data_Hora")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("UsuarioId")
                        .HasColumnType("integer");

                    b.HasKey("Id_Evento");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("Planner.Entidades.Materia", b =>
                {
                    b.Property<int>("Id_Materia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Materia"));

                    b.Property<DateTime?>("Data_Fim")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("Data_Inicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int?>("Id_Usuario")
                        .HasColumnType("integer");

                    b.Property<string>("Professor")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id_Materia");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("Planner.Entidades.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Usuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id_Usuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Planner.Entidades.Evento", b =>
                {
                    b.HasOne("Planner.Entidades.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
