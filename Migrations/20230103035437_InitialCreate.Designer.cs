﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuachHuyDuc748.Data;

#nullable disable

namespace QuachHuyDuc748.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230103035437_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("QuachHuyDuc748.Models.CompanyQHD748", b =>
                {
                    b.Property<string>("CompanyId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });
#pragma warning restore 612, 618
        }
    }
}