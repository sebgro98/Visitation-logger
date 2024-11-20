using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStatusModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("2840fdf4-638e-4a6c-a26c-23cada294ce0")
            );

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("543cfe43-ef05-48c2-a097-28b7775b500a")
            );

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("8de6812e-caff-4991-9285-1c665e2b90dd")
            );

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("53e78c27-2525-4dae-ba8c-be5cd619ba16")
            );

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("c52a87c8-083e-4c81-8db4-bb75727c301d")
            );

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("5766c22b-7807-4ee5-a2fb-9638c1c0e449")
            );

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a")
            );

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f")
            );

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9")
            );

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd")
            );

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("7a3d837f-0438-4456-abe7-902a50efe61c")
            );

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b")
            );

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("dc54d56f-5132-4976-aef2-f313acbeca10")
            );

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f")
            );

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377")
            );

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc")
            );

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1")
            );

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e")
            );

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321")
            );

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("3022bb74-2320-4725-8377-28b91a6ee966"), "Sweden" },
                    { new Guid("48045850-7209-420b-96a7-9cb6e702cba8"), "Norway" }
                }
            );

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"), "Visitor" },
                    { new Guid("3c99db9c-b93a-4f0a-b15a-1f015ac1f183"), "LoggAdmin" },
                    { new Guid("f8b17167-e2b4-481b-be1d-71250788628e"), "MasterAdmin" }
                }
            );

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("54478169-4590-4bc8-addf-95cbf00e0480"), "Stockholm Office" },
                    { new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"), "Oslo Office" }
                }
            );

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0855fe54-cb09-49ab-9e33-ddb1cfa44f02"), "Event" },
                    { new Guid("b6d46a8c-c9ec-4fd9-a637-26671eceebfb"), "Meeting" },
                    { new Guid("edf944d6-96e5-487d-8df8-73d2a8346180"), "Service" }
                }
            );

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[]
                {
                    "id",
                    "account_type_id",
                    "FullName",
                    "node_Id",
                    "password",
                    "username"
                },
                values: new object[,]
                {
                    {
                        new Guid("02669e4d-0d83-4929-aaee-ac8032930eef"),
                        new Guid("3c99db9c-b93a-4f0a-b15a-1f015ac1f183"),
                        "Logging Admin",
                        new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        "Logging-Admin"
                    },
                    {
                        new Guid("c5872302-bd38-4227-b9c8-4289c7608c8d"),
                        new Guid("f8b17167-e2b4-481b-be1d-71250788628e"),
                        "Master Admin",
                        new Guid("54478169-4590-4bc8-addf-95cbf00e0480"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        "Master-Admin"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[]
                {
                    "id",
                    "account_type_id",
                    "end_date",
                    "node_id",
                    "password",
                    "purpose_type_id",
                    "start_date",
                    "username",
                    "VisitorId"
                },
                values: new object[]
                {
                    new Guid("6ffa2cc3-de61-431e-b1db-06108bcb027a"),
                    new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"),
                    new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                    new Guid("54478169-4590-4bc8-addf-95cbf00e0480"),
                    "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                    new Guid("edf944d6-96e5-487d-8df8-73d2a8346180"),
                    new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                    "Angel.man",
                    null
                }
            );

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[]
                {
                    "id",
                    "city",
                    "company",
                    "country_id",
                    "fullname",
                    "passport_no",
                    "SSN"
                },
                values: new object[,]
                {
                    {
                        new Guid("0726e10f-1ade-40e1-be90-93c34d8f5a96"),
                        "Stockholm",
                        "TechCorp",
                        new Guid("3022bb74-2320-4725-8377-28b91a6ee966"),
                        "John Doe",
                        "A1234567",
                        "123-45-6789"
                    },
                    {
                        new Guid("5579bfcb-625b-4037-8e15-f1ec2cb9b527"),
                        "Oslo",
                        "InnovateInc",
                        new Guid("48045850-7209-420b-96a7-9cb6e702cba8"),
                        "Jane Smith",
                        "B7654321",
                        "987-65-4321"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[]
                {
                    "id",
                    "account_type_id",
                    "end_date",
                    "node_id",
                    "password",
                    "purpose_type_id",
                    "start_date",
                    "username",
                    "VisitorId"
                },
                values: new object[,]
                {
                    {
                        new Guid("7c1c5cc4-239a-4eed-bc8a-0617136e4289"),
                        new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"),
                        new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        new Guid("0855fe54-cb09-49ab-9e33-ddb1cfa44f02"),
                        new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                        "jane.smith",
                        new Guid("5579bfcb-625b-4037-8e15-f1ec2cb9b527")
                    },
                    {
                        new Guid("a452e126-f495-46ac-8dfb-d50dd4c16b2e"),
                        new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"),
                        new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("54478169-4590-4bc8-addf-95cbf00e0480"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        new Guid("edf944d6-96e5-487d-8df8-73d2a8346180"),
                        new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                        "john.doe",
                        new Guid("0726e10f-1ade-40e1-be90-93c34d8f5a96")
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "status",
                columns: new[]
                {
                    "id",
                    "check_in_sign",
                    "check_in_time",
                    "check_out_sign",
                    "check_out_time",
                    "last_export_date",
                    "node_id",
                    "visitor_account_id"
                },
                values: new object[,]
                {
                    {
                        new Guid("098c2e8d-476d-4d65-ae4f-af6ff88eb3b6"),
                        "JD123",
                        new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                        "JD456",
                        new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                        new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("54478169-4590-4bc8-addf-95cbf00e0480"),
                        new Guid("a452e126-f495-46ac-8dfb-d50dd4c16b2e")
                    },
                    {
                        new Guid("590e8ac7-d79f-43c5-8e43-c4c0de49640b"),
                        "JS321",
                        new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                        "JS654",
                        new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                        new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"),
                        new Guid("7c1c5cc4-239a-4eed-bc8a-0617136e4289")
                    }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("02669e4d-0d83-4929-aaee-ac8032930eef")
            );

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("c5872302-bd38-4227-b9c8-4289c7608c8d")
            );

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("b6d46a8c-c9ec-4fd9-a637-26671eceebfb")
            );

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("098c2e8d-476d-4d65-ae4f-af6ff88eb3b6")
            );

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("590e8ac7-d79f-43c5-8e43-c4c0de49640b")
            );

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("6ffa2cc3-de61-431e-b1db-06108bcb027a")
            );

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("3c99db9c-b93a-4f0a-b15a-1f015ac1f183")
            );

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("f8b17167-e2b4-481b-be1d-71250788628e")
            );

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("7c1c5cc4-239a-4eed-bc8a-0617136e4289")
            );

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("a452e126-f495-46ac-8dfb-d50dd4c16b2e")
            );

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6")
            );

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("54478169-4590-4bc8-addf-95cbf00e0480")
            );

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d")
            );

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("0855fe54-cb09-49ab-9e33-ddb1cfa44f02")
            );

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("edf944d6-96e5-487d-8df8-73d2a8346180")
            );

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("0726e10f-1ade-40e1-be90-93c34d8f5a96")
            );

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("5579bfcb-625b-4037-8e15-f1ec2cb9b527")
            );

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("3022bb74-2320-4725-8377-28b91a6ee966")
            );

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("48045850-7209-420b-96a7-9cb6e702cba8")
            );

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e"), "Norway" },
                    { new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321"), "Sweden" }
                }
            );

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a"), "LoggAdmin" },
                    { new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"), "Visitor" },
                    { new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f"), "MasterAdmin" }
                }
            );

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"), "Oslo Office" },
                    { new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"), "Stockholm Office" }
                }
            );

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"), "Service" },
                    { new Guid("8de6812e-caff-4991-9285-1c665e2b90dd"), "Meeting" },
                    { new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377"), "Event" }
                }
            );

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[]
                {
                    "id",
                    "account_type_id",
                    "FullName",
                    "node_Id",
                    "password",
                    "username"
                },
                values: new object[,]
                {
                    {
                        new Guid("2840fdf4-638e-4a6c-a26c-23cada294ce0"),
                        new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f"),
                        "Master Admin",
                        new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        "Master-Admin"
                    },
                    {
                        new Guid("543cfe43-ef05-48c2-a097-28b7775b500a"),
                        new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a"),
                        "Logging Admin",
                        new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        "Logging-Admin"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[]
                {
                    "id",
                    "account_type_id",
                    "end_date",
                    "node_id",
                    "password",
                    "purpose_type_id",
                    "start_date",
                    "username",
                    "VisitorId"
                },
                values: new object[]
                {
                    new Guid("5766c22b-7807-4ee5-a2fb-9638c1c0e449"),
                    new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"),
                    new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                    new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                    "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                    new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"),
                    new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                    "Angel.man",
                    null
                }
            );

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[]
                {
                    "id",
                    "city",
                    "company",
                    "country_id",
                    "fullname",
                    "passport_no",
                    "SSN"
                },
                values: new object[,]
                {
                    {
                        new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc"),
                        "Stockholm",
                        "TechCorp",
                        new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321"),
                        "John Doe",
                        "A1234567",
                        "123-45-6789"
                    },
                    {
                        new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1"),
                        "Oslo",
                        "InnovateInc",
                        new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e"),
                        "Jane Smith",
                        "B7654321",
                        "987-65-4321"
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[]
                {
                    "id",
                    "account_type_id",
                    "end_date",
                    "node_id",
                    "password",
                    "purpose_type_id",
                    "start_date",
                    "username",
                    "VisitorId"
                },
                values: new object[,]
                {
                    {
                        new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9"),
                        new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"),
                        new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377"),
                        new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                        "jane.smith",
                        new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1")
                    },
                    {
                        new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd"),
                        new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"),
                        new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                        "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013",
                        new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"),
                        new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                        "john.doe",
                        new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc")
                    }
                }
            );

            migrationBuilder.InsertData(
                table: "status",
                columns: new[]
                {
                    "id",
                    "check_in_sign",
                    "check_in_time",
                    "check_out_sign",
                    "check_out_time",
                    "last_export_date",
                    "node_id",
                    "visitor_account_id"
                },
                values: new object[,]
                {
                    {
                        new Guid("53e78c27-2525-4dae-ba8c-be5cd619ba16"),
                        "JS321",
                        new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc),
                        "JS654",
                        new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc),
                        new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"),
                        new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9")
                    },
                    {
                        new Guid("c52a87c8-083e-4c81-8db4-bb75727c301d"),
                        "JD123",
                        new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc),
                        "JD456",
                        new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc),
                        new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc),
                        new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"),
                        new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd")
                    }
                }
            );


            //Added manually to drop the VisitorId
            migrationBuilder.DropForeignKey(
                name: "FK_status_visitor_visitor_id",
                table: "status"
            );

            migrationBuilder.DropColumn(name: "VisitorId", table: "status");
        }
    }
}
