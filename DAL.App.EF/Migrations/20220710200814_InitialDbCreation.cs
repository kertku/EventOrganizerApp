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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("001fa73d-b8bc-43b9-8eeb-27b9ee620c30"), "Teeme Tööd OÜ", 77443382 });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("3d8589e7-611a-41a7-82ee-5f219f3a98b3"), "Kõva Kate OÜ", 77443382 });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("b9489ff2-db80-422c-8efe-e80669995863"), "Testiminse AS", 77443382 });

            migrationBuilder.InsertData(
                table: "BusinessUsers",
                columns: new[] { "Id", "CompanyName", "RegistryCode" },
                values: new object[] { new Guid("bb039692-33ee-471c-9557-fb6be382ca20"), "Tublitöö As", 77443382 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("49bce2c5-23ee-43ff-8515-3a0a9e942bca"), new DateTime(2022, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tasub kindlasti tulla kõigil.", "Aia 33, Tallinn", "Juhi sünnipäev" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("cb0cb587-cc48-44be-9775-a018950284e8"), new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Ärimajas", "Suvine seminar" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("cbd46e44-1ea9-42f7-bd50-5b652ba49333"), new DateTime(2022, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Saame kokku ja kuulame", "Metsas", "Suvepäevad" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Date", "Information", "Location", "Name" },
                values: new object[] { new Guid("df193f93-645b-43bd-ab50-c616783483a7"), new DateTime(2022, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Osad räägivad, teised kuulavad.", "Linnahall", "Eilene üritus" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("29f372f1-2b00-4e7a-8c60-f2fc05657f6e"), "Kalle", 46111110222L, "test", "Sinilill" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("324cadc2-325f-4e79-8dc4-3498d56a1f85"), "Aivar", 46411110222L, "test", "Roos" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("35410fb4-d254-4e56-a95c-de9916f7c329"), "Kaupe", 46611110222L, "tubli", "Kask" });

            migrationBuilder.InsertData(
                table: "IndividualUsers",
                columns: new[] { "Id", "FirstName", "IdentificationCode", "Information", "LastName" },
                values: new object[] { new Guid("66c335c4-9e91-4215-bcaf-ffee063b3f90"), "Piia", 46311110222L, "Infot palju ei ole", "Tulp" });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentTypeName" },
                values: new object[] { new Guid("68cd8f67-28fb-4c0f-8313-e85382f9f58c"), "Kaardimakse" });

            migrationBuilder.InsertData(
                table: "PaymentTypes",
                columns: new[] { "Id", "PaymentTypeName" },
                values: new object[] { new Guid("7b0bc0f9-1ff6-4058-b6fc-92c7e070eb65"), "Sularaha" });

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
