using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Courses.Queries.GetList;

public class GetListCourseListItemDto : IDto
{
    public Guid Id { get; set; }
    public Instructor Instructor { get; set; }
    public Guid InstructorId { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
    public bool AttendanceObligation { get; set; }
}