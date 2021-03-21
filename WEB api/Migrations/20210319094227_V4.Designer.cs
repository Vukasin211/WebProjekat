﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEB_api.Models;

namespace WEB_api.Migrations
{
    [DbContext(typeof(EvidencijaContext))]
    [Migration("20210319094227_V4")]
    partial class V4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WEB_api.Models.Evidencija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImeDrzave")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ImeDrzave");

                    b.HasKey("ID");

                    b.ToTable("Evidencija");
                });

            modelBuilder.Entity("WEB_api.Models.Kategorija", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Kategorije")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Kategorije");

                    b.Property<int?>("vozacID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("vozacID");

                    b.ToTable("Kategorije");
                });

            modelBuilder.Entity("WEB_api.Models.Vozacka", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojDozvole")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("BrojDozvole");

                    b.Property<string>("Grad")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("Grad");

                    b.Property<string>("ImeVozaca")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("ImeVozaca");

                    b.Property<string>("JMBG")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("JMBG");

                    b.Property<string>("PrezimeVozaca")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("PrezimeVozaca");

                    b.Property<int?>("evidencijaID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("evidencijaID");

                    b.ToTable("Vozacka");
                });

            modelBuilder.Entity("WEB_api.Models.Kategorija", b =>
                {
                    b.HasOne("WEB_api.Models.Vozacka", "vozac")
                        .WithMany("Kategorije")
                        .HasForeignKey("vozacID");

                    b.Navigation("vozac");
                });

            modelBuilder.Entity("WEB_api.Models.Vozacka", b =>
                {
                    b.HasOne("WEB_api.Models.Evidencija", "evidencija")
                        .WithMany("ListaVozackih")
                        .HasForeignKey("evidencijaID");

                    b.Navigation("evidencija");
                });

            modelBuilder.Entity("WEB_api.Models.Evidencija", b =>
                {
                    b.Navigation("ListaVozackih");
                });

            modelBuilder.Entity("WEB_api.Models.Vozacka", b =>
                {
                    b.Navigation("Kategorije");
                });
#pragma warning restore 612, 618
        }
    }
}
