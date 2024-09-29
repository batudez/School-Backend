using FluentValidation;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        RuleFor(c => c.NameSurname).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.TelephoneNumber).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.PasswordConfirm).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}