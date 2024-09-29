using FluentValidation;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Instructor).NotEmpty();
        RuleFor(c => c.InstructorId).NotEmpty();
        RuleFor(c => c.CourseName).NotEmpty();
        RuleFor(c => c.CourseCode).NotEmpty();
        RuleFor(c => c.AttendanceObligation).NotEmpty();
    }
}