﻿// <auto-generated />
using System;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessObject.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20241021075248_InitDb")]
    partial class InitDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObject.Models.Author", b =>
                {
                    b.Property<int>("author_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("author_id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("author_id");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            author_id = 1,
                            address = "123 Main St",
                            city = "New York",
                            email_address = "john.doe@example.com",
                            first_name = "John",
                            last_name = "Doe",
                            phone = "123-456-7890",
                            state = "NY",
                            zip = "10001"
                        },
                        new
                        {
                            author_id = 2,
                            address = "456 Maple Ave",
                            city = "Los Angeles",
                            email_address = "jane.smith@example.com",
                            first_name = "Jane",
                            last_name = "Smith",
                            phone = "098-765-4321",
                            state = "CA",
                            zip = "90001"
                        });
                });

            modelBuilder.Entity("BusinessObject.Models.Book", b =>
                {
                    b.Property<int>("book_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("book_id"));

                    b.Property<decimal>("advance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("pub_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("published_date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("royalty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ytd_sales")
                        .HasColumnType("int");

                    b.HasKey("book_id");

                    b.HasIndex("pub_id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            book_id = 1,
                            advance = 5000m,
                            notes = "Excellent resource",
                            price = 49.99m,
                            pub_id = 1,
                            published_date = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            royalty = 10m,
                            title = "Learning EF Core",
                            type = "Technical",
                            ytd_sales = 500
                        },
                        new
                        {
                            book_id = 2,
                            advance = 6000m,
                            notes = "Highly recommended",
                            price = 59.99m,
                            pub_id = 2,
                            published_date = new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            royalty = 12m,
                            title = "Mastering ASP.NET",
                            type = "Technical",
                            ytd_sales = 300
                        });
                });

            modelBuilder.Entity("BusinessObject.Models.BookAuthor", b =>
                {
                    b.Property<int>("book_id")
                        .HasColumnType("int");

                    b.Property<int>("author_id")
                        .HasColumnType("int");

                    b.Property<int>("author_order")
                        .HasColumnType("int");

                    b.Property<decimal>("royality_percentage")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("book_id", "author_id");

                    b.HasIndex("author_id");

                    b.ToTable("BookAuthors");

                    b.HasData(
                        new
                        {
                            book_id = 1,
                            author_id = 1,
                            author_order = 1,
                            royality_percentage = 10m
                        },
                        new
                        {
                            book_id = 2,
                            author_id = 2,
                            author_order = 1,
                            royality_percentage = 12m
                        });
                });

            modelBuilder.Entity("BusinessObject.Models.Publisher", b =>
                {
                    b.Property<int>("pub_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pub_id"));

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("publisher_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("pub_id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            pub_id = 1,
                            city = "Sebastopol",
                            country = "USA",
                            publisher_name = "O'Reilly Media",
                            state = "CA"
                        },
                        new
                        {
                            pub_id = 2,
                            city = "Birmingham",
                            country = "UK",
                            publisher_name = "Packt Publishing",
                            state = "West Midlands"
                        });
                });

            modelBuilder.Entity("BusinessObject.Models.Role", b =>
                {
                    b.Property<int>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("role_id"));

                    b.Property<string>("role_desc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("role_id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            role_id = 1,
                            role_desc = "Admin"
                        },
                        new
                        {
                            role_id = 2,
                            role_desc = "User"
                        });
                });

            modelBuilder.Entity("BusinessObject.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("user_id"));

                    b.Property<string>("email_address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("hire_date")
                        .HasColumnType("datetime2");

                    b.Property<string>("last_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middle_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pub_id")
                        .HasColumnType("int");

                    b.Property<int>("role_id")
                        .HasColumnType("int");

                    b.Property<string>("source")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.HasIndex("pub_id");

                    b.HasIndex("role_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            user_id = 1,
                            email_address = "admin@example.com",
                            first_name = "Admin",
                            hire_date = new DateTime(2024, 10, 21, 14, 52, 48, 485, DateTimeKind.Local).AddTicks(614),
                            last_name = "User",
                            middle_name = "",
                            password = "password",
                            pub_id = 1,
                            role_id = 1,
                            source = "Internal"
                        },
                        new
                        {
                            user_id = 2,
                            email_address = "user@example.com",
                            first_name = "Normal",
                            hire_date = new DateTime(2024, 10, 21, 14, 52, 48, 485, DateTimeKind.Local).AddTicks(629),
                            last_name = "User",
                            middle_name = "",
                            password = "password",
                            pub_id = 2,
                            role_id = 2,
                            source = "Internal"
                        });
                });

            modelBuilder.Entity("BusinessObject.Models.Book", b =>
                {
                    b.HasOne("BusinessObject.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("pub_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BusinessObject.Models.BookAuthor", b =>
                {
                    b.HasOne("BusinessObject.Models.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("author_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("book_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BusinessObject.Models.User", b =>
                {
                    b.HasOne("BusinessObject.Models.Publisher", "Publisher")
                        .WithMany("Users")
                        .HasForeignKey("pub_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObject.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BusinessObject.Models.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BusinessObject.Models.Book", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BusinessObject.Models.Publisher", b =>
                {
                    b.Navigation("Books");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BusinessObject.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
