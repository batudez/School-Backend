using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Notes.Queries.GetList;

public class GetListNoteListItemDto : IDto
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public Student Student { get; set; }
    public Guid StudentId { get; set; }
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public Instructor Instructor { get; set; }
    public Guid InstructorId { get; set; }
}