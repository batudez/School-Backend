using FluentValidation;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.CourseName).NotEmpty();
        RuleFor(c => c.CourseCode).NotEmpty();
        RuleFor(c => c.AttendanceObligation).NotEmpty();
    }
}