﻿// <auto-generated />
using System;
using BikeShop.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BikeShop.Entities.Migrations
{
    [DbContext(typeof(BikeShopContext))]
    [Migration("20220224063245_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BikeShop.Entities.Models.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"), 1L, 1);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BrandID");

                    b.ToTable("Brand");

                    b.HasData(
                        new
                        {
                            BrandID = 1,
                            BrandName = "Max"
                        },
                        new
                        {
                            BrandID = 2,
                            BrandName = "RMB"
                        },
                        new
                        {
                            BrandID = 3,
                            BrandName = "Max"
                        },
                        new
                        {
                            BrandID = 4,
                            BrandName = "Big Max"
                        });
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Children Bike"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Road Bike"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Mountain Bike"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Electric Bike"
                        });
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            City = "Centurion",
                            ContactNumber = "012365478",
                            Country = "SA",
                            Email = "roseyboxa@gmail.com",
                            FirstName = "Rosey",
                            LastName = "Boxa",
                            PostalCode = "125",
                            Province = "Gauteng",
                            Street = "12 Cool str"
                        },
                        new
                        {
                            CustomerId = 2,
                            City = "Bloemfontein",
                            ContactNumber = "05123654",
                            Country = "SA",
                            Email = "oozyCheal@gmail.com",
                            FirstName = "Oozy",
                            LastName = "Cheal",
                            PostalCode = "125",
                            Province = "Free State",
                            Street = "11A Kerol str"
                        },
                        new
                        {
                            CustomerId = 3,
                            City = "Centurion",
                            ContactNumber = "012365478",
                            Country = "SA",
                            Email = "luluMini@gmail.com",
                            FirstName = "Lulu",
                            LastName = "Mini",
                            PostalCode = "1235",
                            Province = "Gauteng",
                            Street = "785 Mapel str"
                        },
                        new
                        {
                            CustomerId = 4,
                            City = "Minlerton",
                            ContactNumber = "012365478",
                            Country = "SA",
                            Email = "roxyFerero@gmail.com",
                            FirstName = "Roxy",
                            LastName = "Ferero",
                            PostalCode = "001",
                            Province = "Western Cape",
                            Street = "85 Ocean Breeze str"
                        });
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ShippedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StoreID");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            CustomerID = 1,
                            OrderDate = new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequiredDate = new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShippedDate = new DateTime(2020, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreID = 1
                        },
                        new
                        {
                            OrderId = 2,
                            CustomerID = 2,
                            OrderDate = new DateTime(2021, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RequiredDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ShippedDate = new DateTime(2021, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StoreID = 2
                        });
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"), 1L, 1);

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("ModelYear")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId");

                    b.HasIndex("BrandID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            BrandID = 1,
                            CategoryID = 1,
                            ModelYear = 2020,
                            Price = 1200m,
                            ProductName = "Bmax 4 wiler"
                        },
                        new
                        {
                            ProductId = 2,
                            BrandID = 2,
                            CategoryID = 2,
                            ModelYear = 2018,
                            Price = 2300m,
                            ProductName = "RMB Max"
                        },
                        new
                        {
                            ProductId = 3,
                            BrandID = 3,
                            CategoryID = 3,
                            ModelYear = 2007,
                            Price = 800m,
                            ProductName = "Bmax 4 wiler"
                        },
                        new
                        {
                            ProductId = 4,
                            BrandID = 4,
                            CategoryID = 4,
                            ModelYear = 2020,
                            Price = 1500m,
                            ProductName = "Max"
                        });
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Store", b =>
                {
                    b.Property<int>("StoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StoreId"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Contacts")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreId");

                    b.HasIndex("ProductID");

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            StoreId = 1,
                            Address = "121 Lake street Sandton Gauteng",
                            Contacts = 123654,
                            Email = "bikeSonton@bikeshop.co.za",
                            ProductID = 1,
                            StoreName = "Sandton Shop"
                        },
                        new
                        {
                            StoreId = 2,
                            Address = "10 Ocean Blue Mall  CapeTown Western Cape",
                            Contacts = 123654,
                            Email = "bikeCapeTown@bikeshop.co.za",
                            ProductID = 2,
                            StoreName = "Cape Town Shop"
                        },
                        new
                        {
                            StoreId = 3,
                            Address = "Rich street 10A Bloem FS",
                            Contacts = 123654,
                            Email = "bikeBloem@bikeshop.co.za",
                            ProductID = 3,
                            StoreName = "Bloemfontein Shop"
                        });
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Order", b =>
                {
                    b.HasOne("BikeShop.Entities.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeShop.Entities.Models.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Product", b =>
                {
                    b.HasOne("BikeShop.Entities.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BikeShop.Entities.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BikeShop.Entities.Models.Store", b =>
                {
                    b.HasOne("BikeShop.Entities.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}