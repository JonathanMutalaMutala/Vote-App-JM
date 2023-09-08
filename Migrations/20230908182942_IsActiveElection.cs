using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vote_Application_JonathanMutala.Migrations
{
    public partial class IsActiveElection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Election",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Election");
        }
    }
}
