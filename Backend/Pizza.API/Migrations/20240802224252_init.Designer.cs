﻿// <auto-generated />
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pizza.API.Dal;

#nullable disable

namespace Pizza.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240802224252_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AdditivePizza", b =>
                {
                    b.Property<int>("AdditivesId")
                        .HasColumnType("integer");

                    b.Property<int>("PizzasId")
                        .HasColumnType("integer");

                    b.HasKey("AdditivesId", "PizzasId");

                    b.HasIndex("PizzasId");

                    b.ToTable("AdditivePizza");
                });

            modelBuilder.Entity("Pizza.API.Domain.Entities.Additive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Additives");
                });

            modelBuilder.Entity("Pizza.API.Domain.Entities.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BasePrice")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DoughType")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Radius")
                        .HasColumnType("double precision");

                    b.Property<int>("Sizetype")
                        .HasColumnType("integer");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.ComplexProperty<Dictionary<string, object>>("NutritionalValue", "Pizza.API.Domain.Entities.Pizza.NutritionalValue#NutritionalValue", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<double>("Carbonydrates")
                                .HasColumnType("double precision");

                            b1.Property<double>("EnergyValue")
                                .HasColumnType("double precision");

                            b1.Property<double>("Fats")
                                .HasColumnType("double precision");

                            b1.Property<double>("Protein")
                                .HasColumnType("double precision");
                        });

                    b.HasKey("Id");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("AdditivePizza", b =>
                {
                    b.HasOne("Pizza.API.Domain.Entities.Additive", null)
                        .WithMany()
                        .HasForeignKey("AdditivesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pizza.API.Domain.Entities.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
