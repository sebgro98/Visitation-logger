using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_nodes_Node_Id",
                table: "admins");

            migrationBuilder.DropForeignKey(
                name: "FK_status_nodes_NodeId",
                table: "status");

            migrationBuilder.DropForeignKey(
                name: "FK_visitorAccounts_nodes_Node_id",
                table: "visitorAccounts");

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

            migrationBuilder.RenameColumn(
                name: "Node_id",
                table: "visitorAccounts",
                newName: "node_id");

            migrationBuilder.RenameIndex(
                name: "IX_visitorAccounts_Node_id",
                table: "visitorAccounts",
                newName: "IX_visitorAccounts_node_id");

            migrationBuilder.RenameColumn(
                name: "NodeId",
                table: "status",
                newName: "node_id");

            migrationBuilder.RenameIndex(
                name: "IX_status_NodeId",
                table: "status",
                newName: "IX_status_node_id");

            migrationBuilder.RenameColumn(
                name: "Node_Id",
                table: "admins",
                newName: "node_Id");

            migrationBuilder.RenameIndex(
                name: "IX_admins_Node_Id",
                table: "admins",
                newName: "IX_admins_node_Id");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("5cfcc3f6-dfab-462b-b826-da28625582ba"), "Norway" },
                    { new Guid("65ac3add-ccef-43a3-b39e-0bfcea262c25"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("16f8c55f-1d2c-4d4f-93e2-2ae3047a5bb6"), "MasterAdmin" },
                    { new Guid("a2f5ef84-10f0-4e05-a3a3-fcbe73728d16"), "Visitor" },
                    { new Guid("bac9986d-c95f-4f6c-a0c2-16801f4d08a4"), "LoggAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("bd22cb11-ff86-4295-ac73-a9c79516087b"), "Oslo Office" },
                    { new Guid("d1653396-d2d5-4668-806d-808a144cdc0a"), "Stockholm Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("7a4623d1-33e2-48e9-88a0-934b8374bdf0"), "Service" },
                    { new Guid("edb56ab7-8a8c-4ba3-af01-8671a8648833"), "Event" },
                    { new Guid("fae3dd00-7ce4-4677-9421-6a570f9ce8f8"), "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("46f9a5c1-6c94-4943-93d3-0a56bb39a21b"), new Guid("bac9986d-c95f-4f6c-a0c2-16801f4d08a4"), new Guid("bd22cb11-ff86-4295-ac73-a9c79516087b"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" },
                    { new Guid("8ab1f39f-5195-4039-ac27-ac4b4e55901e"), new Guid("16f8c55f-1d2c-4d4f-93e2-2ae3047a5bb6"), new Guid("d1653396-d2d5-4668-806d-808a144cdc0a"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("9ad08aeb-e3b4-429d-918e-127d2d07eb93"), new Guid("a2f5ef84-10f0-4e05-a3a3-fcbe73728d16"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d1653396-d2d5-4668-806d-808a144cdc0a"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("7a4623d1-33e2-48e9-88a0-934b8374bdf0"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("6de88bd3-40a5-4153-bbd8-83e54a51d7f6"), "Oslo", "InnovateInc", new Guid("5cfcc3f6-dfab-462b-b826-da28625582ba"), "Jane Smith", "B7654321", "987-65-4321" },
                    { new Guid("c6fa3652-64b0-49d7-9e09-a6e93311d545"), "Stockholm", "TechCorp", new Guid("65ac3add-ccef-43a3-b39e-0bfcea262c25"), "John Doe", "A1234567", "123-45-6789" }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("2f70654a-3232-4064-9c71-165d43f6ecbb"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d1653396-d2d5-4668-806d-808a144cdc0a"), new Guid("c6fa3652-64b0-49d7-9e09-a6e93311d545") },
                    { new Guid("734d8274-1882-41df-bdf5-c450085b2fb3"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("bd22cb11-ff86-4295-ac73-a9c79516087b"), new Guid("6de88bd3-40a5-4153-bbd8-83e54a51d7f6") }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("83e17be8-e515-448f-9a0d-0d6e34b2a6bb"), new Guid("a2f5ef84-10f0-4e05-a3a3-fcbe73728d16"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("bd22cb11-ff86-4295-ac73-a9c79516087b"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("edb56ab7-8a8c-4ba3-af01-8671a8648833"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("6de88bd3-40a5-4153-bbd8-83e54a51d7f6") },
                    { new Guid("b9cbaf77-c136-416f-bf8d-31959942d049"), new Guid("a2f5ef84-10f0-4e05-a3a3-fcbe73728d16"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("d1653396-d2d5-4668-806d-808a144cdc0a"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("7a4623d1-33e2-48e9-88a0-934b8374bdf0"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("c6fa3652-64b0-49d7-9e09-a6e93311d545") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_admins_nodes_node_Id",
                table: "admins",
                column: "node_Id",
                principalTable: "nodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_status_nodes_node_id",
                table: "status",
                column: "node_id",
                principalTable: "nodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visitorAccounts_nodes_node_id",
                table: "visitorAccounts",
                column: "node_id",
                principalTable: "nodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_admins_nodes_node_Id",
                table: "admins");

            migrationBuilder.DropForeignKey(
                name: "FK_status_nodes_node_id",
                table: "status");

            migrationBuilder.DropForeignKey(
                name: "FK_visitorAccounts_nodes_node_id",
                table: "visitorAccounts");

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("46f9a5c1-6c94-4943-93d3-0a56bb39a21b"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("8ab1f39f-5195-4039-ac27-ac4b4e55901e"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("fae3dd00-7ce4-4677-9421-6a570f9ce8f8"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("2f70654a-3232-4064-9c71-165d43f6ecbb"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("734d8274-1882-41df-bdf5-c450085b2fb3"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("83e17be8-e515-448f-9a0d-0d6e34b2a6bb"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("9ad08aeb-e3b4-429d-918e-127d2d07eb93"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("b9cbaf77-c136-416f-bf8d-31959942d049"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("16f8c55f-1d2c-4d4f-93e2-2ae3047a5bb6"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("a2f5ef84-10f0-4e05-a3a3-fcbe73728d16"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("bac9986d-c95f-4f6c-a0c2-16801f4d08a4"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("bd22cb11-ff86-4295-ac73-a9c79516087b"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("d1653396-d2d5-4668-806d-808a144cdc0a"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("7a4623d1-33e2-48e9-88a0-934b8374bdf0"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("edb56ab7-8a8c-4ba3-af01-8671a8648833"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("6de88bd3-40a5-4153-bbd8-83e54a51d7f6"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("c6fa3652-64b0-49d7-9e09-a6e93311d545"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("5cfcc3f6-dfab-462b-b826-da28625582ba"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("65ac3add-ccef-43a3-b39e-0bfcea262c25"));

            migrationBuilder.RenameColumn(
                name: "node_id",
                table: "visitorAccounts",
                newName: "Node_id");

            migrationBuilder.RenameIndex(
                name: "IX_visitorAccounts_node_id",
                table: "visitorAccounts",
                newName: "IX_visitorAccounts_Node_id");

            migrationBuilder.RenameColumn(
                name: "node_id",
                table: "status",
                newName: "NodeId");

            migrationBuilder.RenameIndex(
                name: "IX_status_node_id",
                table: "status",
                newName: "IX_status_NodeId");

            migrationBuilder.RenameColumn(
                name: "node_Id",
                table: "admins",
                newName: "Node_Id");

            migrationBuilder.RenameIndex(
                name: "IX_admins_node_Id",
                table: "admins",
                newName: "IX_admins_Node_Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_admins_nodes_Node_Id",
                table: "admins",
                column: "Node_Id",
                principalTable: "nodes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_status_nodes_NodeId",
                table: "status",
                column: "NodeId",
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
    }
}
