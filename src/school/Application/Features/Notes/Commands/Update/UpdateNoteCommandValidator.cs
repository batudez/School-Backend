using FluentValidation;

namespace Application.Features.Notes.Commands.Update;

public class UpdateNoteCommandValidator : AbstractValidator<UpdateNoteCommand>
{
    public UpdateNoteCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Value).NotEmpty();
        RuleFor(c => c.Student).NotEmpty();
        RuleFor(c => c.StudentId).NotEmpty();
        RuleFor(c => c.Course).NotEmpty();
        RuleFor(c => c.CourseId).NotEmpty();
        RuleFor(c => c.Instructor).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
    }
}