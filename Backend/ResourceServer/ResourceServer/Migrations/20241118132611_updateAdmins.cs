using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class updateAdmins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("2a04dde4-59a4-48fc-ad92-6ef67da5a707"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("df292dc5-80e7-47d3-8085-28d3edff833b"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("26d51fa9-fb51-40ad-af11-cb364763cf40"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("20e81c0f-1aed-4acd-81b4-51e57b8a207f"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("9bdd4e54-c3c0-472b-b534-4b9425c2e66c"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("2402460b-51dd-4949-9b69-2138c3d77a96"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("a0b813ae-52d3-4586-ad73-86abaf0a2640"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("bba51f98-3a64-41c6-ad4d-9d1826f0ec50"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("b3761d34-0069-461c-9122-7e2ea8729f6b"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("ea1035f4-8391-433a-b35b-107674218234"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("faa6e3ed-0eef-4a32-b1ec-edfcfa08d172"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("0b7b2113-7681-4dc1-b485-f08d0b46adda"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("51905299-a0a4-4837-a0bb-496cfebd2106"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("d69f3e72-21d8-4aec-9cec-fdf74d30b19d"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("e2db4df7-7a91-47dd-84bb-ab2383b4f9f2"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("bc16967d-ddf6-47fa-a61b-1a818f1fabb9"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("bf9cc4e7-149c-4b01-9ed7-e5ec38ede3c7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("0e36492f-a97b-4fb0-91fd-a5aac404da36"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("d4db364c-2ab2-4fc4-882e-153322d8ba6b"));

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "admins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("c3c890f7-8f57-4e90-9b12-f99b928a20e6"), "Norway" },
                    { new Guid("fb319aab-4467-46f0-8ae8-2087e333af97"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("2a610367-d627-4e5e-9c3e-89977d531090"), "MasterAdmin" },
                    { new Guid("6f0dd1d5-ca3c-450f-9e04-8338f1d0f308"), "LoggAdmin" },
                    { new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"), "Visitor" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"), "Stockholm Office" },
                    { new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"), "Oslo Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1d903e81-57ea-407a-8397-ef5f9b9155b2"), "Service" },
                    { new Guid("239cdf95-bf3f-47fe-afb7-2eedcb77379d"), "Meeting" },
                    { new Guid("26b7a9dc-6ffb-4140-927c-d0f40d49c922"), "Event" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "FullName", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("8665bd5d-ee97-4ffd-a1cb-020abc34f9de"), new Guid("2a610367-d627-4e5e-9c3e-89977d531090"), "Master Admin", new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" },
                    { new Guid("e6c565c9-8cfb-4df8-8cfd-32690861f6da"), new Guid("6f0dd1d5-ca3c-450f-9e04-8338f1d0f308"), "Logging Admin", new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("b948f141-c4a9-4bea-a30c-115b2abcf0b7"), new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("1d903e81-57ea-407a-8397-ef5f9b9155b2"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("2f7aaf4f-86b4-4523-af41-5a18317f1d33"), "Oslo", "InnovateInc", new Guid("c3c890f7-8f57-4e90-9b12-f99b928a20e6"), "Jane Smith", "B7654321", "987-65-4321" },
                    { new Guid("d54c6c5c-87d1-4479-8e9f-76cb97d465e7"), "Stockholm", "TechCorp", new Guid("fb319aab-4467-46f0-8ae8-2087e333af97"), "John Doe", "A1234567", "123-45-6789" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("959738a7-3581-497c-9465-96db93b0bd87"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"), new Guid("d54c6c5c-87d1-4479-8e9f-76cb97d465e7") },
                    { new Guid("b112294c-2521-4755-adeb-29c9a1054ee1"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"), new Guid("2f7aaf4f-86b4-4523-af41-5a18317f1d33") }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("62c92b11-1c55-4414-bf97-1fc3f3b2cb16"), new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("1d903e81-57ea-407a-8397-ef5f9b9155b2"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("d54c6c5c-87d1-4479-8e9f-76cb97d465e7") },
                    { new Guid("82c29b80-7d7e-4df8-851b-c143eeea3bff"), new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("26b7a9dc-6ffb-4140-927c-d0f40d49c922"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("2f7aaf4f-86b4-4523-af41-5a18317f1d33") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("8665bd5d-ee97-4ffd-a1cb-020abc34f9de"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("e6c565c9-8cfb-4df8-8cfd-32690861f6da"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("239cdf95-bf3f-47fe-afb7-2eedcb77379d"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("959738a7-3581-497c-9465-96db93b0bd87"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("b112294c-2521-4755-adeb-29c9a1054ee1"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("62c92b11-1c55-4414-bf97-1fc3f3b2cb16"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("82c29b80-7d7e-4df8-851b-c143eeea3bff"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("b948f141-c4a9-4bea-a30c-115b2abcf0b7"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("2a610367-d627-4e5e-9c3e-89977d531090"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("6f0dd1d5-ca3c-450f-9e04-8338f1d0f308"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("f3436c04-fb41-4b33-bf8c-eb639a403a51"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("3be15a03-7bee-4a00-92ab-19a8af2c14e9"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("d65f6b94-3b13-4bf8-9f30-453e718d9eca"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("1d903e81-57ea-407a-8397-ef5f9b9155b2"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("26b7a9dc-6ffb-4140-927c-d0f40d49c922"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("2f7aaf4f-86b4-4523-af41-5a18317f1d33"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("d54c6c5c-87d1-4479-8e9f-76cb97d465e7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("c3c890f7-8f57-4e90-9b12-f99b928a20e6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("fb319aab-4467-46f0-8ae8-2087e333af97"));

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "admins");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("0e36492f-a97b-4fb0-91fd-a5aac404da36"), "Sweden" },
                    { new Guid("d4db364c-2ab2-4fc4-882e-153322d8ba6b"), "Norway" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("b3761d34-0069-461c-9122-7e2ea8729f6b"), "LoggAdmin" },
                    { new Guid("ea1035f4-8391-433a-b35b-107674218234"), "MasterAdmin" },
                    { new Guid("faa6e3ed-0eef-4a32-b1ec-edfcfa08d172"), "Visitor" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("0b7b2113-7681-4dc1-b485-f08d0b46adda"), "Stockholm Office" },
                    { new Guid("51905299-a0a4-4837-a0bb-496cfebd2106"), "Oslo Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("26d51fa9-fb51-40ad-af11-cb364763cf40"), "Meeting" },
                    { new Guid("d69f3e72-21d8-4aec-9cec-fdf74d30b19d"), "Service" },
                    { new Guid("e2db4df7-7a91-47dd-84bb-ab2383b4f9f2"), "Event" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("2a04dde4-59a4-48fc-ad92-6ef67da5a707"), new Guid("b3761d34-0069-461c-9122-7e2ea8729f6b"), new Guid("51905299-a0a4-4837-a0bb-496cfebd2106"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" },
                    { new Guid("df292dc5-80e7-47d3-8085-28d3edff833b"), new Guid("ea1035f4-8391-433a-b35b-107674218234"), new Guid("0b7b2113-7681-4dc1-b485-f08d0b46adda"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("a0b813ae-52d3-4586-ad73-86abaf0a2640"), new Guid("faa6e3ed-0eef-4a32-b1ec-edfcfa08d172"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0b7b2113-7681-4dc1-b485-f08d0b46adda"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("d69f3e72-21d8-4aec-9cec-fdf74d30b19d"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("bc16967d-ddf6-47fa-a61b-1a818f1fabb9"), "Stockholm", "TechCorp", new Guid("0e36492f-a97b-4fb0-91fd-a5aac404da36"), "John Doe", "A1234567", "123-45-6789" },
                    { new Guid("bf9cc4e7-149c-4b01-9ed7-e5ec38ede3c7"), "Oslo", "InnovateInc", new Guid("d4db364c-2ab2-4fc4-882e-153322d8ba6b"), "Jane Smith", "B7654321", "987-65-4321" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("20e81c0f-1aed-4acd-81b4-51e57b8a207f"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0b7b2113-7681-4dc1-b485-f08d0b46adda"), new Guid("bc16967d-ddf6-47fa-a61b-1a818f1fabb9") },
                    { new Guid("9bdd4e54-c3c0-472b-b534-4b9425c2e66c"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("51905299-a0a4-4837-a0bb-496cfebd2106"), new Guid("bf9cc4e7-149c-4b01-9ed7-e5ec38ede3c7") }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("2402460b-51dd-4949-9b69-2138c3d77a96"), new Guid("faa6e3ed-0eef-4a32-b1ec-edfcfa08d172"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0b7b2113-7681-4dc1-b485-f08d0b46adda"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("d69f3e72-21d8-4aec-9cec-fdf74d30b19d"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("bc16967d-ddf6-47fa-a61b-1a818f1fabb9") },
                    { new Guid("bba51f98-3a64-41c6-ad4d-9d1826f0ec50"), new Guid("faa6e3ed-0eef-4a32-b1ec-edfcfa08d172"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("51905299-a0a4-4837-a0bb-496cfebd2106"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("e2db4df7-7a91-47dd-84bb-ab2383b4f9f2"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("bf9cc4e7-149c-4b01-9ed7-e5ec38ede3c7") }
                });
        }
    }
}
