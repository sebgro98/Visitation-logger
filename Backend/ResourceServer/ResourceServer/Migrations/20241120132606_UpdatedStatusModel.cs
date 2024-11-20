using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStatusModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_status_visitors_visitor_id",
                table: "status");

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

            migrationBuilder.RenameColumn(
                name: "visitor_id",
                table: "status",
                newName: "VisitorId");

            migrationBuilder.RenameIndex(
                name: "IX_status_visitor_id",
                table: "status",
                newName: "IX_status_VisitorId");

            migrationBuilder.AlterColumn<Guid>(
                name: "VisitorId",
                table: "status",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "visitor_account_id",
                table: "status",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e"), "Norway" },
                    { new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a"), "LoggAdmin" },
                    { new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"), "Visitor" },
                    { new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f"), "MasterAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"), "Oslo Office" },
                    { new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"), "Stockholm Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"), "Service" },
                    { new Guid("8de6812e-caff-4991-9285-1c665e2b90dd"), "Meeting" },
                    { new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377"), "Event" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "FullName", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("2840fdf4-638e-4a6c-a26c-23cada294ce0"), new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f"), "Master Admin", new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" },
                    { new Guid("543cfe43-ef05-48c2-a097-28b7775b500a"), new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a"), "Logging Admin", new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("5766c22b-7807-4ee5-a2fb-9638c1c0e449"), new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc"), "Stockholm", "TechCorp", new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321"), "John Doe", "A1234567", "123-45-6789" },
                    { new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1"), "Oslo", "InnovateInc", new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e"), "Jane Smith", "B7654321", "987-65-4321" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9"), new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1") },
                    { new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd"), new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc") }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_account_id", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("53e78c27-2525-4dae-ba8c-be5cd619ba16"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"), new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9"), null },
                    { new Guid("c52a87c8-083e-4c81-8db4-bb75727c301d"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"), new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_status_visitor_account_id",
                table: "status",
                column: "visitor_account_id");

            migrationBuilder.AddForeignKey(
                name: "FK_status_visitorAccounts_visitor_account_id",
                table: "status",
                column: "visitor_account_id",
                principalTable: "visitorAccounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_status_visitors_VisitorId",
                table: "status",
                column: "VisitorId",
                principalTable: "visitors",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_status_visitorAccounts_visitor_account_id",
                table: "status");

            migrationBuilder.DropForeignKey(
                name: "FK_status_visitors_VisitorId",
                table: "status");

            migrationBuilder.DropIndex(
                name: "IX_status_visitor_account_id",
                table: "status");

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("2840fdf4-638e-4a6c-a26c-23cada294ce0"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("543cfe43-ef05-48c2-a097-28b7775b500a"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("8de6812e-caff-4991-9285-1c665e2b90dd"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("53e78c27-2525-4dae-ba8c-be5cd619ba16"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("c52a87c8-083e-4c81-8db4-bb75727c301d"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("5766c22b-7807-4ee5-a2fb-9638c1c0e449"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("2fbd583c-a475-4268-9305-9da1e5ce174a"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("ad3b17e8-5e81-4e95-99b6-75bbd166ba5f"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("b48cf28f-7143-48f2-b724-69b9ae16feb9"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("e10c4314-afe8-4040-be4e-e2241a08b4bd"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("7a3d837f-0438-4456-abe7-902a50efe61c"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("c2f99247-0307-4aa8-92ad-014347a81a4b"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("dc54d56f-5132-4976-aef2-f313acbeca10"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("3d1488b2-f162-4a3f-a378-92d1973b842f"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("c5b4c4ae-49a3-43ea-9523-86d02ee62377"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("9ffd4a73-8564-4109-bd82-1c4ad56b21fc"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("bfae3745-1cb7-4234-8b8e-6fb2d2ba17e1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("7ed0fbd1-e0ba-440c-93fe-c4fe9006890e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("803c609b-f7c9-4c41-80bb-c8b8400fd321"));

            migrationBuilder.DropColumn(
                name: "visitor_account_id",
                table: "status");

            migrationBuilder.RenameColumn(
                name: "VisitorId",
                table: "status",
                newName: "visitor_id");

            migrationBuilder.RenameIndex(
                name: "IX_status_VisitorId",
                table: "status",
                newName: "IX_status_visitor_id");

            migrationBuilder.AlterColumn<Guid>(
                name: "visitor_id",
                table: "status",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_status_visitors_visitor_id",
                table: "status",
                column: "visitor_id",
                principalTable: "visitors",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
