namespace Torc.Challenge.Domain.DTOs.Book
{
    public class EditBookDto
    {
        public required string Title { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
    }
}
