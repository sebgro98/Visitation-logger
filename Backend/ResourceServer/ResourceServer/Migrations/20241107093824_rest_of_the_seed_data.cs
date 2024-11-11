using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class rest_of_the_seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admin_types",
                keyColumn: "id",
                keyValue: new Guid("5522bc1c-43a3-4850-9a04-385dc2aa29cc"));

            migrationBuilder.DeleteData(
                table: "admin_types",
                keyColumn: "id",
                keyValue: new Guid("80565433-d4ee-4773-ac23-b484b4b7f36f"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("0d5abe13-4b5f-4fd6-ad74-a2cf129a94cf"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("59d1bf88-b964-4076-8818-5b7d52a0440a"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("d24e2c90-7132-465c-83c0-f1eea38fc0fa"));

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("3ffb0d03-f337-4863-8795-f83a38c487f7"), "Norway" },
                    { new Guid("8d03334e-b319-49d1-9634-886857ceacbb"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "admin_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("c06f39a7-1d51-4a4e-adb7-bb3d8aa2d5c5"), "MasterAdmin" },
                    { new Guid("c71b4fa4-0a43-45c2-bd7d-70ccbb546faf"), "LoggAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("1dd3fc45-fbbd-44b8-9c3b-d95145f50cac"), "Main Gate" },
                    { new Guid("ef33a5c3-3fc5-41fe-bc81-cb58186340dd"), "Lobby Entrance" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("9dcafe35-9a40-4b85-a9ba-251aa0bba98d"), "Meeting" },
                    { new Guid("bc586354-b7b0-4277-bcfd-24596c0f7c79"), "Service" },
                    { new Guid("c1fbf656-acb9-462a-9907-baee396e51ce"), "Event" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "admin_type_id", "fullname", "password" },
                values: new object[,]
                {
                    { new Guid("175f6613-80bf-4c5f-a159-5fd7d60dd952"), new Guid("c71b4fa4-0a43-45c2-bd7d-70ccbb546faf"), "Logging-Admin", "Password321!" },
                    { new Guid("9e881241-24f0-44f5-ae1b-6f4cf7f9b6ef"), new Guid("c06f39a7-1d51-4a4e-adb7-bb3d8aa2d5c5"), "Master-Admin", "Password123!" }
                });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("3317fcad-0aef-41af-bff3-3d60e3b7fbe7"), "Oslo", "InnovateInc", new Guid("3ffb0d03-f337-4863-8795-f83a38c487f7"), "Jane Smith", "B7654321", "987-65-4321" },
                    { new Guid("e63d3529-716f-4688-8c9d-6b12d25f56e8"), "Stockholm", "TechCorp", new Guid("8d03334e-b319-49d1-9634-886857ceacbb"), "John Doe", "A1234567", "123-45-6789" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "NodeId", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("20dc902a-2d2e-472d-946c-f3f96dce41fa"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("ef33a5c3-3fc5-41fe-bc81-cb58186340dd"), new Guid("3317fcad-0aef-41af-bff3-3d60e3b7fbe7") },
                    { new Guid("31b0e1d8-5be4-4549-ac84-f536437bd51a"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("1dd3fc45-fbbd-44b8-9c3b-d95145f50cac"), new Guid("e63d3529-716f-4688-8c9d-6b12d25f56e8") }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "end_date", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("861efe29-4f8a-4d51-b99b-d99d7f87fecd"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass1", new Guid("bc586354-b7b0-4277-bcfd-24596c0f7c79"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("e63d3529-716f-4688-8c9d-6b12d25f56e8") },
                    { new Guid("df41d94e-ce75-408a-9933-d4570a8c13c5"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass2", new Guid("c1fbf656-acb9-462a-9907-baee396e51ce"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("3317fcad-0aef-41af-bff3-3d60e3b7fbe7") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("175f6613-80bf-4c5f-a159-5fd7d60dd952"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("9e881241-24f0-44f5-ae1b-6f4cf7f9b6ef"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("9dcafe35-9a40-4b85-a9ba-251aa0bba98d"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("20dc902a-2d2e-472d-946c-f3f96dce41fa"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("31b0e1d8-5be4-4549-ac84-f536437bd51a"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("861efe29-4f8a-4d51-b99b-d99d7f87fecd"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("df41d94e-ce75-408a-9933-d4570a8c13c5"));

            migrationBuilder.DeleteData(
                table: "admin_types",
                keyColumn: "id",
                keyValue: new Guid("c06f39a7-1d51-4a4e-adb7-bb3d8aa2d5c5"));

            migrationBuilder.DeleteData(
                table: "admin_types",
                keyColumn: "id",
                keyValue: new Guid("c71b4fa4-0a43-45c2-bd7d-70ccbb546faf"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("1dd3fc45-fbbd-44b8-9c3b-d95145f50cac"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("ef33a5c3-3fc5-41fe-bc81-cb58186340dd"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("bc586354-b7b0-4277-bcfd-24596c0f7c79"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("c1fbf656-acb9-462a-9907-baee396e51ce"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("3317fcad-0aef-41af-bff3-3d60e3b7fbe7"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("e63d3529-716f-4688-8c9d-6b12d25f56e8"));

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "id",
                keyValue: new Guid("3ffb0d03-f337-4863-8795-f83a38c487f7"));

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "id",
                keyValue: new Guid("8d03334e-b319-49d1-9634-886857ceacbb"));

            migrationBuilder.InsertData(
                table: "admin_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("5522bc1c-43a3-4850-9a04-385dc2aa29cc"), "LoggAdmin" },
                    { new Guid("80565433-d4ee-4773-ac23-b484b4b7f36f"), "MasterAdmin" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0d5abe13-4b5f-4fd6-ad74-a2cf129a94cf"), "Service" },
                    { new Guid("59d1bf88-b964-4076-8818-5b7d52a0440a"), "Meeting" },
                    { new Guid("d24e2c90-7132-465c-83c0-f1eea38fc0fa"), "Event" }
                });
        }
    }
}
