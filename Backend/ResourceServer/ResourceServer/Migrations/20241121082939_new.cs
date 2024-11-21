using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ResourceServer.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
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
                    VisitorId = table.Column<Guid>(type: "uuid", nullable: true),
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
                        name: "FK_visitorAccounts_visitors_VisitorId",
                        column: x => x.VisitorId,
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
                    node_id = table.Column<Guid>(type: "uuid", nullable: false),
                    VisitorId = table.Column<Guid>(type: "uuid", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_status_visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "visitors",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "id", "country_name" },
                values: new object[,]
                {
                    { new Guid("11bc10b5-ad59-49f7-b596-f90b59362402"), "Norway" },
                    { new Guid("885eab3b-353d-45d2-b321-b75c3292d81e"), "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "account_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("4fbd008c-93d4-4995-a5ad-ac4abbe0311c"), "LoggAdmin" },
                    { new Guid("8c6165ea-2c47-4178-82b0-b79e3688cab1"), "MasterAdmin" },
                    { new Guid("f98ef32e-3aa7-432c-af44-a0da7b2cb19e"), "Visitor" }
                });

            migrationBuilder.InsertData(
                table: "nodes",
                columns: new[] { "id", "node_name" },
                values: new object[,]
                {
                    { new Guid("149092a9-8b7b-4295-94da-2ef8b91413d9"), "Stockholm Office" },
                    { new Guid("f47e1b03-ec0c-416b-8063-ab9d67199767"), "Oslo Office" }
                });

            migrationBuilder.InsertData(
                table: "purpose_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("37151d50-949f-480c-b27a-05da8c6c43e1"), "Service" },
                    { new Guid("382e19ca-4bc5-414e-a962-da20209c65b3"), "Event" },
                    { new Guid("b6a5301c-3db8-45fa-8863-cbaaa75f1d9c"), "Meeting" }
                });

            migrationBuilder.InsertData(
                table: "admins",
                columns: new[] { "id", "account_type_id", "FullName", "node_Id", "password", "username" },
                values: new object[,]
                {
                    { new Guid("22c95fc6-f2ac-4a75-ae43-e9429e9525e6"), new Guid("4fbd008c-93d4-4995-a5ad-ac4abbe0311c"), "Logging Admin", new Guid("f47e1b03-ec0c-416b-8063-ab9d67199767"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Logging-Admin" },
                    { new Guid("8995cb29-8e8e-41ef-8298-e6f783d36080"), new Guid("8c6165ea-2c47-4178-82b0-b79e3688cab1"), "Master Admin", new Guid("149092a9-8b7b-4295-94da-2ef8b91413d9"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", "Master-Admin" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[] { new Guid("9f7ec946-23cf-4956-ac12-2e601a68103f"), new Guid("f98ef32e-3aa7-432c-af44-a0da7b2cb19e"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("149092a9-8b7b-4295-94da-2ef8b91413d9"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("37151d50-949f-480c-b27a-05da8c6c43e1"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "Angel.man", null });

            migrationBuilder.InsertData(
                table: "visitors",
                columns: new[] { "id", "city", "company", "country_id", "fullname", "passport_no", "SSN" },
                values: new object[,]
                {
                    { new Guid("141c3022-e832-4d4b-8ba4-5af8e05da700"), "Stockholm", "TechCorp", new Guid("885eab3b-353d-45d2-b321-b75c3292d81e"), "John Doe", "A1234567", "123-45-6789" },
                    { new Guid("696ea10c-fa9f-4324-9abd-8004472eac08"), "Oslo", "InnovateInc", new Guid("11bc10b5-ad59-49f7-b596-f90b59362402"), "Jane Smith", "B7654321", "987-65-4321" }
                });

            migrationBuilder.InsertData(
                table: "visitorAccounts",
                columns: new[] { "id", "account_type_id", "end_date", "node_id", "password", "purpose_type_id", "start_date", "username", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("0521cf16-b2f0-4168-8613-3592a4678c93"), new Guid("f98ef32e-3aa7-432c-af44-a0da7b2cb19e"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("149092a9-8b7b-4295-94da-2ef8b91413d9"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("37151d50-949f-480c-b27a-05da8c6c43e1"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "john.doe", new Guid("141c3022-e832-4d4b-8ba4-5af8e05da700") },
                    { new Guid("35386052-60bd-45b6-8f3a-48020594ee7a"), new Guid("f98ef32e-3aa7-432c-af44-a0da7b2cb19e"), new DateTime(2023, 1, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f47e1b03-ec0c-416b-8063-ab9d67199767"), "695d6cc588c73738c7b30d21954af72431eeb703ae6ae1b013", new Guid("382e19ca-4bc5-414e-a962-da20209c65b3"), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "jane.smith", new Guid("696ea10c-fa9f-4324-9abd-8004472eac08") }
                });

            migrationBuilder.InsertData(
                table: "status",
                columns: new[] { "id", "check_in_sign", "check_in_time", "check_out_sign", "check_out_time", "last_export_date", "node_id", "visitor_account_id", "VisitorId" },
                values: new object[,]
                {
                    { new Guid("95518960-29a6-4fb8-a95f-80d9c4962bdf"), "JD123", new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Utc), "JD456", new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("149092a9-8b7b-4295-94da-2ef8b91413d9"), new Guid("0521cf16-b2f0-4168-8613-3592a4678c93"), null },
                    { new Guid("98b619cb-5da6-47d4-88b5-bebc97701a18"), "JS321", new DateTime(2024, 1, 2, 9, 0, 0, 0, DateTimeKind.Utc), "JS654", new DateTime(2024, 1, 2, 18, 0, 0, 0, DateTimeKind.Utc), new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f47e1b03-ec0c-416b-8063-ab9d67199767"), new Guid("35386052-60bd-45b6-8f3a-48020594ee7a"), null }
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
                name: "IX_status_VisitorId",
                table: "status",
                column: "VisitorId");

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
