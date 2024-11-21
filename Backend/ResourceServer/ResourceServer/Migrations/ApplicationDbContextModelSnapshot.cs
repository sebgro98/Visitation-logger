﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResourceServer.Data;

#nullable disable

namespace ResourceServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SharedModels.Models.AccountType", b =>
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

                    b.ToTable("account_types");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7d4db1e6-30c0-465b-9ca4-368a93445844"),
                            Name = "MasterAdmin"
                        },
                        new
                        {
                            Id = new Guid("c06043bb-c05c-4ea8-b208-421c47befa15"),
                            Name = "LoggAdmin"
                        },
                        new
                        {
                            Id = new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"),
                            Name = "Visitor"
                        });
                });

            modelBuilder.Entity("SharedModels.Models.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_type_id");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("NodeId")
                        .HasColumnType("uuid")
                        .HasColumnName("node_Id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("NodeId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("60359f12-7e1f-428f-82bb-e4190cb9c474"),
                            AccountTypeId = new Guid("7d4db1e6-30c0-465b-9ca4-368a93445844"),
                            FullName = "Master Admin",
                            NodeId = new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            Username = "Master-Admin"
                        },
                        new
                        {
                            Id = new Guid("f025c6c9-ed77-4d44-97d4-86c1c8c4d683"),
                            AccountTypeId = new Guid("c06043bb-c05c-4ea8-b208-421c47befa15"),
                            FullName = "Logging Admin",
                            NodeId = new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            Username = "Logging-Admin"
                        });
                });

            modelBuilder.Entity("SharedModels.Models.Country", b =>
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

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3432dcc4-8ab8-4cea-b415-78a56ca11729"),
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("40eccb6e-1ff4-44e3-9d24-2e3a631c6c34"),
                            CountryName = "Norway"
                        });
                });

            modelBuilder.Entity("SharedModels.Models.Node", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"),
                            NodeName = "Stockholm Office"
                        },
                        new
                        {
                            Id = new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"),
                            NodeName = "Oslo Office"
                        });
                });

            modelBuilder.Entity("SharedModels.Models.PurposeType", b =>
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
                            Id = new Guid("e9465804-912c-4187-9641-f4b900623a36"),
                            Name = "Service"
                        },
                        new
                        {
                            Id = new Guid("7fde4b49-2de8-4513-99e6-dfa3db4b5fed"),
                            Name = "Event"
                        },
                        new
                        {
                            Id = new Guid("f4a3c769-20e8-46f8-afef-de0fbab29885"),
                            Name = "Meeting"
                        });
                });

            modelBuilder.Entity("SharedModels.Models.Status", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("CheckInSign")
                        .HasColumnType("text")
                        .HasColumnName("check_in_sign");

                    b.Property<DateTime>("CheckInTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("check_in_time");

                    b.Property<string>("CheckOutSign")
                        .HasColumnType("text")
                        .HasColumnName("check_out_sign");

                    b.Property<DateTime?>("CheckOutTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("check_out_time");

                    b.Property<DateTime?>("LastExportDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_export_date");

                    b.Property<Guid>("NodeId")
                        .HasColumnType("uuid")
                        .HasColumnName("node_id");

                    b.Property<Guid>("VisitorAccountId")
                        .HasColumnType("uuid")
                        .HasColumnName("visitor_account_id");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("VisitorAccountId");

                    b.ToTable("status");

                    b.HasData(
                        new
                        {
                            Id = new Guid("229fa498-a558-4498-8ba2-b04c9f3dc3e5"),
                            CheckInSign = "JD123",
                            CheckInTime = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JD456",
                            CheckOutTime = new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"),
                            VisitorAccountId = new Guid("0373dd99-a8dc-494d-bd43-c24de6a53835")
                        },
                        new
                        {
                            Id = new Guid("71974d2c-40ba-42b7-be50-ef6e892ce081"),
                            CheckInSign = "JS321",
                            CheckInTime = new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JS654",
                            CheckOutTime = new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"),
                            VisitorAccountId = new Guid("708ed67c-97e6-42a8-8223-9358f9a60727")
                        });
                });

            modelBuilder.Entity("SharedModels.Models.Visitor", b =>
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("eddd2fc4-b146-448a-a150-88bfc5cdd48e"),
                            City = "Stockholm",
                            Company = "TechCorp",
                            CountryId = new Guid("3432dcc4-8ab8-4cea-b415-78a56ca11729"),
                            FullName = "John Doe",
                            PassportNo = "A1234567",
                            SSN = "123-45-6789"
                        },
                        new
                        {
                            Id = new Guid("91d83a1a-69dd-43a8-8101-45fab24e8607"),
                            City = "Oslo",
                            Company = "InnovateInc",
                            CountryId = new Guid("40eccb6e-1ff4-44e3-9d24-2e3a631c6c34"),
                            FullName = "Jane Smith",
                            PassportNo = "B7654321",
                            SSN = "987-65-4321"
                        });
                });

            modelBuilder.Entity("SharedModels.Models.VisitorAccount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("AccountTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("account_type_id");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("end_date");

                    b.Property<Guid>("NodeId")
                        .HasColumnType("uuid")
                        .HasColumnName("node_id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("password");

                    b.Property<Guid>("PurposeTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("purpose_type_id");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("start_date");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("username");

                    b.Property<Guid?>("VisitorId")
                        .HasColumnType("uuid")
                        .HasColumnName("visitor_id");

                    b.HasKey("Id");

                    b.HasIndex("AccountTypeId");

                    b.HasIndex("NodeId");

                    b.HasIndex("PurposeTypeId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("VisitorId");

                    b.ToTable("visitorAccounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0373dd99-a8dc-494d-bd43-c24de6a53835"),
                            AccountTypeId = new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("e9465804-912c-4187-9641-f4b900623a36"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "john.doe",
                            VisitorId = new Guid("eddd2fc4-b146-448a-a150-88bfc5cdd48e")
                        },
                        new
                        {
                            Id = new Guid("708ed67c-97e6-42a8-8223-9358f9a60727"),
                            AccountTypeId = new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("7fde4b49-2de8-4513-99e6-dfa3db4b5fed"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "jane.smith",
                            VisitorId = new Guid("91d83a1a-69dd-43a8-8101-45fab24e8607")
                        },
                        new
                        {
                            Id = new Guid("41492cef-5697-42c9-ae84-899fce075184"),
                            AccountTypeId = new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("e9465804-912c-4187-9641-f4b900623a36"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "Angel.man"
                        });
                });

            modelBuilder.Entity("SharedModels.Models.Admin", b =>
                {
                    b.HasOne("SharedModels.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModels.Models.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AccountType");

                    b.Navigation("Node");
                });

            modelBuilder.Entity("SharedModels.Models.Status", b =>
                {
                    b.HasOne("SharedModels.Models.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModels.Models.VisitorAccount", "VisitorAccount")
                        .WithMany()
                        .HasForeignKey("VisitorAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");

                    b.Navigation("VisitorAccount");
                });

            modelBuilder.Entity("SharedModels.Models.Visitor", b =>
                {
                    b.HasOne("SharedModels.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SharedModels.Models.VisitorAccount", b =>
                {
                    b.HasOne("SharedModels.Models.AccountType", "AccountType")
                        .WithMany()
                        .HasForeignKey("AccountTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModels.Models.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModels.Models.PurposeType", "PurposeType")
                        .WithMany()
                        .HasForeignKey("PurposeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModels.Models.Visitor", "Visitor")
                        .WithMany("VisitorAccounts")
                        .HasForeignKey("VisitorId");

                    b.Navigation("AccountType");

                    b.Navigation("Node");

                    b.Navigation("PurposeType");

                    b.Navigation("Visitor");
                });

            modelBuilder.Entity("SharedModels.Models.Visitor", b =>
                {
                    b.Navigation("VisitorAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
