using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class MakeCheckOutTimeNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("5f2de9fe-96d6-4fcc-94ea-cc61a23e95f4"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("a1990d8a-edc3-43bd-93d9-b927acb3ce61"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("b2f41591-cf26-4531-ab41-062441156a34"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("2528cb14-9998-465c-a77a-df388986fc00"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("873e8a5c-dda4-4884-b1cd-6dc44f7a664e"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("076e538a-e0d1-4f90-b9f5-246afca9ac16"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("3f442613-8804-414e-8517-f36c22a90a84"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("73efd26a-3ef3-4a51-b917-a6696635466a"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("36a817d3-4445-4779-a60b-23dc36d72cbf"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("3a868a47-34fd-41e9-9e4e-1280007e933b"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("140c797b-330e-4882-8f93-98765bc01caa"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("561007e8-0075-475e-9ffa-86de967d2568"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("a98dc435-e2ce-4470-be62-bf58f677aec7"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("ab3e25bf-7fec-41af-bc14-eaed5a93f652"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("a02cecf6-0749-48ba-bccd-f5871df211ab"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("ca1f1a3e-b406-4702-aae8-661c00123b40"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("3732d939-b4bd-4aa5-9d1e-cf8bb3711abd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("7db8e65e-092d-45f3-bf5b-0bb21621047e"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_export_date",
                table: "status",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "check_out_time",
                table: "status",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "check_out_sign",
                table: "status",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("1aa7387b-0e3c-45b0-b63a-aa7d2b5e642f"), "Norway" },
                    { new Guid("8ecbc659-71d3-4302-b6a5-3a57d5ab11d7"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("6f203847-e655-472d-9acc-37a131e6bf04"), "LoggAdmin" },
                    { new Guid("c6a5ddbe-f090-45e6-952d-b3e5249a9da6"), "MasterAdmin" },
                    { new Guid("ced65640-1a46-4293-a9e3-32d2ef092616"), "Visitor" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("a8030597-5ac2-4578-b1c1-ccec8696fe67"), "Lobby Entrance" },
                    { new Guid("e4936fba-2e11-4f95-830f-8c2621c0c13c"), "Main Gate" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("69c262b6-17e9-4a01-9957-4bfefc286120"), "Meeting" },
                    { new Guid("c85a2ecf-8f65-4d4c-9982-2f50810136de"), "Service" },
                    { new Guid("e01d4a1b-3d0a-4e15-bcb9-84c6966e8701"), "Event" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("ab9e89a3-d809-497a-8d13-9b60355a1bfc"), new Guid("6f203847-e655-472d-9acc-37a131e6bf04"), "Password321!", "Logging-Admin" },
                    { new Guid("dedb3ee1-1a1e-4088-bd15-bb6d28216daf"), new Guid("c6a5ddbe-f090-45e6-952d-b3e5249a9da6"), "Password123!", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("30e75148-1b96-4c45-af47-ef66cb77f484"), new Guid("ced65640-1a46-4293-a9e3-32d2ef092616"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass1!", new Guid("c85a2ecf-8f65-4d4c-9982-2f50810136de"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("79e93708-7fde-46ab-a92f-a45a83e3dedb"), "Stockholm", "TechCorp", new Guid("8ecbc659-71d3-4302-b6a5-3a57d5ab11d7"), "John Doe", "A1234567", "123-45-6789" },
                    { new Guid("ae7cc5e5-4c8f-4a81-9686-0dac0eabd206"), "Oslo", "InnovateInc", new Guid("1aa7387b-0e3c-45b0-b63a-aa7d2b5e642f"), "Jane Smith", "B7654321", "987-65-4321" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "NodeId", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("1e519282-68fd-48b1-87ed-5fe1eccba075"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("e4936fba-2e11-4f95-830f-8c2621c0c13c"), new Guid("79e93708-7fde-46ab-a92f-a45a83e3dedb") },
                    { new Guid("549d016a-5106-4b12-8f26-0e1e9aeb30e4"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a8030597-5ac2-4578-b1c1-ccec8696fe67"), new Guid("ae7cc5e5-4c8f-4a81-9686-0dac0eabd206") }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("0f2aa218-da57-4719-aed2-9b73f0c8c9bf"), new Guid("ced65640-1a46-4293-a9e3-32d2ef092616"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass2!", new Guid("e01d4a1b-3d0a-4e15-bcb9-84c6966e8701"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("ae7cc5e5-4c8f-4a81-9686-0dac0eabd206") },
                    { new Guid("693055b0-e76a-4962-9e94-fc8e9d5ca89a"), new Guid("ced65640-1a46-4293-a9e3-32d2ef092616"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass1!", new Guid("c85a2ecf-8f65-4d4c-9982-2f50810136de"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("79e93708-7fde-46ab-a92f-a45a83e3dedb") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("ab9e89a3-d809-497a-8d13-9b60355a1bfc"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("dedb3ee1-1a1e-4088-bd15-bb6d28216daf"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("69c262b6-17e9-4a01-9957-4bfefc286120"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("1e519282-68fd-48b1-87ed-5fe1eccba075"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("549d016a-5106-4b12-8f26-0e1e9aeb30e4"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("0f2aa218-da57-4719-aed2-9b73f0c8c9bf"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("30e75148-1b96-4c45-af47-ef66cb77f484"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("693055b0-e76a-4962-9e94-fc8e9d5ca89a"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("6f203847-e655-472d-9acc-37a131e6bf04"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("c6a5ddbe-f090-45e6-952d-b3e5249a9da6"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("ced65640-1a46-4293-a9e3-32d2ef092616"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("a8030597-5ac2-4578-b1c1-ccec8696fe67"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("e4936fba-2e11-4f95-830f-8c2621c0c13c"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("c85a2ecf-8f65-4d4c-9982-2f50810136de"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("e01d4a1b-3d0a-4e15-bcb9-84c6966e8701"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("79e93708-7fde-46ab-a92f-a45a83e3dedb"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("ae7cc5e5-4c8f-4a81-9686-0dac0eabd206"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("1aa7387b-0e3c-45b0-b63a-aa7d2b5e642f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("8ecbc659-71d3-4302-b6a5-3a57d5ab11d7"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "last_export_date",
                table: "status",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "check_out_time",
                table: "status",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "check_out_sign",
                table: "status",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("3732d939-b4bd-4aa5-9d1e-cf8bb3711abd"), "Sweden" },
                    { new Guid("7db8e65e-092d-45f3-bf5b-0bb21621047e"), "Norway" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"), "Visitor" },
                    { new Guid("36a817d3-4445-4779-a60b-23dc36d72cbf"), "LoggAdmin" },
                    { new Guid("3a868a47-34fd-41e9-9e4e-1280007e933b"), "MasterAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("140c797b-330e-4882-8f93-98765bc01caa"), "Main Gate" },
                    { new Guid("561007e8-0075-475e-9ffa-86de967d2568"), "Lobby Entrance" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("a98dc435-e2ce-4470-be62-bf58f677aec7"), "Service" },
                    { new Guid("ab3e25bf-7fec-41af-bc14-eaed5a93f652"), "Event" },
                    { new Guid("b2f41591-cf26-4531-ab41-062441156a34"), "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("5f2de9fe-96d6-4fcc-94ea-cc61a23e95f4"), new Guid("36a817d3-4445-4779-a60b-23dc36d72cbf"), "Password321!", "Logging-Admin" },
                    { new Guid("a1990d8a-edc3-43bd-93d9-b927acb3ce61"), new Guid("3a868a47-34fd-41e9-9e4e-1280007e933b"), "Password123!", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("73efd26a-3ef3-4a51-b917-a6696635466a"), new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass1!", new Guid("a98dc435-e2ce-4470-be62-bf58f677aec7"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("a02cecf6-0749-48ba-bccd-f5871df211ab"), "Oslo", "InnovateInc", new Guid("7db8e65e-092d-45f3-bf5b-0bb21621047e"), "Jane Smith", "B7654321", "987-65-4321" },
                    { new Guid("ca1f1a3e-b406-4702-aae8-661c00123b40"), "Stockholm", "TechCorp", new Guid("3732d939-b4bd-4aa5-9d1e-cf8bb3711abd"), "John Doe", "A1234567", "123-45-6789" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "NodeId", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("2528cb14-9998-465c-a77a-df388986fc00"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("561007e8-0075-475e-9ffa-86de967d2568"), new Guid("a02cecf6-0749-48ba-bccd-f5871df211ab") },
                    { new Guid("873e8a5c-dda4-4884-b1cd-6dc44f7a664e"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("140c797b-330e-4882-8f93-98765bc01caa"), new Guid("ca1f1a3e-b406-4702-aae8-661c00123b40") }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("076e538a-e0d1-4f90-b9f5-246afca9ac16"), new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass1!", new Guid("a98dc435-e2ce-4470-be62-bf58f677aec7"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("ca1f1a3e-b406-4702-aae8-661c00123b40") },
                    { new Guid("3f442613-8804-414e-8517-f36c22a90a84"), new Guid("28633ad3-cce7-4cd5-85dd-5b27d93a60c9"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), "securePass2!", new Guid("ab3e25bf-7fec-41af-bc14-eaed5a93f652"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("a02cecf6-0749-48ba-bccd-f5871df211ab") }
                });
        }
    }
}
