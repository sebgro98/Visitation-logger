﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ResourceServer.Data;

#nullable disable

namespace ResourceServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241120132606_UpdatedStatusModel")]
    partial class UpdatedStatusModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f"),
                            Name = "MasterAdmin"
                        },
                        new
                        {
                            Id = new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a"),
                            Name = "LoggAdmin"
                        },
                        new
                        {
                            Id = new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"),
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
                            Id = new Guid("2840fdf4-638e-4a6c-a26c-23cada294ce0"),
                            AccountTypeId = new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f"),
                            FullName = "Master Admin",
                            NodeId = new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            Username = "Master-Admin"
                        },
                        new
                        {
                            Id = new Guid("543cfe43-ef05-48c2-a097-28b7775b500a"),
                            AccountTypeId = new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a"),
                            FullName = "Logging Admin",
                            NodeId = new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"),
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
                            Id = new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321"),
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e"),
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
                            Id = new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                            NodeName = "Stockholm Office"
                        },
                        new
                        {
                            Id = new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"),
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
                            Id = new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"),
                            Name = "Service"
                        },
                        new
                        {
                            Id = new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377"),
                            Name = "Event"
                        },
                        new
                        {
                            Id = new Guid("8de6812e-caff-4991-9285-1c665e2b90dd"),
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

                    b.Property<Guid?>("VisitorId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("VisitorAccountId");

                    b.HasIndex("VisitorId");

                    b.ToTable("status");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c52a87c8-083e-4c81-8db4-bb75727c301d"),
                            CheckInSign = "JD123",
                            CheckInTime = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JD456",
                            CheckOutTime = new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                            VisitorAccountId = new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd")
                        },
                        new
                        {
                            Id = new Guid("53e78c27-2525-4dae-ba8c-be5cd619ba16"),
                            CheckInSign = "JS321",
                            CheckInTime = new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JS654",
                            CheckOutTime = new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"),
                            VisitorAccountId = new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9")
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
                            Id = new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc"),
                            City = "Stockholm",
                            Company = "TechCorp",
                            CountryId = new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321"),
                            FullName = "John Doe",
                            PassportNo = "A1234567",
                            SSN = "123-45-6789"
                        },
                        new
                        {
                            Id = new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1"),
                            City = "Oslo",
                            Company = "InnovateInc",
                            CountryId = new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e"),
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
                            Id = new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd"),
                            AccountTypeId = new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "john.doe",
                            VisitorId = new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc")
                        },
                        new
                        {
                            Id = new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9"),
                            AccountTypeId = new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "jane.smith",
                            VisitorId = new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1")
                        },
                        new
                        {
                            Id = new Guid("5766c22b-7807-4ee5-a2fb-9638c1c0e449"),
                            AccountTypeId = new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"),
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

                    b.HasOne("SharedModels.Models.Visitor", null)
                        .WithMany("Status")
                        .HasForeignKey("VisitorId");

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
                    b.Navigation("Status");

                    b.Navigation("VisitorAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
