using FluentValidation;
using lab3.Commands;

namespace lab3.Validators;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().Length(2, 100);
        RuleFor(x => x.Author).NotEmpty().Length(2, 100);
        RuleFor(x => x.Year).InclusiveBetween(1450, DateTime.Now.Year);
    }
}