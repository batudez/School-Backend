using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notes.Commands.UpdateGrades;
public class StudentGradeUpdateDto
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public int Value { get; set; }
}