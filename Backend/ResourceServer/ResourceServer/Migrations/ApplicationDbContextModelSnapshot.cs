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
                            Id = new Guid("9534d3ea-6eb4-4227-a7ac-c5fc2918cd11"),
                            Name = "MasterAdmin"
                        },
                        new
                        {
                            Id = new Guid("03aad3bb-965e-4c3b-9286-cf002f86e6c3"),
                            Name = "LoggAdmin"
                        },
                        new
                        {
                            Id = new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"),
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
                            Id = new Guid("8d513038-65bc-427a-8a55-46c58a49492a"),
                            AccountTypeId = new Guid("9534d3ea-6eb4-4227-a7ac-c5fc2918cd11"),
                            FullName = "Master Admin",
                            NodeId = new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            Username = "Master-Admin"
                        },
                        new
                        {
                            Id = new Guid("5a0b0c42-6886-4ae3-b0e4-4da51d3c8f0e"),
                            AccountTypeId = new Guid("03aad3bb-965e-4c3b-9286-cf002f86e6c3"),
                            FullName = "Logging Admin",
                            NodeId = new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"),
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
                            Id = new Guid("a398fad4-b3c1-4b6c-b096-936bcd49d775"),
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("77438c0f-9862-4ae6-a12c-b042e7aaef2e"),
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
                            Id = new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"),
                            NodeName = "Stockholm Office"
                        },
                        new
                        {
                            Id = new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"),
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
                            Id = new Guid("e4f4e5fd-5b72-4482-ac30-0efdfc1b26a8"),
                            Name = "Service"
                        },
                        new
                        {
                            Id = new Guid("b22bb19c-5c78-49ca-bb1a-4f774385d7dc"),
                            Name = "Event"
                        },
                        new
                        {
                            Id = new Guid("5fe4e241-4d85-4ea0-a7ab-fab7395e51af"),
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
                            Id = new Guid("7d5fc47a-3ff0-4021-ac28-f4177c0d7b74"),
                            CheckInSign = "JD123",
                            CheckInTime = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JD456",
                            CheckOutTime = new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"),
                            VisitorAccountId = new Guid("3a793485-637f-4db8-9f66-a3aa1f547258")
                        },
                        new
                        {
                            Id = new Guid("157f2ea0-1a32-44fc-b311-a5074b463ad6"),
                            CheckInSign = "JS321",
                            CheckInTime = new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                            CheckOutSign = "JS654",
                            CheckOutTime = new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                            LastExportDate = new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"),
                            VisitorAccountId = new Guid("b03cd088-1ad0-461f-9950-0173e64c6899")
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
                            Id = new Guid("af67b649-669a-40f7-8b07-e7eb124d2b5c"),
                            City = "Stockholm",
                            Company = "TechCorp",
                            CountryId = new Guid("a398fad4-b3c1-4b6c-b096-936bcd49d775"),
                            FullName = "John Doe",
                            PassportNo = "A1234567",
                            SSN = "123-45-6789"
                        },
                        new
                        {
                            Id = new Guid("b4598202-d400-49bc-897b-f89ab8e7c0fd"),
                            City = "Oslo",
                            Company = "InnovateInc",
                            CountryId = new Guid("77438c0f-9862-4ae6-a12c-b042e7aaef2e"),
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
                            Id = new Guid("3a793485-637f-4db8-9f66-a3aa1f547258"),
                            AccountTypeId = new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("e4f4e5fd-5b72-4482-ac30-0efdfc1b26a8"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "john.doe",
                            VisitorId = new Guid("af67b649-669a-40f7-8b07-e7eb124d2b5c")
                        },
                        new
                        {
                            Id = new Guid("b03cd088-1ad0-461f-9950-0173e64c6899"),
                            AccountTypeId = new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("b22bb19c-5c78-49ca-bb1a-4f774385d7dc"),
                            StartDate = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                            Username = "jane.smith",
                            VisitorId = new Guid("b4598202-d400-49bc-897b-f89ab8e7c0fd")
                        },
                        new
                        {
                            Id = new Guid("93ba0ecc-d49a-4b9c-81d3-55b89d016d99"),
                            AccountTypeId = new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"),
                            EndDate = new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                            NodeId = new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"),
                            Password = "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                            PurposeTypeId = new Guid("e4f4e5fd-5b72-4482-ac30-0efdfc1b26a8"),
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
