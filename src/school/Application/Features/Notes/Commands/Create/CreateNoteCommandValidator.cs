using FluentValidation;

namespace Application.Features.Notes.Commands.Create;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        RuleFor(c => c.Value).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
    }
}