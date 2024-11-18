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
                            Id = new Guid("2a610367-d627-4e5e-9c3e-89977d531090"),
                            Name = "MasterAdmin"
                        },
                        new
                        {
                            Id = new Guid("6f0dd1d5-ca3c-450f-9e04-8338f1d0f308"),
                            Name = "LoggAdmin"
                        },
                        new
                        {
                            Id = new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"),
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
                            Id = new Guid("8665bd5d-ee97-4ffd-a1cb-020abc34f9de"),
                            AccountTypeId = new Guid("2a610367-d627-4e5e-9c3e-89977d531090"),
                            FullName = "Master Admin",
                            NodeId = new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            Username = "Master-Admin"
                        },
                        new
                        {
                            Id = new Guid("e6c565c9-8cfb-4df8-8cfd-32690861f6da"),
                            AccountTypeId = new Guid("6f0dd1d5-ca3c-450f-9e04-8338f1d0f308"),
                            FullName = "Logging Admin",
                            NodeId = new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"),
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
                            Id = new Guid("fb319aab-4467-46f0-8ae8-2087e333af97"),
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("c3c890f7-8f57-4e90-9b12-f99b928a20e6"),
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
                            Id = new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"),
                            NodeName = "Stockholm Office"
                        },
                        new
                        {
                            Id = new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"),
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
                            Id = new Guid("1d903e81-57ea-407a-8397-ef5f9b9155b2"),
                            Name = "Service"
                        },
                        new
                        {
                            Id = new Guid("26b7a9dc-6ffb-4140-927c-d0f40d49c922"),
                            Name = "Event"
                        },
                        new
                        {
                            Id = new Guid("239cdf95-bf3f-47fe-afb7-2eedcb77379d"),
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

                    b.Property<Guid>("VisitorId")
                        .HasColumnType("uuid")
                        .HasColumnName("visitor_id");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("VisitorId");

                    b.ToTable("status");

                    b.HasData(
                        new
                        {
                            Id = new Guid("959738a7-3581-497c-9465-96db93b0bd87"),
                            CheckInSign = "JD123",
                            CheckInTime = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JD456",
                            CheckOutTime = new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"),
                            VisitorId = new Guid("d54c6c5c-87d1-4479-8e9f-76cb97d465e7")
                        },
                        new
                        {
                            Id = new Guid("b112294c-2521-4755-adeb-29c9a1054ee1"),
                            CheckInSign = "JS321",
                            CheckInTime = new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JS654",
                            CheckOutTime = new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"),
                            VisitorId = new Guid("2f7aaf4f-86b4-4523-af41-5a18317f1d33")
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
                            Id = new Guid("d54c6c5c-87d1-4479-8e9f-76cb97d465e7"),
                            City = "Stockholm",
                            Company = "TechCorp",
                            CountryId = new Guid("fb319aab-4467-46f0-8ae8-2087e333af97"),
                            FullName = "John Doe",
                            PassportNo = "A1234567",
                            SSN = "123-45-6789"
                        },
                        new
                        {
                            Id = new Guid("2f7aaf4f-86b4-4523-af41-5a18317f1d33"),
                            City = "Oslo",
                            Company = "InnovateInc",
                            CountryId = new Guid("c3c890f7-8f57-4e90-9b12-f99b928a20e6"),
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
                        .HasColumnType("uuid");

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
                            Id = new Guid("62c92b11-1c55-4414-bf97-1fc3f3b2cb16"),
                            AccountTypeId = new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("1d903e81-57ea-407a-8397-ef5f9b9155b2"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "john.doe",
                            VisitorId = new Guid("d54c6c5c-87d1-4479-8e9f-76cb97d465e7")
                        },
                        new
                        {
                            Id = new Guid("82c29b80-7d7e-4df8-851b-c143eeea3bff"),
                            AccountTypeId = new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("26b7a9dc-6ffb-4140-927c-d0f40d49c922"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "jane.smith",
                            VisitorId = new Guid("2f7aaf4f-86b4-4523-af41-5a18317f1d33")
                        },
                        new
                        {
                            Id = new Guid("b948f141-c4a9-4bea-a30c-115b2abcf0b7"),
                            AccountTypeId = new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("1d903e81-57ea-407a-8397-ef5f9b9155b2"),
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

                    b.HasOne("SharedModels.Models.Visitor", "Visitor")
                        .WithMany("Status")
                        .HasForeignKey("VisitorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Node");

                    b.Navigation("Visitor");
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
                    b.Navigation("Status");

                    b.Navigation("VisitorAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
