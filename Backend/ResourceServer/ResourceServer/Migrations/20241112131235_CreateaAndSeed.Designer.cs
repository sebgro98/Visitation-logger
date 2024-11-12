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
    [Migration("20241112131235_CreateaAndSeed")]
    partial class CreateaAndSeed
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
                            Id = new Guid("3a868a47-34fd-41e9-9e4e-1280007e933b"),
                            Name = "MasterAdmin"
                        },
                        new
                        {
                            Id = new Guid("36a817d3-4445-4779-a60b-23dc36d72cbf"),
                            Name = "LoggAdmin"
                        },
                        new
                        {
                            Id = new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"),
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

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("admins");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a1990d8a-edc3-43bd-93d9-b927acb3ce61"),
                            AccountTypeId = new Guid("3a868a47-34fd-41e9-9e4e-1280007e933b"),
                            Password = "Password123!",
                            Username = "Master-Admin"
                        },
                        new
                        {
                            Id = new Guid("5f2de9fe-96d6-4fcc-94ea-cc61a23e95f4"),
                            AccountTypeId = new Guid("36a817d3-4445-4779-a60b-23dc36d72cbf"),
                            Password = "Password321!",
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
                            Id = new Guid("3732d939-b4bd-4aa5-9d1e-cf8bb3711abd"),
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("7db8e65e-092d-45f3-bf5b-0bb21621047e"),
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
                            Id = new Guid("140c797b-330e-4882-8f93-98765bc01caa"),
                            NodeName = "Main Gate"
                        },
                        new
                        {
                            Id = new Guid("561007e8-0075-475e-9ffa-86de967d2568"),
                            NodeName = "Lobby Entrance"
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
                            Id = new Guid("a98dc435-e2ce-4470-be62-bf58f677aec7"),
                            Name = "Service"
                        },
                        new
                        {
                            Id = new Guid("ab3e25bf-7fec-41af-bc14-eaed5a93f652"),
                            Name = "Event"
                        },
                        new
                        {
                            Id = new Guid("b2f41591-cf26-4531-ab41-062441156a34"),
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
                        .HasColumnType("uuid")
                        .HasColumnName("visitor_id");

                    b.HasKey("Id");

                    b.HasIndex("NodeId");

                    b.HasIndex("VisitorId");

                    b.ToTable("status");

                    b.HasData(
                        new
                        {
                            Id = new Guid("873e8a5c-dda4-4884-b1cd-6dc44f7a664e"),
                            CheckInSign = "JD123",
                            CheckInTime = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JD456",
                            CheckOutTime = new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("140c797b-330e-4882-8f93-98765bc01caa"),
                            VisitorId = new Guid("ca1f1a3e-b406-4702-aae8-661c00123b40")
                        },
                        new
                        {
                            Id = new Guid("2528cb14-9998-465c-a77a-df388986fc00"),
                            CheckInSign = "JS321",
                            CheckInTime = new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JS654",
                            CheckOutTime = new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("561007e8-0075-475e-9ffa-86de967d2568"),
                            VisitorId = new Guid("a02cecf6-0749-48ba-bccd-f5871df211ab")
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
                            Id = new Guid("ca1f1a3e-b406-4702-aae8-661c00123b40"),
                            City = "Stockholm",
                            Company = "TechCorp",
                            CountryId = new Guid("3732d939-b4bd-4aa5-9d1e-cf8bb3711abd"),
                            FullName = "John Doe",
                            PassportNo = "A1234567",
                            SSN = "123-45-6789"
                        },
                        new
                        {
                            Id = new Guid("a02cecf6-0749-48ba-bccd-f5871df211ab"),
                            City = "Oslo",
                            Company = "InnovateInc",
                            CountryId = new Guid("7db8e65e-092d-45f3-bf5b-0bb21621047e"),
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

                    b.HasIndex("PurposeTypeId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.HasIndex("VisitorId");

                    b.ToTable("visitorAccounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("076e538a-e0d1-4f90-b9f5-246afca9ac16"),
                            AccountTypeId = new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            Password = "securePass1!",
                            PurposeTypeId = new Guid("a98dc435-e2ce-4470-be62-bf58f677aec7"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "john.doe",
                            VisitorId = new Guid("ca1f1a3e-b406-4702-aae8-661c00123b40")
                        },
                        new
                        {
                            Id = new Guid("3f442613-8804-414e-8517-f36c22a90a84"),
                            AccountTypeId = new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            Password = "securePass2!",
                            PurposeTypeId = new Guid("ab3e25bf-7fec-41af-bc14-eaed5a93f652"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "jane.smith",
                            VisitorId = new Guid("a02cecf6-0749-48ba-bccd-f5871df211ab")
                        },
                        new
                        {
                            Id = new Guid("73efd26a-3ef3-4a51-b917-a6696635466a"),
                            AccountTypeId = new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            Password = "securePass1!",
                            PurposeTypeId = new Guid("a98dc435-e2ce-4470-be62-bf58f677aec7"),
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

                    b.Navigation("AccountType");
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

                    b.HasOne("SharedModels.Models.PurposeType", "PurposeType")
                        .WithMany()
                        .HasForeignKey("PurposeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SharedModels.Models.Visitor", "Visitor")
                        .WithMany("VisitorAccounts")
                        .HasForeignKey("VisitorId");

                    b.Navigation("AccountType");

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