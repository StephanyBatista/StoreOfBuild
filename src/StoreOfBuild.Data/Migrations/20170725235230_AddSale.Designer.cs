using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StoreOfBuild.Data.Contexts;

namespace StoreOfBuild.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170725235230_AddSale")]
    partial class AddSale
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StoreOfBuild.Domain.Products.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StoreOfBuild.Domain.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CategoryId");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("StockQuantity");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StoreOfBuild.Domain.Sales.Sale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClientName");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("ItemId");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("StoreOfBuild.Domain.Sales.SaleItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("SaleItem");
                });

            modelBuilder.Entity("StoreOfBuild.Domain.Products.Product", b =>
                {
                    b.HasOne("StoreOfBuild.Domain.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("StoreOfBuild.Domain.Sales.Sale", b =>
                {
                    b.HasOne("StoreOfBuild.Domain.Sales.SaleItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("StoreOfBuild.Domain.Sales.SaleItem", b =>
                {
                    b.HasOne("StoreOfBuild.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
