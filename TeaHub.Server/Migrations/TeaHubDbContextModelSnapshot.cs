﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TeaHub.Server.Data;

#nullable disable

namespace TeaHub.Server.Migrations
{
    [DbContext(typeof(TeaHubDbContext))]
    partial class TeaHubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TeaHub.Server.Models.Domain.Origin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Origins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5600c9b5-3a70-40e0-9e04-9b476b10071d"),
                            Name = "China"
                        },
                        new
                        {
                            Id = new Guid("86457340-1456-44c1-a80a-2a9b0e0ad64e"),
                            Name = "Japan"
                        },
                        new
                        {
                            Id = new Guid("4640705a-c3a8-4322-a0ff-cdcb7f4d9168"),
                            Name = "Taiwan"
                        },
                        new
                        {
                            Id = new Guid("cd29ae67-690a-48b4-b315-57f06d8759eb"),
                            Name = "Nepal"
                        },
                        new
                        {
                            Id = new Guid("24778741-c9a9-4109-b3f0-c8fd0a331211"),
                            Name = "India"
                        });
                });

            modelBuilder.Entity("TeaHub.Server.Models.Domain.Tea", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("OriginId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PurchasedFrom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("OriginId");

                    b.HasIndex("TypeId");

                    b.ToTable("Teas");
                });

            modelBuilder.Entity("TeaHub.Server.Models.Domain.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3ec436ab-47a0-449a-9d19-1a9d8f34c3bd"),
                            Name = "White"
                        },
                        new
                        {
                            Id = new Guid("ed5b839f-4a58-459c-ae3c-10f997b5174c"),
                            Name = "Green"
                        },
                        new
                        {
                            Id = new Guid("0d8c977a-e5a6-42c6-808f-5b1d8fff61c2"),
                            Name = "Oolong"
                        },
                        new
                        {
                            Id = new Guid("d8402d0c-9578-4d54-a4e3-d1a915d8c59a"),
                            Name = "Yellow"
                        },
                        new
                        {
                            Id = new Guid("1fd3cbbb-0b22-42b1-bf17-3417d16c53c0"),
                            Name = "Black"
                        });
                });

            modelBuilder.Entity("TeaHub.Server.Models.Domain.Tea", b =>
                {
                    b.HasOne("TeaHub.Server.Models.Domain.Origin", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TeaHub.Server.Models.Domain.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Origin");

                    b.Navigation("Type");
                });
#pragma warning restore 612, 618
        }
    }
}