using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Torc.Challenge.Domain.DTOs.Book;

namespace Torc.Challenge.Domain.Entities
{
    [Table("books")]
    public class Book
    {
        [Column("book_id")]
        public int BookId { get; set; }

        [Required]
        [Column("title", TypeName = "varchar(100)")]
        public required string Title { get; set; }

        [Required]
        [Column("first_name", TypeName = "varchar(100)")]
        public required string FirstName { get; set; }

        [Required]
        [Column("last_name", TypeName = "varchar(100)")]
        public required string LastName { get; set; }

        [Required]
        [Column("total_copies")]
        public int TotalCopies { get; set; }

        [Required]
        [Column("copies_in_use")]
        public int CopiesInUse { get; set; }

        [Column("type", TypeName = "varchar(50)")]
        public string? Type { get; set; }

        [Column("isbn", TypeName = "varchar(80)")]
        public string? Isbn { get; set; }

        [Column("category", TypeName = "varchar(50)")]
        public string? Category { get; set; }

        public static explicit operator Book(NewBookDto book)
        {
            return new Book
            {
                Title = book.Title,
                FirstName = book.FirstName,
                LastName = book.LastName,
                TotalCopies = book.TotalCopies,
                Type = book.Type,
                Isbn = book.Isbn,
                Category = book.Category
            };
        }
    }
}
