using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FluentManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_AuthorBookMaps",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_AuthorBookMaps", x => new { x.Author_Id, x.Book_Id });
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorBookMaps_Fluent_Athors_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Fluent_Athors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fluent_AuthorBookMaps_Fluent_Books_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Fluent_Books",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_AuthorBookMaps_Book_Id",
                table: "Fluent_AuthorBookMaps",
                column: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_AuthorBookMaps");
        }
    }
}
