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
                    node_Id = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    visitor_id = table.Column<Guid>(type: "uuid", nullable: false),
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
                name: "IX_status_visitor_id",
                table: "status",
                column: "visitor_id");

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
