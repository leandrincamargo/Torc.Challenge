using Microsoft.EntityFrameworkCore.Migrations;

namespace Torc.Challenge.Infrastructure.Migrations
{
    public partial class InsertBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .Sql(@$"INSERT INTO books (title, first_name, last_name, total_copies, copies_in_use, type, isbn, category)
                        VALUES ('Pride and Prejudice', 'Jane', 'Austen', 100, 80, 'Hardcover', '1234567891', 'Fiction'),
                            ('To Kill a Mockingbird', 'Harper', 'Lee', 75, 65, 'Paperback', '1234567892', 'Fiction'),
                            ('The Catcher in the Rye', 'J.D.', 'Salinger', 50, 45, 'Hardcover', '1234567893', 'Fiction'),
                            ('The Great Gatsby', 'F. Scott', 'Fitzgerald', 50, 22, 'Hardcover', '1234567894', 'Non-Fiction'),
                            ('The Alchemist', 'Paulo', 'Coelho', 50, 35, 'Hardcover', '1234567895', 'Biography'),
                            ('The Book Thief', 'Markus', 'Zusak', 75, 11, 'Hardcover', '1234567896', 'Mystery'),
                            ('The Chronicles of Narnia', 'C.S.', 'Lewis', 100, 14, 'Paperback', '1234567897', 'Sci-Fi'),
                            ('The Da Vinci Code', 'Dan', 'Brown', 50, 40, 'Paperback', '1234567898', 'Sci-Fi'),
                            ('The Grapes of Wrath', 'John', 'Steinbeck', 50, 35, 'Hardcover', '1234567899', 'Fiction'),
                            ('The Hitchhiker''s Guide to the Galaxy', 'Douglas', 'Adams', 50, 35, 'Paperback', '1234567900', 'Non-Fiction'),
                            ('Moby-Dick', 'Herman', 'Melville', 30, 8, 'Hardcover', '8901234567', 'Fiction'),
                            ('To Kill a Mockingbird', 'Harper', 'Lee', 20, 0, 'Paperback', '9012345678', 'Non-Fiction'),
                            ('The Catcher in the Rye', 'J.D.', 'Salinger', 10, 1, 'Hardcover', '0123456789', 'Non-Fiction');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
               .Sql(@$"delete from books");
        }
    }
}
