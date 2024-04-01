using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nest_backend.Migrations
{
    public partial class UpdatedUserRegistrtionLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "AspNetUsers",
                newName: "FullName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "Fullname");
        }
    }
}
