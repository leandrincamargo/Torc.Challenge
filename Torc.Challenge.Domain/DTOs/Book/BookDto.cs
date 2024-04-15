namespace Torc.Challenge.Domain.DTOs.Book
{
    public class BookDto
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
        public string? Type { get; set; }
        public string? Isbn { get; set; }
        public string? Category { get; set; }

        public static explicit operator BookDto(Entities.Book book)
        {
            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                FirstName = book.FirstName,
                LastName = book.LastName,
                TotalCopies = book.TotalCopies,
                CopiesInUse = book.CopiesInUse,
                Type = book.Type,
                Isbn = book.Isbn,
                Category = book.Category
            };
        }
    }
}
