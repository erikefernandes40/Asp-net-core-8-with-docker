using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstApi.Migrations
{
    /// <inheritdoc />
    public partial class add_fields_to_employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "employee",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "employee",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "employee");

            migrationBuilder.DropColumn(
                name: "password",
                table: "employee");
        }
    }
}
