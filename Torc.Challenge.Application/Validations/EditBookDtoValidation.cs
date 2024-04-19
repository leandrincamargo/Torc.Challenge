using FluentValidation;
using Torc.Challenge.Domain.DTOs.Book;

namespace Torc.Challenge.Application.Validations
{
    public class EditBookDtoValidation : AbstractValidator<EditBookDto>
    {
        public EditBookDtoValidation()
        {
            RuleFor(d => d.Type).MaximumLength(50).WithMessage("Max length of type is 50 characters");

            RuleFor(d => d.Category).MaximumLength(50).WithMessage("Max length of category is 50 characters");

            RuleFor(d => d.TotalCopies).GreaterThanOrEqualTo(0).WithMessage("Total copies is required");

            RuleFor(d => d.CopiesInUse).GreaterThanOrEqualTo(0).WithMessage("Copies in use is required");
        }
    }
}
