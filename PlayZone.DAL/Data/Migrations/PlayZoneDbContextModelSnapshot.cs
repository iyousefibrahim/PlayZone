﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlayZone.DAL.Data.Contexts;

#nullable disable

namespace PlayZone.DAL.Data.Migrations
{
    [DbContext(typeof(PlayZoneDbContext))]
    partial class PlayZoneDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PlayZone.DAL.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6964b615-a3d6-4b60-a317-75c84e5c10b6"),
                            Name = "Action"
                        },
                        new
                        {
                            Id = new Guid("f676e0fb-aec3-409b-846b-fa5f0bf5b3c0"),
                            Name = "Adventure"
                        },
                        new
                        {
                            Id = new Guid("d54f03bb-4c38-4e9d-b5a8-aa419a69d15c"),
                            Name = "Puzzle"
                        },
                        new
                        {
                            Id = new Guid("e6a466ff-7f2f-4d6d-ba09-451d295dd130"),
                            Name = "RPG"
                        },
                        new
                        {
                            Id = new Guid("b513a8fc-2200-4538-91c3-4986c6b0aba1"),
                            Name = "Simulation"
                        },
                        new
                        {
                            Id = new Guid("b9bfb3a1-f5c3-4029-bc0e-230043d41aa1"),
                            Name = "Strategy"
                        },
                        new
                        {
                            Id = new Guid("46e66292-65d9-4b3f-a429-42fe2de55371"),
                            Name = "Sports"
                        },
                        new
                        {
                            Id = new Guid("91a7cad7-e569-4566-9cea-380dbb8959cb"),
                            Name = "Racing"
                        },
                        new
                        {
                            Id = new Guid("6671ce52-49cf-416f-8ff4-5364f9092115"),
                            Name = "Horror"
                        });
                });

            modelBuilder.Entity("PlayZone.DAL.Models.Device", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Devices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9047443a-dd73-4872-b40c-26d3624af5eb"),
                            Icon = "bi bi-pc-display",
                            Name = "PC"
                        },
                        new
                        {
                            Id = new Guid("b03b81c5-3c75-494b-9154-1e227a5627e0"),
                            Icon = "bi bi-xbox",
                            Name = "Xbox"
                        },
                        new
                        {
                            Id = new Guid("c338cb39-0e7c-42d1-bc1b-128e7263988c"),
                            Icon = "bi bi-playstation",
                            Name = "PlayStation"
                        },
                        new
                        {
                            Id = new Guid("2edcb1b3-f15f-4b75-91dd-226c395e9b14"),
                            Icon = "bi bi-nintendo-switch",
                            Name = "Nintendo Switch"
                        });
                });

            modelBuilder.Entity("PlayZone.DAL.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("PlayZone.DAL.Models.GameDevice", b =>
                {
                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DeviceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GameId", "DeviceId");

                    b.HasIndex("DeviceId");

                    b.ToTable("GameDevices", (string)null);
                });

            modelBuilder.Entity("PlayZone.DAL.Models.Game", b =>
                {
                    b.HasOne("PlayZone.DAL.Models.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PlayZone.DAL.Models.GameDevice", b =>
                {
                    b.HasOne("PlayZone.DAL.Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PlayZone.DAL.Models.Game", "Game")
                        .WithMany("Device")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("PlayZone.DAL.Models.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("PlayZone.DAL.Models.Game", b =>
                {
                    b.Navigation("Device");
                });
#pragma warning restore 612, 618
        }
    }
}
