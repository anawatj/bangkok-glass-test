﻿// <auto-generated />
using System;
using Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domains.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "db9c8841-efbd-48e3-9636-11c7de440010",
                            CategoryName = "Cookies"
                        },
                        new
                        {
                            Id = "8959b817-2c19-47ac-ae3f-4f446638619e",
                            CategoryName = "Crackers"
                        },
                        new
                        {
                            Id = "262474b5-eba8-4f88-bcd8-a3c70aaf74d8",
                            CategoryName = "Bars"
                        },
                        new
                        {
                            Id = "e21d6266-ff57-4ee0-9b7f-26492e8878c4",
                            CategoryName = "Snack"
                        });
                });

            modelBuilder.Entity("Core.Domains.City", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RegionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RegionId");

                    b.ToTable("Cities", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f66d70c2-fb76-47cd-b857-8a1f95cc6f26",
                            CityName = "Boston",
                            RegionId = "fb75e403-e2d9-4fa8-a499-46995aea008d"
                        },
                        new
                        {
                            Id = "ba0c074a-8388-4ca1-8918-1bb29c47201c",
                            CityName = "New York",
                            RegionId = "fb75e403-e2d9-4fa8-a499-46995aea008d"
                        },
                        new
                        {
                            Id = "ba999d0d-3f3f-4c84-9245-61fb1a98c852",
                            CityName = "Los Angeles",
                            RegionId = "43380845-8317-409b-803c-c73e47bf875a"
                        },
                        new
                        {
                            Id = "f71e8d8b-55fe-444a-99b8-945704c0d650",
                            CityName = "Santiago",
                            RegionId = "43380845-8317-409b-803c-c73e47bf875a"
                        });
                });

            modelBuilder.Entity("Core.Domains.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CityId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RegionId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("TotalPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CityId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RegionId");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Core.Domains.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "2d0ded5e-2356-4b51-944c-da716ae1c657",
                            CategoryId = "db9c8841-efbd-48e3-9636-11c7de440010",
                            ProductName = "Arrowroot"
                        },
                        new
                        {
                            Id = "388f2e8e-ab0d-4f32-91ce-78b13de46758",
                            CategoryId = "db9c8841-efbd-48e3-9636-11c7de440010",
                            ProductName = "Chocolate Chip"
                        },
                        new
                        {
                            Id = "b921c3de-f523-4d9b-85c1-1ec754506cc6",
                            CategoryId = "8959b817-2c19-47ac-ae3f-4f446638619e",
                            ProductName = "Whole Wheat"
                        },
                        new
                        {
                            Id = "5e5a1cc6-e795-47da-aae6-3b9124b6ef3e",
                            CategoryId = "e21d6266-ff57-4ee0-9b7f-26492e8878c4",
                            ProductName = "Potato Chips"
                        },
                        new
                        {
                            Id = "b84efd99-bf35-4a33-9653-8aebd7ccbb39",
                            CategoryId = "e21d6266-ff57-4ee0-9b7f-26492e8878c4",
                            ProductName = "Pretzels"
                        },
                        new
                        {
                            Id = "dbd3518a-2a27-44d8-8fb2-09ebadacaaaf",
                            CategoryId = "262474b5-eba8-4f88-bcd8-a3c70aaf74d8",
                            ProductName = "Carrot"
                        },
                        new
                        {
                            Id = "a46fd69c-9b80-41e1-a203-b5e5e0279e87",
                            CategoryId = "262474b5-eba8-4f88-bcd8-a3c70aaf74d8",
                            ProductName = "Bran"
                        });
                });

            modelBuilder.Entity("Core.Domains.Region", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "fb75e403-e2d9-4fa8-a499-46995aea008d",
                            RegionName = "EAST"
                        },
                        new
                        {
                            Id = "43380845-8317-409b-803c-c73e47bf875a",
                            RegionName = "WEST"
                        });
                });

            modelBuilder.Entity("Core.Domains.City", b =>
                {
                    b.HasOne("Core.Domains.Region", "Region")
                        .WithMany("Cities")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Core.Domains.Order", b =>
                {
                    b.HasOne("Core.Domains.Category", "Category")
                        .WithMany("Orders")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Domains.City", "City")
                        .WithMany("Orders")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Domains.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Domains.Region", "Region")
                        .WithMany("Orders")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");

                    b.Navigation("Product");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Core.Domains.Product", b =>
                {
                    b.HasOne("Core.Domains.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Core.Domains.Category", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Core.Domains.City", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Core.Domains.Product", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Core.Domains.Region", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
