﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieRating.Infrastructure.Data;

#nullable disable

namespace MovieRating.Infrastructure.Migrations
{
    [DbContext(typeof(MovieRatingDatabaseContext))]
    [Migration("20231116122417_Inital")]
    partial class Inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MovieRating.Domain.Entities.MovieRate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int>("MovieRatedStar")
                        .HasColumnType("int");

                    b.Property<DateTime>("RatedTime")
                        .HasColumnType("datetime(6)");

                    b.HasKey("ID");

                    b.ToTable("MovieRates");
                });
#pragma warning restore 612, 618
        }
    }
}
