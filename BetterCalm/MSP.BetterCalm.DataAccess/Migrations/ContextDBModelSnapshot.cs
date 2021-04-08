﻿// <auto-generated />
using System;
using MSP.BetterCalm.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MSP.BetterCalm.DataAccess.Migrations
{
    [DbContext(typeof(ContextDB))]
    partial class ContextDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.CategoryDto", b =>
                {
                    b.Property<int>("CategoryDtoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlaylistDtoID")
                        .HasColumnType("int");

                    b.Property<int?>("SongDtoID")
                        .HasColumnType("int");

                    b.HasKey("CategoryDtoID");

                    b.HasIndex("PlaylistDtoID");

                    b.HasIndex("SongDtoID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.PlaylistDto", b =>
                {
                    b.Property<int>("PlaylistDtoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlaylistDtoID");

                    b.ToTable("Playlists");
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

                    b.Property<int?>("PlaylistDtoID")
                        .HasColumnType("int");

                    b.Property<string>("UrlAudio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SongDtoID");

                    b.HasIndex("PlaylistDtoID");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.CategoryDto", b =>
                {
                    b.HasOne("MSP.BetterCalm.DataAccess.PlaylistDto", "PlaylistDto")
                        .WithMany("Categories")
                        .HasForeignKey("PlaylistDtoID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("MSP.BetterCalm.DataAccess.SongDto", "SongDto")
                        .WithMany("Categories")
                        .HasForeignKey("SongDtoID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("PlaylistDto");

                    b.Navigation("SongDto");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.SongDto", b =>
                {
                    b.HasOne("MSP.BetterCalm.DataAccess.PlaylistDto", "PlaylistDto")
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistDtoID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("PlaylistDto");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.PlaylistDto", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Songs");
                });

            modelBuilder.Entity("MSP.BetterCalm.DataAccess.SongDto", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
