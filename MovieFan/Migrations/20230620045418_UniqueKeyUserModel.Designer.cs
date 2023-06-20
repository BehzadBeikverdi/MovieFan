﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieFan.Data;

namespace MovieFan.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230620045418_UniqueKeyUserModel")]
    partial class UniqueKeyUserModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("MovieFan.Data.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("MovieFan.Data.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("MovieActors")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieDirector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MovieDuration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MovieIMDB")
                        .HasColumnType("float");

                    b.Property<string>("MovieName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MovieActors = "Behzad",
                            MovieDescription = "Flutter",
                            MovieDirector = "Google",
                            MovieDuration = "99 min",
                            MovieIMDB = 9.9000000000000004,
                            MovieName = "Computer Engeenering 1",
                            ReleaseDate = new DateTime(2009, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            MovieActors = "Behzad",
                            MovieDescription = "DotNet",
                            MovieDirector = "Microsoft",
                            MovieDuration = "99 min",
                            MovieIMDB = 9.5999999999999996,
                            MovieName = "Computer Engeenering 2",
                            ReleaseDate = new DateTime(2006, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            MovieActors = "Behzad",
                            MovieDescription = "Python",
                            MovieDirector = "Python Software Foundation",
                            MovieDuration = "99 min",
                            MovieIMDB = 9.3000000000000007,
                            MovieName = "Computer Engeenering 3",
                            ReleaseDate = new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MovieFan.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmailAddress")
                        .IsUnique()
                        .HasFilter("[EmailAddress] IS NOT NULL");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
