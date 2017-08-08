using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using StoreOfBuild.Data;
using StoreOfBuild.Data.Contexts;

namespace StoreOfBuild.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170708235219_AddProduct")]
    partial class AddProduct
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

            modelBuilder.Entity("StoreOfBuild.Domain.Products.Product", b =>
                {
                    b.HasOne("StoreOfBuild.Domain.Products.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");
                });
        }
    }
}
