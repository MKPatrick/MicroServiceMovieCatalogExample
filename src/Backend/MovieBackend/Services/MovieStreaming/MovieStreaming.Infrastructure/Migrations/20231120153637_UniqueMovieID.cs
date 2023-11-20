using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieStreaming.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UniqueMovieID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MovieStreams_MovieID",
                table: "MovieStreams",
                column: "MovieID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovieStreams_MovieID",
                table: "MovieStreams");
        }
    }
}
