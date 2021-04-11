﻿// <auto-generated />
using System;
using MSP.BetterCalm.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    [DbContext(typeof(ContextDB))]
    [Migration("20210409001454_AdministratorModel")]
    partial class AdministratorModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.AdministratorDto", b =>
                {
                    b.Property<int>("AdministratorDtoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserDtoId")
                        .HasColumnType("int");

                    b.HasKey("AdministratorDtoId");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.CategoryDto", b =>
                {
                    b.Property<int>("CategoryDtoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SongDtoID")
                        .HasColumnType("int");

                    b.HasKey("CategoryDtoID");

                    b.HasIndex("SongDtoID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.PatientDto", b =>
                {
                    b.Property<int>("PatientDtoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cellphone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserDtoId")
                        .HasColumnType("int");

                    b.HasKey("PatientDtoId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.ProblematicDto", b =>
                {
                    b.Property<int>("ProblematicDtoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProblematicDtoID");

                    b.ToTable("Problematics");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.PsychologistDto", b =>
                {
                    b.Property<int>("PsychologistDtoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserDtoId")
                        .HasColumnType("int");

                    b.HasKey("PsychologistDtoId");

                    b.ToTable("Psychologists");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.SongDto", b =>
                {
                    b.Property<int>("SongDtoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlAudio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongDtoID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.CategoryDto", b =>
                {
                    b.HasOne("MSP.BetterCalm.DataAccess.SongDto", null)
                        .WithMany("Categories")
                        .HasForeignKey("SongDtoID");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.SongDto", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}