using FluentValidation;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
{
    public CreateInstructorCommandValidator()
    {
        RuleFor(c => c.NameSurname).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.PasswordConfirm).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}