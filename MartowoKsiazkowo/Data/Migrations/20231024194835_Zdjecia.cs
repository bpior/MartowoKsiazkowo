using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MartowoKsiazkowo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Zdjecia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ImageData",
                table: "Book",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageMimeType",
                table: "Book",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageData",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "ImageMimeType",
                table: "Book");
        }
    }
}
