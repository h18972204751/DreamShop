﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Product.API.Data;

namespace Product.API.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20201211022303_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Product.API.Model.ProductProperties", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PropertiesGuid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductsId");

                    b.ToTable("ProductProperties");
                });

            modelBuilder.Entity("Product.API.Model.ProductType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("Product.API.Model.Products", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AddTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Core")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreateUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descript")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("IsCheck")
                        .HasColumnType("smallint");

                    b.Property<bool>("IsNew")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTop")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("NowPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Online")
                        .HasColumnType("bit");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Pic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PublishStatus")
                        .HasColumnType("int");

                    b.Property<string>("SellLimit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SellNum")
                        .HasColumnType("int");

                    b.Property<DateTime>("SellTime")
                        .HasColumnType("datetime2");

                    b.Property<short>("SetNewDays")
                        .HasColumnType("smallint");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<DateTime>("TopTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdateUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ProductTypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Product.API.Model.ProductProperties", b =>
                {
                    b.HasOne("Product.API.Model.Products", "Products")
                        .WithMany("ProductProperties")
                        .HasForeignKey("ProductsId");
                });

            modelBuilder.Entity("Product.API.Model.Products", b =>
                {
                    b.HasOne("Product.API.Model.ProductType", "ProductType")
                        .WithMany("Product")
                        .HasForeignKey("ProductTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}