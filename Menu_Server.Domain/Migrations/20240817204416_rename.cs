using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Menu_Server.Domain.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Coast",
                table: "Ingredients",
                newName: "Price");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Ingredients",
                newName: "Coast");
        }
    }
}
