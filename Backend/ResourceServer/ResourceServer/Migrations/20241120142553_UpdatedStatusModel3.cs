using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStatusModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("02669e4d-0d83-4929-aaee-ac8032930eef"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("c5872302-bd38-4227-b9c8-4289c7608c8d"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("b6d46a8c-c9ec-4fd9-a637-26671eceebfb"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("098c2e8d-476d-4d65-ae4f-af6ff88eb3b6"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("590e8ac7-d79f-43c5-8e43-c4c0de49640b"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("6ffa2cc3-de61-431e-b1db-06108bcb027a"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("3c99db9c-b93a-4f0a-b15a-1f015ac1f183"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("f8b17167-e2b4-481b-be1d-71250788628e"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("7c1c5cc4-239a-4eed-bc8a-0617136e4289"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("a452e126-f495-46ac-8dfb-d50dd4c16b2e"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("54478169-4590-4bc8-addf-95cbf00e0480"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("0855fe54-cb09-49ab-9e33-ddb1cfa44f02"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("edf944d6-96e5-487d-8df8-73d2a8346180"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("0726e10f-1ade-40e1-be90-93c34d8f5a96"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("5579bfcb-625b-4037-8e15-f1ec2cb9b527"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("3022bb74-2320-4725-8377-28b91a6ee966"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("48045850-7209-420b-96a7-9cb6e702cba8"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("77438c0f-9862-4ae6-a12c-b042e7aaef2e"), "Norway" },
                    { new Guid("a398fad4-b3c1-4b6c-b096-936bcd49d775"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("03aad3bb-965e-4c3b-9286-cf002f86e6c3"), "LoggAdmin" },
                    { new Guid("9534d3ea-6eb4-4227-a7ac-c5fc2918cd11"), "MasterAdmin" },
                    { new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"), "Visitor" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"), "Oslo Office" },
                    { new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"), "Stockholm Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("5fe4e241-4d85-4ea0-a7ab-fab7395e51af"), "Meeting" },
                    { new Guid("b22bb19c-5c78-49ca-bb1a-4f774385d7dc"), "Event" },
                    { new Guid("e4f4e5fd-5b72-4482-ac30-0efdfc1b26a8"), "Service" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "FullName", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("5a0b0c42-6886-4ae3-b0e4-4da51d3c8f0e"), new Guid("03aad3bb-965e-4c3b-9286-cf002f86e6c3"), "Logging Admin", new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" },
                    { new Guid("8d513038-65bc-427a-8a55-46c58a49492a"), new Guid("9534d3ea-6eb4-4227-a7ac-c5fc2918cd11"), "Master Admin", new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("93ba0ecc-d49a-4b9c-81d3-55b89d016d99"), new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("e4f4e5fd-5b72-4482-ac30-0efdfc1b26a8"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("af67b649-669a-40f7-8b07-e7eb124d2b5c"), "Stockholm", "TechCorp", new Guid("a398fad4-b3c1-4b6c-b096-936bcd49d775"), "John Doe", "A1234567", "123-45-6789" },
                    { new Guid("b4598202-d400-49bc-897b-f89ab8e7c0fd"), "Oslo", "InnovateInc", new Guid("77438c0f-9862-4ae6-a12c-b042e7aaef2e"), "Jane Smith", "B7654321", "987-65-4321" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("3a793485-637f-4db8-9f66-a3aa1f547258"), new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("e4f4e5fd-5b72-4482-ac30-0efdfc1b26a8"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("af67b649-669a-40f7-8b07-e7eb124d2b5c") },
                    { new Guid("b03cd088-1ad0-461f-9950-0173e64c6899"), new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("b22bb19c-5c78-49ca-bb1a-4f774385d7dc"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("b4598202-d400-49bc-897b-f89ab8e7c0fd") }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_account_id" },
                values: new object[,]
                {
                    { new Guid("157f2ea0-1a32-44fc-b311-a5074b463ad6"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"), new Guid("b03cd088-1ad0-461f-9950-0173e64c6899") },
                    { new Guid("7d5fc47a-3ff0-4021-ac28-f4177c0d7b74"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"), new Guid("3a793485-637f-4db8-9f66-a3aa1f547258") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("5a0b0c42-6886-4ae3-b0e4-4da51d3c8f0e"));

            migrationBuilder.DeleteData(
                table: "admins",
                keyColumn: "id",
                keyValue: new Guid("8d513038-65bc-427a-8a55-46c58a49492a"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("5fe4e241-4d85-4ea0-a7ab-fab7395e51af"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("157f2ea0-1a32-44fc-b311-a5074b463ad6"));

            migrationBuilder.DeleteData(
                table: "status",
                keyColumn: "id",
                keyValue: new Guid("7d5fc47a-3ff0-4021-ac28-f4177c0d7b74"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("93ba0ecc-d49a-4b9c-81d3-55b89d016d99"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("03aad3bb-965e-4c3b-9286-cf002f86e6c3"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("9534d3ea-6eb4-4227-a7ac-c5fc2918cd11"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("3a793485-637f-4db8-9f66-a3aa1f547258"));

            migrationBuilder.DeleteData(
                table: "visitorAccounts",
                keyColumn: "id",
                keyValue: new Guid("b03cd088-1ad0-461f-9950-0173e64c6899"));

            migrationBuilder.DeleteData(
                table: "account_types",
                keyColumn: "id",
                keyValue: new Guid("a0157d26-caa2-4da7-8a05-dd2b65fd0258"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("2ff0c831-74bf-4d5f-9713-219bfff2de20"));

            migrationBuilder.DeleteData(
                table: "nodes",
                keyColumn: "id",
                keyValue: new Guid("4298b279-90c0-4332-b595-d04da0cdbfbc"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("b22bb19c-5c78-49ca-bb1a-4f774385d7dc"));

            migrationBuilder.DeleteData(
                table: "purpose_types",
                keyColumn: "id",
                keyValue: new Guid("e4f4e5fd-5b72-4482-ac30-0efdfc1b26a8"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("af67b649-669a-40f7-8b07-e7eb124d2b5c"));

            migrationBuilder.DeleteData(
                table: "visitors",
                keyColumn: "id",
                keyValue: new Guid("b4598202-d400-49bc-897b-f89ab8e7c0fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("77438c0f-9862-4ae6-a12c-b042e7aaef2e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "id",
                keyValue: new Guid("a398fad4-b3c1-4b6c-b096-936bcd49d775"));

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("3022bb74-2320-4725-8377-28b91a6ee966"), "Sweden" },
                    { new Guid("48045850-7209-420b-96a7-9cb6e702cba8"), "Norway" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"), "Visitor" },
                    { new Guid("3c99db9c-b93a-4f0a-b15a-1f015ac1f183"), "LoggAdmin" },
                    { new Guid("f8b17167-e2b4-481b-be1d-71250788628e"), "MasterAdmin" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("54478169-4590-4bc8-addf-95cbf00e0480"), "Stockholm Office" },
                    { new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"), "Oslo Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("0855fe54-cb09-49ab-9e33-ddb1cfa44f02"), "Event" },
                    { new Guid("b6d46a8c-c9ec-4fd9-a637-26671eceebfb"), "Meeting" },
                    { new Guid("edf944d6-96e5-487d-8df8-73d2a8346180"), "Service" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "FullName", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("02669e4d-0d83-4929-aaee-ac8032930eef"), new Guid("3c99db9c-b93a-4f0a-b15a-1f015ac1f183"), "Logging Admin", new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" },
                    { new Guid("c5872302-bd38-4227-b9c8-4289c7608c8d"), new Guid("f8b17167-e2b4-481b-be1d-71250788628e"), "Master Admin", new Guid("54478169-4590-4bc8-addf-95cbf00e0480"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("6ffa2cc3-de61-431e-b1db-06108bcb027a"), new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("54478169-4590-4bc8-addf-95cbf00e0480"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("edf944d6-96e5-487d-8df8-73d2a8346180"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("0726e10f-1ade-40e1-be90-93c34d8f5a96"), "Stockholm", "TechCorp", new Guid("3022bb74-2320-4725-8377-28b91a6ee966"), "John Doe", "A1234567", "123-45-6789" },
                    { new Guid("5579bfcb-625b-4037-8e15-f1ec2cb9b527"), "Oslo", "InnovateInc", new Guid("48045850-7209-420b-96a7-9cb6e702cba8"), "Jane Smith", "B7654321", "987-65-4321" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("7c1c5cc4-239a-4eed-bc8a-0617136e4289"), new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("0855fe54-cb09-49ab-9e33-ddb1cfa44f02"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("5579bfcb-625b-4037-8e15-f1ec2cb9b527") },
                    { new Guid("a452e126-f495-46ac-8dfb-d50dd4c16b2e"), new Guid("1c09b5fb-51ed-4bab-90b4-503cc11e1fa6"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("54478169-4590-4bc8-addf-95cbf00e0480"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("edf944d6-96e5-487d-8df8-73d2a8346180"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("0726e10f-1ade-40e1-be90-93c34d8f5a96") }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_account_id" },
                values: new object[,]
                {
                    { new Guid("098c2e8d-476d-4d65-ae4f-af6ff88eb3b6"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("54478169-4590-4bc8-addf-95cbf00e0480"), new Guid("a452e126-f495-46ac-8dfb-d50dd4c16b2e") },
                    { new Guid("590e8ac7-d79f-43c5-8e43-c4c0de49640b"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f864e5b4-bf21-458d-8c53-0bac40362c8d"), new Guid("7c1c5cc4-239a-4eed-bc8a-0617136e4289") }
                });
        }
    }
}
