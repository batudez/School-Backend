using FluentValidation;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
{
    public UpdateStudentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.NameSurname).NotEmpty();
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.TelephoneNumber).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();   
        RuleFor(c => c.ImageUrl).NotEmpty();
    }
}