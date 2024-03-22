﻿// <auto-generated />
using System;
using Domoupravitel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domoupravitel.Web.Migrations
{
    [DbContext(typeof(DomoupravitelDbContext))]
    [Migration("20240129215443_GridState")]
    partial class GridState
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domoupravitel.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("PropertyId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Domoupravitel.Models.Chip", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("Disabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Chips");
                });

            modelBuilder.Entity("Domoupravitel.Models.GridState", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("GridName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Options")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GridName");

                    b.ToTable("GridStates");
                });

            modelBuilder.Entity("Domoupravitel.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Domoupravitel.Models.PersonDescriptor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("MonthsInHouse")
                        .HasColumnType("int");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("RegisteredOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Residence")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UnRegisteredOn")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.HasIndex("PropertyId");

                    b.ToTable("Descriptors");
                });

            modelBuilder.Entity("Domoupravitel.Models.Pet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("PropertyId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("PropertyId");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("Domoupravitel.Models.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Share")
                        .HasColumnType("double");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Domoupravitel.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = "25d1f761-de81-4ecc-b002-28cc3c54d880",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "00f34567-4c6f-44f4-9d31-16fe119f76f5",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "wnvko",
                            PasswordHash = "AQAAAAEAACcQAAAAELcd9wqkbILQQCsB60GgUqbe6xuYKF7mncyuYSjtp0KcHw40IJVNjNxdbKXA6gJFpA==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "dc5937f6-9dce-4a3f-b11d-4a9fa79a1f40",
                            TwoFactorEnabled = false,
                            UserName = "wnvko"
                        });
                });

            modelBuilder.Entity("Domoupravitel.Models.Car", b =>
                {
                    b.HasOne("Domoupravitel.Models.Property", "Property")
                        .WithMany("Cars")
                        .HasForeignKey("PropertyId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Domoupravitel.Models.Chip", b =>
                {
                    b.HasOne("Domoupravitel.Models.Person", "Person")
                        .WithMany("Chips")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Domoupravitel.Models.PersonDescriptor", b =>
                {
                    b.HasOne("Domoupravitel.Models.Person", "Person")
                        .WithMany("Descriptors")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domoupravitel.Models.Property", "Property")
                        .WithMany("People")
                        .HasForeignKey("PropertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Domoupravitel.Models.Pet", b =>
                {
                    b.HasOne("Domoupravitel.Models.Property", "Property")
                        .WithMany("Pets")
                        .HasForeignKey("PropertyId");

                    b.Navigation("Property");
                });

            modelBuilder.Entity("Domoupravitel.Models.Person", b =>
                {
                    b.Navigation("Chips");

                    b.Navigation("Descriptors");
                });

            modelBuilder.Entity("Domoupravitel.Models.Property", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("People");

                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}