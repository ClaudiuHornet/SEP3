using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PersistenceServer.Migrations
{
    public partial class S05_RemoveUserDbSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campuses",
                columns: table => new
                {
                    City = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Street = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    postcode = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campuses", x => new { x.City, x.Street, x.postcode });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "ViaEntities",
                columns: table => new
                {
                    ViaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Password = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViaEntities", x => x.ViaId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    viaId = table.Column<int>(type: "integer", nullable: false),
                    type = table.Column<int>(type: "integer", nullable: false),
                    ApplicationPassword = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Roles_type",
                        column: x => x.type,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Accounts_ViaEntities_viaId",
                        column: x => x.viaId,
                        principalTable: "ViaEntities",
                        principalColumn: "ViaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    ViaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CampusCity = table.Column<string>(type: "character varying(256)", nullable: true),
                    CampusStreet = table.Column<string>(type: "character varying(256)", nullable: true),
                    CampusPostCode = table.Column<string>(type: "character varying(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.ViaId);
                    table.ForeignKey(
                        name: "FK_Facilities_Campuses_CampusCity_CampusStreet_CampusPostCode",
                        columns: x => new { x.CampusCity, x.CampusStreet, x.CampusPostCode },
                        principalTable: "Campuses",
                        principalColumns: new[] { "City", "Street", "postcode" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Facilities_ViaEntities_ViaId",
                        column: x => x.ViaId,
                        principalTable: "ViaEntities",
                        principalColumn: "ViaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    ViaId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    lname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Cpr = table.Column<long>(type: "bigint", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.ViaId);
                    table.ForeignKey(
                        name: "FK_Members_ViaEntities_ViaId",
                        column: x => x.ViaId,
                        principalTable: "ViaEntities",
                        principalColumn: "ViaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    fname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    lname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ExpirationMonth = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    ExpirationYear = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    SecurityCode = table.Column<int>(type: "integer", nullable: false),
                    AmountOfMoney = table.Column<float>(type: "real", nullable: false),
                    accountId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardNumber);
                    table.ForeignKey(
                        name: "FK_CreditCards_Accounts_accountId",
                        column: x => x.accountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    receiver = table.Column<int>(type: "integer", nullable: false),
                    sender = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_receiver",
                        column: x => x.receiver,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Accounts_sender",
                        column: x => x.sender,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_type",
                table: "Accounts",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_viaId",
                table: "Accounts",
                column: "viaId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_accountId",
                table: "CreditCards",
                column: "accountId");

            migrationBuilder.CreateIndex(
                name: "IX_Facilities_CampusCity_CampusStreet_CampusPostCode",
                table: "Facilities",
                columns: new[] { "CampusCity", "CampusStreet", "CampusPostCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_receiver",
                table: "Transactions",
                column: "receiver");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_sender",
                table: "Transactions",
                column: "sender");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Campuses");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "ViaEntities");
        }
    }
}
