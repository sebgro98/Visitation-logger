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
            migrationBuilder.CreateTable(
                name: "account_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    country_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "nodes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    node_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "purpose_types",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purpose_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "visitors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    SSN = table.Column<string>(type: "text", nullable: false),
                    country_id = table.Column<Guid>(type: "uuid", nullable: false),
                    passport_no = table.Column<string>(type: "text", nullable: false),
                    company = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitors", x => x.id);
                    table.ForeignKey(
                        name: "FK_visitors_Countries_country_id",
                        column: x => x.country_id,
                        principalTable: "Countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    account_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    node_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.id);
                    table.ForeignKey(
                        name: "FK_admins_account_types_account_type_id",
                        column: x => x.account_type_id,
                        principalTable: "account_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_admins_nodes_node_Id",
                        column: x => x.node_Id,
                        principalTable: "nodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visitorAccounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    visitor_id = table.Column<Guid>(type: "uuid", nullable: true),
                    account_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    purpose_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    node_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitorAccounts", x => x.id);
                    table.ForeignKey(
                        name: "FK_visitorAccounts_account_types_account_type_id",
                        column: x => x.account_type_id,
                        principalTable: "account_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visitorAccounts_nodes_node_id",
                        column: x => x.node_id,
                        principalTable: "nodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visitorAccounts_purpose_types_purpose_type_id",
                        column: x => x.purpose_type_id,
                        principalTable: "purpose_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visitorAccounts_visitors_visitor_id",
                        column: x => x.visitor_id,
                        principalTable: "visitors",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    visitor_account_id = table.Column<Guid>(type: "uuid", nullable: false),
                    check_in_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    check_in_sign = table.Column<string>(type: "text", nullable: true),
                    check_out_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    check_out_sign = table.Column<string>(type: "text", nullable: true),
                    last_export_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    node_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                    table.ForeignKey(
                        name: "FK_status_nodes_node_id",
                        column: x => x.node_id,
                        principalTable: "nodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_status_visitorAccounts_visitor_account_id",
                        column: x => x.visitor_account_id,
                        principalTable: "visitorAccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_admins_account_type_id",
                table: "admins",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_admins_node_Id",
                table: "admins",
                column: "node_Id");

            migrationBuilder.CreateIndex(
                name: "IX_admins_username",
                table: "admins",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_status_node_id",
                table: "status",
                column: "node_id");

            migrationBuilder.CreateIndex(
                name: "IX_status_visitor_account_id",
                table: "status",
                column: "visitor_account_id");

            migrationBuilder.CreateIndex(
                name: "IX_visitorAccounts_account_type_id",
                table: "visitorAccounts",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_visitorAccounts_node_id",
                table: "visitorAccounts",
                column: "node_id");

            migrationBuilder.CreateIndex(
                name: "IX_visitorAccounts_purpose_type_id",
                table: "visitorAccounts",
                column: "purpose_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_visitorAccounts_username",
                table: "visitorAccounts",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_visitorAccounts_visitor_id",
                table: "visitorAccounts",
                column: "visitor_id");

            migrationBuilder.CreateIndex(
                name: "IX_visitors_country_id",
                table: "visitors",
                column: "country_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "status");

            migrationBuilder.DropTable(
                name: "visitorAccounts");

            migrationBuilder.DropTable(
                name: "account_types");

            migrationBuilder.DropTable(
                name: "nodes");

            migrationBuilder.DropTable(
                name: "purpose_types");

            migrationBuilder.DropTable(
                name: "visitors");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
