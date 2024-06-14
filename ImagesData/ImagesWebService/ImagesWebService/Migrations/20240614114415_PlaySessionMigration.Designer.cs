﻿// <auto-generated />
using System;
using ImagesWebService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ImagesWebService.Migrations
{
    [DbContext(typeof(MemoryGameContext))]
    [Migration("20240614114415_PlaySessionMigration")]
    partial class PlaySessionMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ImagesWebService.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<byte[]>("Image1")
                        .IsRequired()
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Image");

                    b.Property<bool?>("IsBack")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("ImagesWebService.Models.PlaySessionNames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlaySessionNames");
                });
#pragma warning restore 612, 618
        }
    }
}