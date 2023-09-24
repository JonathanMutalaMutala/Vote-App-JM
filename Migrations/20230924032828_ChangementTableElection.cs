using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vote_Application_JonathanMutala.Migrations
{
    public partial class ChangementTableElection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Election");

            migrationBuilder.AddColumn<bool>(
                name: "IsClose",
                table: "Election",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInProgress",
                table: "Election",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnCreate",
                table: "Election",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsClose",
                table: "Election");

            migrationBuilder.DropColumn(
                name: "IsInProgress",
                table: "Election");

            migrationBuilder.DropColumn(
                name: "IsOnCreate",
                table: "Election");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Election",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
