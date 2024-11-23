using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notes.Queries.GetNotesByStudentId;

public class GetNotesByStudentIdResponse : IResponse 
{
    public int Value { get; set; }
    public CourseDto CourseName { get; set; }
}
