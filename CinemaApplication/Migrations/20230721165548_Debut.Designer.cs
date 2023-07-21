﻿// <auto-generated />
using System;
using CinemaApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CinemaApplication.Migrations
{
    [DbContext(typeof(CinemaAppDbcontext))]
    [Migration("20230721165548_Debut")]
    partial class Debut
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CinemaApplication.Models.CategorieDuFilm", b =>
                {
                    b.Property<int>("CategorieDuFilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategorieDuFilmId"), 1L, 1);

                    b.Property<string>("GenreDuFilm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieDuFilmId");

                    b.ToTable("CategorieDuFilms");
                });

            modelBuilder.Entity("CinemaApplication.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AnneeDeSortie")
                        .HasColumnType("datetime2");

                    b.Property<string>("CategorieDeFilm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategorieDuFilmId")
                        .HasColumnType("int");

                    b.Property<string>("PrixDAchatDuFilm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategorieDuFilmId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("CinemaApplication.Models.Film", b =>
                {
                    b.HasOne("CinemaApplication.Models.CategorieDuFilm", "CategorieDuFilm")
                        .WithMany()
                        .HasForeignKey("CategorieDuFilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategorieDuFilm");
                });
#pragma warning restore 612, 618
        }
    }
}
