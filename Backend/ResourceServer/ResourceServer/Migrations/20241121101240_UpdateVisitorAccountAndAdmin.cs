using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVisitorAccountAndAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("60359f12-7e1f-428f-82bb-e4190cb9c474"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("f025c6c9-ed77-4d44-97d4-86c1c8c4d683"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("f4a3c769-20e8-46f8-afef-de0fbab29885"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("229fa498-a558-4498-8ba2-b04c9f3dc3e5"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("71974d2c-40ba-42b7-be50-ef6e892ce081"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("41492cef-5697-42c9-ae84-899fce075184"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("7d4db1e6-30c0-465b-9ca4-368a93445844"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("c06043bb-c05c-4ea8-b208-421c47befa15"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("0373dd99-a8dc-494d-bd43-c24de6a53835"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("708ed67c-97e6-42a8-8223-9358f9a60727"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("7fde4b49-2de8-4513-99e6-dfa3db4b5fed"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("e9465804-912c-4187-9641-f4b900623a36"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("91d83a1a-69dd-43a8-8101-45fab24e8607"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("eddd2fc4-b146-448a-a150-88bfc5cdd48e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("3432dcc4-8ab8-4cea-b415-78a56ca11729"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("40eccb6e-1ff4-44e3-9d24-2e3a631c6c34"));

            migrationBuilder.AddColumn<int>(
                name: "failed_login_attempts",
                table: "visitorAccounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "lockout_end",
                table: "visitorAccounts",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "failed_login_attempts",
                table: "admins",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "lockout_end",
                table: "admins",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("21c89cc3-2010-4cb0-9297-aec8337422a6"), "Norway" },
                    { new Guid("58930c40-8764-40aa-ac0e-268fd0c35f41"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("66240095-4707-4efc-91ba-eb437ddebc02"), "MasterAdmin" },
                    { new Guid("9e1be644-a827-45d7-a6bf-d8cbaa59df91"), "Visitor" },
                    { new Guid("a2bdcf9e-e8c9-4cda-bb8b-977bc88adc13"), "LoggAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("52f57a4a-dbe2-4175-a77e-6e009e8e7f20"), "Oslo Office" },
                    { new Guid("b61d45e8-18be-437f-b35e-8cc350c19602"), "Stockholm Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("922a43cc-b98a-48e9-aab5-c794c3c63158"), "Event" },
                    { new Guid("d69f1cf6-3010-4a5a-ac16-3facded4fe2d"), "Service" },
                    { new Guid("e8ca44c7-4a4a-4466-9853-258a8291e9a4"), "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "failed_login_attempts", "FullName", "lockout_end", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("0f37c915-f22f-4d7b-9278-54186a027c0c"), new Guid("a2bdcf9e-e8c9-4cda-bb8b-977bc88adc13"), 0, "Logging Admin", null, new Guid("52f57a4a-dbe2-4175-a77e-6e009e8e7f20"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" },
                    { new Guid("dd2804de-8af5-4fc4-a3a6-a7a89d80e06a"), new Guid("66240095-4707-4efc-91ba-eb437ddebc02"), 0, "Master Admin", null, new Guid("b61d45e8-18be-437f-b35e-8cc350c19602"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "failed_login_attempts", "lockout_end", "node_id", "password", "purpose_type_id", "start_date", "username", "visitor_id" },
                values: new object[] { new Guid("4e922b55-ae6f-4120-ab72-44ccc6c8300b"), new Guid("9e1be644-a827-45d7-a6bf-d8cbaa59df91"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), 0, null, new Guid("b61d45e8-18be-437f-b35e-8cc350c19602"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("d69f1cf6-3010-4a5a-ac16-3facded4fe2d"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("161114a4-8ab2-42a4-84cb-bc5abea16622"), "Oslo", "InnovateInc", new Guid("21c89cc3-2010-4cb0-9297-aec8337422a6"), "Jane Smith", "B7654321", "987-65-4321" },
                    { new Guid("20919c74-0a0b-4ae6-87c3-628ac9e197aa"), "Stockholm", "TechCorp", new Guid("58930c40-8764-40aa-ac0e-268fd0c35f41"), "John Doe", "A1234567", "123-45-6789" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "failed_login_attempts", "lockout_end", "node_id", "password", "purpose_type_id", "start_date", "username", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("499434a1-89f3-4e4c-8991-416aaa5c7a5f"), new Guid("9e1be644-a827-45d7-a6bf-d8cbaa59df91"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), 0, null, new Guid("52f57a4a-dbe2-4175-a77e-6e009e8e7f20"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("922a43cc-b98a-48e9-aab5-c794c3c63158"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("161114a4-8ab2-42a4-84cb-bc5abea16622") },
                    { new Guid("4fd085d8-68fb-40ce-b054-45d35b3ac345"), new Guid("9e1be644-a827-45d7-a6bf-d8cbaa59df91"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), 0, null, new Guid("b61d45e8-18be-437f-b35e-8cc350c19602"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("d69f1cf6-3010-4a5a-ac16-3facded4fe2d"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("20919c74-0a0b-4ae6-87c3-628ac9e197aa") }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_account_id" },
                values: new object[,]
                {
                    { new Guid("2828e8d6-9983-4555-a17b-4ada5dc5fe99"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("52f57a4a-dbe2-4175-a77e-6e009e8e7f20"), new Guid("499434a1-89f3-4e4c-8991-416aaa5c7a5f") },
                    { new Guid("341df74d-8c77-49b5-9942-dd75d4119119"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b61d45e8-18be-437f-b35e-8cc350c19602"), new Guid("4fd085d8-68fb-40ce-b054-45d35b3ac345") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("0f37c915-f22f-4d7b-9278-54186a027c0c"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("dd2804de-8af5-4fc4-a3a6-a7a89d80e06a"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("e8ca44c7-4a4a-4466-9853-258a8291e9a4"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("2828e8d6-9983-4555-a17b-4ada5dc5fe99"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("341df74d-8c77-49b5-9942-dd75d4119119"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("4e922b55-ae6f-4120-ab72-44ccc6c8300b"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("66240095-4707-4efc-91ba-eb437ddebc02"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("a2bdcf9e-e8c9-4cda-bb8b-977bc88adc13"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("499434a1-89f3-4e4c-8991-416aaa5c7a5f"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("4fd085d8-68fb-40ce-b054-45d35b3ac345"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("9e1be644-a827-45d7-a6bf-d8cbaa59df91"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("52f57a4a-dbe2-4175-a77e-6e009e8e7f20"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("b61d45e8-18be-437f-b35e-8cc350c19602"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("922a43cc-b98a-48e9-aab5-c794c3c63158"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("d69f1cf6-3010-4a5a-ac16-3facded4fe2d"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("161114a4-8ab2-42a4-84cb-bc5abea16622"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("20919c74-0a0b-4ae6-87c3-628ac9e197aa"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("21c89cc3-2010-4cb0-9297-aec8337422a6"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("58930c40-8764-40aa-ac0e-268fd0c35f41"));

            migrationBuilder.DropColumn(
                name: "failed_login_attempts",
                table: "visitorAccounts");

            migrationBuilder.DropColumn(
                name: "lockout_end",
                table: "visitorAccounts");

            migrationBuilder.DropColumn(
                name: "failed_login_attempts",
                table: "admins");

            migrationBuilder.DropColumn(
                name: "lockout_end",
                table: "admins");

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("3432dcc4-8ab8-4cea-b415-78a56ca11729"), "Sweden" },
                    { new Guid("40eccb6e-1ff4-44e3-9d24-2e3a631c6c34"), "Norway" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("7d4db1e6-30c0-465b-9ca4-368a93445844"), "MasterAdmin" },
                    { new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"), "Visitor" },
                    { new Guid("c06043bb-c05c-4ea8-b208-421c47befa15"), "LoggAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"), "Stockholm Office" },
                    { new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"), "Oslo Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("7fde4b49-2de8-4513-99e6-dfa3db4b5fed"), "Event" },
                    { new Guid("e9465804-912c-4187-9641-f4b900623a36"), "Service" },
                    { new Guid("f4a3c769-20e8-46f8-afef-de0fbab29885"), "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "FullName", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("60359f12-7e1f-428f-82bb-e4190cb9c474"), new Guid("7d4db1e6-30c0-465b-9ca4-368a93445844"), "Master Admin", new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" },
                    { new Guid("f025c6c9-ed77-4d44-97d4-86c1c8c4d683"), new Guid("c06043bb-c05c-4ea8-b208-421c47befa15"), "Logging Admin", new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "visitor_id" },
                values: new object[] { new Guid("41492cef-5697-42c9-ae84-899fce075184"), new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("e9465804-912c-4187-9641-f4b900623a36"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("91d83a1a-69dd-43a8-8101-45fab24e8607"), "Oslo", "InnovateInc", new Guid("40eccb6e-1ff4-44e3-9d24-2e3a631c6c34"), "Jane Smith", "B7654321", "987-65-4321" },
                    { new Guid("eddd2fc4-b146-448a-a150-88bfc5cdd48e"), "Stockholm", "TechCorp", new Guid("3432dcc4-8ab8-4cea-b415-78a56ca11729"), "John Doe", "A1234567", "123-45-6789" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "visitor_id" },
                values: new object[,]
                {
                    { new Guid("0373dd99-a8dc-494d-bd43-c24de6a53835"), new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("e9465804-912c-4187-9641-f4b900623a36"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("eddd2fc4-b146-448a-a150-88bfc5cdd48e") },
                    { new Guid("708ed67c-97e6-42a8-8223-9358f9a60727"), new Guid("936b7534-a8f2-473a-b3d3-9abd9d641367"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("7fde4b49-2de8-4513-99e6-dfa3db4b5fed"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("91d83a1a-69dd-43a8-8101-45fab24e8607") }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_account_id" },
                values: new object[,]
                {
                    { new Guid("229fa498-a558-4498-8ba2-b04c9f3dc3e5"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("0493e0dd-dfc2-40bc-adaf-1bb6669e1c3d"), new Guid("0373dd99-a8dc-494d-bd43-c24de6a53835") },
                    { new Guid("71974d2c-40ba-42b7-be50-ef6e892ce081"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("461df1d0-8c3f-43bc-9e7b-ff01ab38136e"), new Guid("708ed67c-97e6-42a8-8223-9358f9a60727") }
                });
        }
    }
}
