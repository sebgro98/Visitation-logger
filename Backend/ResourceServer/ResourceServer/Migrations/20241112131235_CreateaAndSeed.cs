using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class CreateaAndSeed : Migration
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
                name: "admins",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    account_type_id = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    visitor_id = table.Column<Guid>(type: "uuid", nullable: false),
                    check_in_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    check_in_sign = table.Column<string>(type: "text", nullable: false),
                    check_out_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    check_out_sign = table.Column<string>(type: "text", nullable: false),
                    last_export_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NodeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status", x => x.id);
                    table.ForeignKey(
                        name: "FK_status_nodes_NodeId",
                        column: x => x.NodeId,
                        principalTable: "nodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_status_visitors_visitor_id",
                        column: x => x.visitor_id,
                        principalTable: "visitors",
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
                    VisitorId = table.Column<Guid>(type: "uuid", nullable: true),
                    account_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    purpose_type_id = table.Column<Guid>(type: "uuid", nullable: false)
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
                        name: "FK_visitorAccounts_purpose_types_purpose_type_id",
                        column: x => x.purpose_type_id,
                        principalTable: "purpose_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visitorAccounts_visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "visitors",
                        principalColumn: "id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_admins_account_type_id",
                table: "admins",
                column: "account_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_admins_username",
                table: "admins",
                column: "username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_status_NodeId",
                table: "status",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_status_visitor_id",
                table: "status",
                column: "visitor_id");

            migrationBuilder.CreateIndex(
                name: "IX_visitorAccounts_account_type_id",
                table: "visitorAccounts",
                column: "account_type_id");

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
                name: "IX_visitorAccounts_VisitorId",
                table: "visitorAccounts",
                column: "VisitorId");

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
                name: "nodes");

            migrationBuilder.DropTable(
                name: "account_types");

            migrationBuilder.DropTable(
                name: "purpose_types");

            migrationBuilder.DropTable(
                name: "visitors");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
