namespace Torc.Challenge.Domain.DTOs.Book
{
    public class EditBookDto
    {
        public string? Type { get; set; }
        public string? Category { get; set; }
        public int TotalCopies { get; set; }
        public int CopiesInUse { get; set; }
    }
}
