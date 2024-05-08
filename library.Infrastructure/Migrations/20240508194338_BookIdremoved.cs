using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookIdremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Genres");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Genres",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
