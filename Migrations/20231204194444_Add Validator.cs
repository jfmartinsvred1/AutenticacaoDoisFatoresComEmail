using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutenticacaoComEmail.Migrations
{
    public partial class AddValidator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Validator",
                table: "AspNetUsers",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validator",
                table: "AspNetUsers");
        }
    }
}
