using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InterfaceAdapters.Migrations
{
    /// <inheritdoc />
    public partial class foreingkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Concepts_PetId",
                table: "Concepts",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Concepts_Pets_PetId",
                table: "Concepts",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Concepts_Pets_PetId",
                table: "Concepts");

            migrationBuilder.DropIndex(
                name: "IX_Concepts_PetId",
                table: "Concepts");
        }
    }
}
