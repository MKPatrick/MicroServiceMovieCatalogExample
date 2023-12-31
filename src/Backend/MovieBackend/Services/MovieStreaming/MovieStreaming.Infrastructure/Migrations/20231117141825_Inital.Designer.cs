﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieStreaming.Infrastructure.Data;

#nullable disable

namespace MovieStreaming.Infrastructure.Migrations
{
    [DbContext(typeof(MovieStreamingDatabaseContext))]
    [Migration("20231117141825_Inital")]
    partial class Inital
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("MovieStreaming.Domain.Entities.MovieStream", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MovieFile")
                        .HasColumnType("TEXT");

                    b.Property<int>("MovieID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("MovieStreams");
                });
#pragma warning restore 612, 618
        }
    }
}
