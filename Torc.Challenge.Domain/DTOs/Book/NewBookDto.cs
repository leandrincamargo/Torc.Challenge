namespace Torc.Challenge.Domain.DTOs.Book
{
    public class NewBookDto
    {
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int TotalCopies { get; set; }
        public string? Type { get; set; }
        public string? Isbn { get; set; }
        public string? Category { get; set; }
    }
}
