using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Courses.Queries.GetByInstructorId;
public class GetByInstructorIdItemDto : IDto
{
    public Guid Id { get; set; }
    public string CourseName { get; set; }
    public string CourseCode { get; set; }
}
