using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class addNodeIdToVisitorAccountandAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "Node_id",
                table: "visitorAccounts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Node_Id",
                table: "admins",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("18d66487-2f9d-4b54-9a05-407fb832d2d7"), "Sweden" },
                    { new Guid("34083064-6a77-4a65-9f98-70c6a5c5fb19"), "Norway" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("40ef53a6-c0ef-42f7-81c6-c3b0b63916d8"), "Visitor" },
                    { new Guid("9824fcfe-c126-432f-9014-eec8e77c055b"), "MasterAdmin" },
                    { new Guid("bcddf013-219d-4441-ae06-75b556c18c9d"), "LoggAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("8ce46f8c-1ee1-4cbe-8c05-56b4cff2ab30"), "Lobby Entrance" },
                    { new Guid("a0ba9661-5079-49a5-b478-3060a384b521"), "Main Gate" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("446f5d56-e6a9-448e-8f55-ecfc21ea32ea"), "Service" },
                    { new Guid("c4a21a09-a6b0-438d-a985-19cde8985ce0"), "Event" },
                    { new Guid("ef5ac975-0f3e-40e2-8aa8-9b67fb2efec7"), "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "Node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("2ba850a9-daa6-4b6c-aa77-0552b5a22d57"), new Guid("9824fcfe-c126-432f-9014-eec8e77c055b"), new Guid("a0ba9661-5079-49a5-b478-3060a384b521"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" },
                    { new Guid("e387be5e-f712-43c9-a0d5-a7e24d3a5e7f"), new Guid("bcddf013-219d-4441-ae06-75b556c18c9d"), new Guid("8ce46f8c-1ee1-4cbe-8c05-56b4cff2ab30"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "Node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("78342c12-5d3d-46be-93c8-c597d867d666"), new Guid("40ef53a6-c0ef-42f7-81c6-c3b0b63916d8"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0ba9661-5079-49a5-b478-3060a384b521"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("446f5d56-e6a9-448e-8f55-ecfc21ea32ea"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("3a549ddb-ddac-4965-b8ae-916c46621ddb"), "Stockholm", "TechCorp", new Guid("18d66487-2f9d-4b54-9a05-407fb832d2d7"), "John Doe", "A1234567", "123-45-6789" },
                    { new Guid("4fdb1b83-f4a4-4a57-b8e6-ee8854a87b7f"), "Oslo", "InnovateInc", new Guid("34083064-6a77-4a65-9f98-70c6a5c5fb19"), "Jane Smith", "B7654321", "987-65-4321" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "NodeId", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("33a22346-515c-4f88-80a0-0bccd4c53807"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0ba9661-5079-49a5-b478-3060a384b521"), new Guid("3a549ddb-ddac-4965-b8ae-916c46621ddb") },
                    { new Guid("5fa0962b-19af-4d24-a29b-75dec17c69cd"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8ce46f8c-1ee1-4cbe-8c05-56b4cff2ab30"), new Guid("4fdb1b83-f4a4-4a57-b8e6-ee8854a87b7f") }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "Node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("0d21e05f-43fb-49a1-9cbc-a9a19ebb6a5c"), new Guid("40ef53a6-c0ef-42f7-81c6-c3b0b63916d8"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("8ce46f8c-1ee1-4cbe-8c05-56b4cff2ab30"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("c4a21a09-a6b0-438d-a985-19cde8985ce0"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("4fdb1b83-f4a4-4a57-b8e6-ee8854a87b7f") },
                    { new Guid("85cabd85-9c3f-432f-a7f2-39e89301ed77"), new Guid("40ef53a6-c0ef-42f7-81c6-c3b0b63916d8"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("a0ba9661-5079-49a5-b478-3060a384b521"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("446f5d56-e6a9-448e-8f55-ecfc21ea32ea"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("3a549ddb-ddac-4965-b8ae-916c46621ddb") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_visitorAccounts_Node_id",
                table: "visitorAccounts",
                column: "Node_id");

            migrationBuilder.CreateIndex(
                name: "IX_admins_Node_Id",
                table: "admins",
                column: "Node_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_admins_nodes_Node_Id",
                table: "admins",
                column: "Node_Id",
                principalTable: "nodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visitorAccounts_nodes_Node_id",
                table: "visitorAccounts",
                column: "Node_id",
                principalTable: "nodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_nodes_Node_Id",
                table: "admins");

            migrationBuilder.DropForeignKey(
                name: "FK_visitorAccounts_nodes_Node_id",
                table: "visitorAccounts");

            migrationBuilder.DropIndex(
                name: "IX_visitorAccounts_Node_id",
                table: "visitorAccounts");

            migrationBuilder.DropIndex(
                name: "IX_admins_Node_Id",
                table: "admins");

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("2ba850a9-daa6-4b6c-aa77-0552b5a22d57"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("e387be5e-f712-43c9-a0d5-a7e24d3a5e7f"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("ef5ac975-0f3e-40e2-8aa8-9b67fb2efec7"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("33a22346-515c-4f88-80a0-0bccd4c53807"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("5fa0962b-19af-4d24-a29b-75dec17c69cd"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("0d21e05f-43fb-49a1-9cbc-a9a19ebb6a5c"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("78342c12-5d3d-46be-93c8-c597d867d666"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("85cabd85-9c3f-432f-a7f2-39e89301ed77"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("40ef53a6-c0ef-42f7-81c6-c3b0b63916d8"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("9824fcfe-c126-432f-9014-eec8e77c055b"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("bcddf013-219d-4441-ae06-75b556c18c9d"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("8ce46f8c-1ee1-4cbe-8c05-56b4cff2ab30"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("a0ba9661-5079-49a5-b478-3060a384b521"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("446f5d56-e6a9-448e-8f55-ecfc21ea32ea"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("c4a21a09-a6b0-438d-a985-19cde8985ce0"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("3a549ddb-ddac-4965-b8ae-916c46621ddb"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("4fdb1b83-f4a4-4a57-b8e6-ee8854a87b7f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("18d66487-2f9d-4b54-9a05-407fb832d2d7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("34083064-6a77-4a65-9f98-70c6a5c5fb19"));

            migrationBuilder.DropColumn(
                name: "Node_id",
                table: "visitorAccounts");

            migrationBuilder.DropColumn(
                name: "Node_Id",
                table: "admins");

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
    }
}
