using Application.Features.Notes.Queries.GetNotesByCourseId;
using Application.Features.Notes.Queries.GetNotesByStudentId;
using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Notes.Queries.GetList;

public class GetListNoteListItemDto : IDto
{
    public int Value { get; set; }
    public Guid StudentId { get; set; }
    public StudentDto Student { get; set; }
    public CourseDto Course { get; set; } // Sadece CourseCode özelliði
}