using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Courses.Commands.Create;

public class CreatedCourseResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid InstructorId { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public bool AttendanceObligation { get; set; }
}