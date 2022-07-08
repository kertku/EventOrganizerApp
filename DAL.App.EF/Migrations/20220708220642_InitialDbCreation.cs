using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.App.EF.Migrations
{
    public partial class InitialDbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistryCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdentificationCode = table.Column<long>(type: "bigint", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentTypeName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    NumberOfParticipants = table.Column<int>(type: "int", nullable: true),
                    PaymentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IndividualUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participations_BusinessUsers_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "BusinessUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participations_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participations_IndividualUsers_IndividualUserId",
                        column: x => x.IndividualUserId,
                        principalTable: "IndividualUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participations_PaymentTypes_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalTable: "PaymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[,]
                {
                    { new Guid("192109a9-9489-4e2c-86b7-21b8c4b8b983"), "Teeme Tööd OÜ", 77443382 },
                    { new Guid("83f86ba8-0659-4fb6-a737-023a215c2c9c"), "Tublitöö As", 77443382 },
                    { new Guid("a91fd073-92a9-45a5-b041-9ad00d9b50df"), "Kõva Kate OÜ", 77443382 },
                    { new Guid("b5725183-7434-45bc-aeca-28bbd1689167"), "Testiminse AS", 77443382 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("15ed81e5-6a38-4716-81ae-ec5cc52f32c0"), new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Linnahall", "Eilene üritus" },
                    { new Guid("1c6e7a5a-6937-4399-9d9c-8dc84c0a20ba"), new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saame kokku ja kuulame", "Metsas", "Suvepäevad" },
                    { new Guid("e0c7195d-cef5-4851-b8d6-c4cfcbe70c91"), new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasub kindlasti tulla kõigil.", "Aia 33, Tallinn", "Juhi sünnipäev" },
                    { new Guid("f817da15-f2b6-411d-a8c8-90b83db3f8ad"), new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Ärimajas", "Suvine seminar" }
                });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[,]
                {
                    { new Guid("058a8bde-1688-4e2d-bcfb-a683cfd67377"), "Kaupe", 46611110222L, "tubli", "Kask" },
                    { new Guid("24460629-1ce8-4652-90aa-b45a36312542"), "Kalle", 46111110222L, "test", "Sinilill" },
                    { new Guid("53ab12fb-0ac2-432b-b012-e99f923802db"), "Aivar", 46411110222L, "test", "Roos" },
                    { new Guid("9dcadced-12e5-41fd-8ac2-59a63bef203e"), "Piia", 46311110222L, "Infot palju ei ole", "Tulp" }
                });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentTypeName" },
                values: new object[,]
                {
                    { new Guid("12b9e68d-9f54-4512-8693-e8409a40825f"), "Sularaha" },
                    { new Guid("46ea1c1a-5467-4ab7-a18f-df6f1ca0b929"), "Kaardimakse" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Participations_BusinessUserId",
                table: "Participations",
                column: "BusinessUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_EventId",
                table: "Participations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_IndividualUserId",
                table: "Participations",
                column: "IndividualUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Participations_PaymentTypeId",
                table: "Participations",
                column: "PaymentTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participations");

            migrationBuilder.DropTable(
                name: "BusinessUsers");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "IndividualUsers");

            migrationBuilder.DropTable(
                name: "PaymentTypes");
        }
    }
}
