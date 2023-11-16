﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCatalog.Infrastructure.Data;

#nullable disable

namespace MovieCatalog.Infrastructure.Migrations
{
    [DbContext(typeof(MovieDatabaseContext))]
    [Migration("20231116114644_Update")]
    partial class Update
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("MovieCatalog.Domain.Entities.Movie.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("MovieCatalog.Domain.Entities.Movie.Movie", b =>
                {
                    b.OwnsOne("MovieCatalog.Domain.Entities.Movie.DateRelease", "ReleaseDate", b1 =>
                        {
                            b1.Property<int>("MovieID")
                                .HasColumnType("INTEGER");

                            b1.Property<byte>("Day")
                                .HasColumnType("INTEGER");

                            b1.Property<byte>("Month")
                                .HasColumnType("INTEGER");

                            b1.Property<uint>("Year")
                                .HasColumnType("INTEGER");

                            b1.HasKey("MovieID");

                            b1.ToTable("Movies");

                            b1.WithOwner()
                                .HasForeignKey("MovieID");
                        });

                    b.Navigation("ReleaseDate");
                });
#pragma warning restore 612, 618
        }
    }
}
