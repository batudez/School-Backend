using NArchitecture.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Notes.Queries.GetNotesByStudentId;
public class CourseDto : IDto
{
    public string CourseCode { get; set; }
    public Guid CourseId { get; set; }
}
