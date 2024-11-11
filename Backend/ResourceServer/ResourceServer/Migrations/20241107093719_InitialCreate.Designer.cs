﻿// <auto-generated />
using System;
using AuthenticationServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthenticationServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241107093719_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AuthenticationServer.Model.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AdminTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("admin_type_id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.HasIndex("AdminTypeId");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("AuthenticationServer.Model.AdminType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("admin_types");

                    b.HasData(
                        new
                        {
                            Id = new Guid("80565433-d4ee-4773-ac23-b484b4b7f36f"),
                            Name = "MasterAdmin"
                        },
                        new
                        {
                            Id = new Guid("5522bc1c-43a3-4850-9a04-385dc2aa29cc"),
                            Name = "LoggAdmin"
                        });
                });

            modelBuilder.Entity("AuthenticationServer.Model.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("country_name");

                    b.HasKey("Id");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("AuthenticationServer.Model.Node", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("NodeName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("node_name");

                    b.HasKey("Id");

                    b.ToTable("nodes");
                });

            modelBuilder.Entity("AuthenticationServer.Model.PurposeType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("purpose_types");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0d5abe13-4b5f-4fd6-ad74-a2cf129a94cf"),
                            Name = "Service"
                        },
                        new
                        {
                            Id = new Guid("d24e2c90-7132-465c-83c0-f1eea38fc0fa"),
                            Name = "Event"
                        },
                        new
                        {
                            Id = new Guid("59d1bf88-b964-4076-8818-5b7d52a0440a"),
                            Name = "Meeting"
                        });
                });

            modelBuilder.Entity("AuthenticationServer.Model.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CheckInSign")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("check_in_sign");

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("check_in_time");

                    b.Property<string>("CheckOutSign")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("check_out_sign");

                    b.Property<DateTime>("CheckOutTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("check_out_time");

                    b.Property<DateTime>("LastExportDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_export_date");

                    b.Property<Guid>("NodeId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("VisitorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("VisitorId");

                    b.ToTable("status");
                });

            modelBuilder.Entity("AuthenticationServer.Model.Visitor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("city");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("company");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid")
                        .HasColumnName("country_id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fullname");

                    b.Property<string>("PassportNo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("passport_no");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("SSN");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("visitors");
                });

            modelBuilder.Entity("AuthenticationServer.Model.VisitorAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<Guid>("PurposeTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("purpose_type_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("username");

                    b.Property<Guid>("VisitorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PurposeTypeId");

                    b.HasIndex("VisitorId");

                    b.ToTable("visitorAccounts");
                });

            modelBuilder.Entity("AuthenticationServer.Model.Admin", b =>
                {
                    b.HasOne("AuthenticationServer.Model.AdminType", "AdminType")
                        .WithMany()
                        .HasForeignKey("AdminTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdminType");
                });

            modelBuilder.Entity("AuthenticationServer.Model.Status", b =>
                {
                    b.HasOne("AuthenticationServer.Model.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthenticationServer.Model.Visitor", "Visitor")
                        .WithMany("Status")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("AuthenticationServer.Model.Visitor", b =>
                {
                    b.HasOne("AuthenticationServer.Model.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AuthenticationServer.Model.VisitorAccount", b =>
                {
                    b.HasOne("AuthenticationServer.Model.PurposeType", "PurposeType")
                        .WithMany()
                        .HasForeignKey("PurposeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthenticationServer.Model.Visitor", "Visitor")
                        .WithMany("VisitorAccounts")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PurposeType");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("AuthenticationServer.Model.Visitor", b =>
                {
                    b.Navigation("Status");

                    b.Navigation("VisitorAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
