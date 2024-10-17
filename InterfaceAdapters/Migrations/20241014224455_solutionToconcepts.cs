using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterfaceAdapters.Migrations
{
    /// <inheritdoc />
    public partial class solutionToconcepts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Concepts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "UnitPrice",
                table: "Concepts",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Concepts");

            migrationBuilder.DropColumn(
                name: "UnitPrice",
                table: "Concepts");
        }
    }
}
