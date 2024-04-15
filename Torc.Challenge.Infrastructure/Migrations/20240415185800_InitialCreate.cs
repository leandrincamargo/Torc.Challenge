using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Torc.Challenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(100)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(100)", nullable: false),
                    total_copies = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    copies_in_use = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    type = table.Column<string>(type: "varchar(50)", nullable: true),
                    isbn = table.Column<string>(type: "varchar(80)", nullable: true),
                    category = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.book_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "books");
        }
    }
}
