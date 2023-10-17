﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web.Migrations
{
    [DbContext(typeof(DomoupravitelDbContext))]
    [Migration("20231015145355_PersonDescriptorOneToManyToPerson")]
    partial class PersonDescriptorOneToManyToPerson
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

            modelBuilder.Entity("Domoupravitel.Models.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

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

                    b.Property<DateTime>("RegisteredOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Residence")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UnRegisteredOn")
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
                            Id = "54d99be3-4d50-4683-b0e2-e0b05a0442d9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "518f30d7-b99e-456f-8e35-ce1329fcc449",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            Name = "wnvko",
                            PasswordHash = "AQAAAAEAACcQAAAAEEd1cw/Obf8SAju+mdr3La1pOJdHT9n+MPn2fumjFFlP+5tm4QrPHhR+qNbC1qiwqA==",
                            PhoneNumberConfirmed = false,
                            Role = 0,
                            SecurityStamp = "79834631-4915-4b55-97d7-6d58bed321a9",
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
