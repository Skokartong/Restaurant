﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurant.Data;

#nullable disable

namespace Restaurant.Migrations
{
    [DbContext(typeof(RestaurantContext))]
    [Migration("20240829155456_Reservation")]
    partial class Reservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restaurant.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("FK_RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_RestaurantId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Restaurant.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Drink")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("FK_RestaurantId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("NameOfDish")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("FK_RestaurantId");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Restaurant.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int?>("FK_CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("FK_MenuId")
                        .HasColumnType("int");

                    b.Property<int?>("FK_TableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_CustomerId");

                    b.HasIndex("FK_MenuId");

                    b.HasIndex("FK_TableId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Restaurant.Models.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BookingEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BookingStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FK_CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("FK_TableId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_CustomerId");

                    b.HasIndex("FK_TableId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Restaurant.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RestaurantName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Restaurants");
                });

            modelBuilder.Entity("Restaurant.Models.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AmountOfSeats")
                        .HasColumnType("int");

                    b.Property<int?>("FK_RestaurantId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<int>("TableNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_RestaurantId");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("Restaurant.Models.Customer", b =>
                {
                    b.HasOne("Restaurant.Models.Restaurant", "Restaurant")
                        .WithMany("Customers")
                        .HasForeignKey("FK_RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Restaurant.Models.Menu", b =>
                {
                    b.HasOne("Restaurant.Models.Restaurant", "Restaurant")
                        .WithMany("Menus")
                        .HasForeignKey("FK_RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Restaurant.Models.Order", b =>
                {
                    b.HasOne("Restaurant.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("FK_CustomerId");

                    b.HasOne("Restaurant.Models.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("FK_MenuId");

                    b.HasOne("Restaurant.Models.Table", "Table")
                        .WithMany("Orders")
                        .HasForeignKey("FK_TableId");

                    b.Navigation("Customer");

                    b.Navigation("Menu");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Restaurant.Models.Reservation", b =>
                {
                    b.HasOne("Restaurant.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("FK_CustomerId");

                    b.HasOne("Restaurant.Models.Table", "Table")
                        .WithMany()
                        .HasForeignKey("FK_TableId");

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("Restaurant.Models.Table", b =>
                {
                    b.HasOne("Restaurant.Models.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("FK_RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("Restaurant.Models.Customer", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Restaurant.Models.Restaurant", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Menus");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("Restaurant.Models.Table", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
