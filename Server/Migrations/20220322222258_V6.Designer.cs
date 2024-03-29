﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace MoM.Migrations
{
    [DbContext(typeof(MoMContext))]
    [Migration("20220322222258_V6")]
    partial class V6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Models.Odsek", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Ime");

                    b.Property<int>("sprat")
                        .HasColumnType("int")
                        .HasColumnName("Br. sprata");

                    b.HasKey("id");

                    b.ToTable("Odsek");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Odsekid")
                        .HasColumnType("int");

                    b.Property<int>("brLegitimacije")
                        .HasColumnType("int")
                        .HasColumnName("Br. legitimacije");

                    b.Property<int>("godRodj")
                        .HasColumnType("int")
                        .HasColumnName("Godina rođenja");

                    b.Property<string>("ime")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Ime");

                    b.Property<string>("pol")
                        .HasMaxLength(1)
                        .HasColumnType("nvarchar(1)")
                        .HasColumnName("Pol");

                    b.Property<string>("prezime")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Prezime");

                    b.HasKey("id");

                    b.HasIndex("Odsekid");

                    b.ToTable("Radnik");
                });

            modelBuilder.Entity("Models.Slucaj", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("Odsekid")
                        .HasColumnType("int");

                    b.Property<int?>("Radnikid")
                        .HasColumnType("int");

                    b.Property<string>("kodnoIme")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Kodno ime");

                    b.Property<string>("nivoPov")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nivo poverljivosti");

                    b.Property<string>("opis")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Kratak opis");

                    b.Property<int>("status")
                        .HasColumnType("int")
                        .HasColumnName("Status");

                    b.HasKey("id");

                    b.HasIndex("Odsekid");

                    b.HasIndex("Radnikid");

                    b.ToTable("Slučaj");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.HasOne("Models.Odsek", "Odsek")
                        .WithMany("Radnici")
                        .HasForeignKey("Odsekid");

                    b.Navigation("Odsek");
                });

            modelBuilder.Entity("Models.Slucaj", b =>
                {
                    b.HasOne("Models.Odsek", "Odsek")
                        .WithMany("Slucajevi")
                        .HasForeignKey("Odsekid");

                    b.HasOne("Models.Radnik", "Radnik")
                        .WithMany("Slucajevi")
                        .HasForeignKey("Radnikid");

                    b.Navigation("Odsek");

                    b.Navigation("Radnik");
                });

            modelBuilder.Entity("Models.Odsek", b =>
                {
                    b.Navigation("Radnici");

                    b.Navigation("Slucajevi");
                });

            modelBuilder.Entity("Models.Radnik", b =>
                {
                    b.Navigation("Slucajevi");
                });
#pragma warning restore 612, 618
        }
    }
}
