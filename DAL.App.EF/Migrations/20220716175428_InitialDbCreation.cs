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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    RegistryCode = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Information = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndividualUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    IdentificationCode = table.Column<long>(type: "INTEGER", nullable: false),
                    Information = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PaymentTypeName = table.Column<string>(type: "TEXT", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Information = table.Column<string>(type: "TEXT", maxLength: 5000, nullable: true),
                    NumberOfParticipants = table.Column<int>(type: "INTEGER", nullable: true),
                    PaymentTypeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    BusinessUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    IndividualUserId = table.Column<Guid>(type: "TEXT", nullable: true),
                    EventId = table.Column<Guid>(type: "TEXT", nullable: false)
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
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("3900405e-86c3-46a7-85e9-d5ec890163de"), "Teeme Tööd OÜ", 77443382 });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("44434bcd-66b8-4aba-86e9-d4efdef97b49"), "Testiminse AS", 77443382 });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("93664c13-9749-4010-985c-54eab5632cb4"), "Tublitöö As", 77443382 });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("eafe2246-edcf-4126-9625-c76595e3f0a9"), "Kõva Kate OÜ", 77443382 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("366c4a11-f6ee-41d2-974c-8ace37b2b39f"), new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasub kindlasti tulla kõigil.", "Aia 33, Tallinn", "Juhi sünnipäev" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("63fa1ff3-fafe-4a91-bac6-c98e16550308"), new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Ärimajas", "Suvine seminar" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("c8a8cc7a-fd48-4e71-943b-7b6d8efcb6ef"), new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saame kokku ja kuulame", "Metsas", "Suvepäevad" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("dac4ddf3-4757-4e44-a3ea-5ffb004f97ae"), new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Linnahall", "Eilene üritus" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("3532f70f-fe35-422d-bc4c-cf2d1746ac49"), "Aivar", 46411110222L, "test", "Roos" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("c044b9e0-9612-4bf9-8eac-9095081267c8"), "Kalle", 46111110222L, "test", "Sinilill" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("dc1bf13d-f4e3-4c54-9194-e3928bc31e86"), "Kaupe", 46611110222L, "tubli", "Kask" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("fea6f7f9-b715-4721-a6ec-c2d8cd6d3393"), "Piia", 46311110222L, "Infot palju ei ole", "Tulp" });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentTypeName" },
                values: new object[] { new Guid("5f8b3608-1e57-4514-856b-a5d8eaacb4fc"), "Kaardimakse" });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentTypeName" },
                values: new object[] { new Guid("fcc520cb-6653-463c-9508-0d0ebbbfcc59"), "Sularaha" });

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
