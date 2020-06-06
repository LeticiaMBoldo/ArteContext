﻿// <auto-generated />
using System;
using Artes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Artes.Migrations
{
    [DbContext(typeof(ArtesContext))]
    [Migration("20200526210433_criacao-banco")]
    partial class criacaobanco
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Artes.Models.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<int>("CidadeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
                        .HasMaxLength(100);

                    b.Property<string>("Endereco")
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Fone")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(60) CHARACTER SET utf8mb4")
                        .HasMaxLength(60);

                    b.Property<string>("Rg")
                        .HasColumnType("varchar(20) CHARACTER SET utf8mb4")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("CidadeId");

                    b.ToTable("Artista");
                });

            modelBuilder.Entity("Artes.Models.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2) CHARACTER SET utf8mb4")
                        .HasMaxLength(2);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Cidade");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Estado = "SP",
                            Nome = "Barra Bonita"
                        },
                        new
                        {
                            Id = 2,
                            Estado = "SP",
                            Nome = "Igaraçu do Tietê"
                        },
                        new
                        {
                            Id = 3,
                            Estado = "SP",
                            Nome = "Bauru"
                        },
                        new
                        {
                            Id = 4,
                            Estado = "SP",
                            Nome = "Macatuba"
                        },
                        new
                        {
                            Id = 5,
                            Estado = "SP",
                            Nome = "Pederneiras"
                        },
                        new
                        {
                            Id = 6,
                            Estado = "SP",
                            Nome = "Lençois Paulista"
                        });
                });

            modelBuilder.Entity("Artes.Models.Obra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ArtistaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataInscricao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FotoArte")
                        .IsRequired()
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<string>("InspiradaEm")
                        .IsRequired()
                        .HasColumnType("varchar(2000) CHARACTER SET utf8mb4")
                        .HasMaxLength(2000);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000) CHARACTER SET utf8mb4")
                        .HasMaxLength(1000);

                    b.Property<string>("Representa")
                        .IsRequired()
                        .HasColumnType("varchar(2000) CHARACTER SET utf8mb4")
                        .HasMaxLength(2000);

                    b.Property<int>("TipoObraId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistaId");

                    b.HasIndex("TipoObraId");

                    b.ToTable("Obra");
                });

            modelBuilder.Entity("Artes.Models.TipoObra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("TipoObra");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Fotografia"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Artes Plásticas"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Escultura"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Pintura"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Modelagem 3D"
                        });
                });

            modelBuilder.Entity("Artes.Models.Artista", b =>
                {
                    b.HasOne("Artes.Models.Cidade", "Cidade")
                        .WithMany()
                        .HasForeignKey("CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Artes.Models.Obra", b =>
                {
                    b.HasOne("Artes.Models.Artista", "Artista")
                        .WithMany()
                        .HasForeignKey("ArtistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Artes.Models.TipoObra", "TipoObra")
                        .WithMany()
                        .HasForeignKey("TipoObraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}