using FluentValidation;
using Torc.Challenge.Domain.DTOs.Book;

namespace Torc.Challenge.Application.Validations
{
    public class BookDtoValidation : AbstractValidator<BookDto>
    {
        public BookDtoValidation()
        {
            RuleFor(d => d.Title)
                .NotEmpty().WithMessage("The title is required")
                .MaximumLength(100).WithMessage("Max length of title is 200 characters");

            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("The first name is required")
                .MaximumLength(50).WithMessage("Max length of first name is 50 characters");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("The last name is required")
                .MaximumLength(50).WithMessage("Max length of last name is 50 characters");

            RuleFor(d => d.TotalCopies).GreaterThanOrEqualTo(0).WithMessage("Total copies is required");

            RuleFor(d => d.CopiesInUse).GreaterThanOrEqualTo(0).WithMessage("Copies in use is required");

            RuleFor(d => d.Type).MaximumLength(50).WithMessage("Max length of type is 50 characters");

            RuleFor(d => d.Isbn).MaximumLength(80).WithMessage("Max length of isbn is 80 characters");

            RuleFor(d => d.Category).MaximumLength(50).WithMessage("Max length of category is 50 characters");
        }
    }
}
