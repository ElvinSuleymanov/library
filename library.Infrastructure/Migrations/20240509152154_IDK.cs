using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IDK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Authors",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Authors",
                type: "longblob",
                nullable: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "Salt",
                table: "Authors",
                type: "longblob",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Authors");
        }
    }
}
