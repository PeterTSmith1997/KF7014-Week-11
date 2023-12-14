using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace temperature.Migrations
{
    /// <inheritdoc />
    public partial class alert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "alert",
                table: "Temperatures",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "alert",
                table: "Temperatures");
        }
    }
}
