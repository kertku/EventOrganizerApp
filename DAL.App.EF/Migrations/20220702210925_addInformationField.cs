using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.App.EF.Migrations
{
    public partial class addInformationField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Information",
                table: "Participations",
                type: "nvarchar(max)",
                maxLength: 5000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Information",
                table: "Participations");
        }
    }
}
