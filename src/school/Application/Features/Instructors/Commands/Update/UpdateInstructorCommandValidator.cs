using FluentValidation;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommandValidator : AbstractValidator<UpdateInstructorCommand>
{
    public UpdateInstructorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.NameSurname).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.Password).NotEmpty();
        RuleFor(c => c.PasswordConfirm).NotEmpty();
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}