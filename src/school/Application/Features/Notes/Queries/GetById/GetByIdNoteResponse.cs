using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notes.Queries.GetById;

public class GetByIdNoteResponse : IResponse
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public Guid StudentId { get; set; }
    public Student Student { get; set; }
    public Guid CourseId { get; set; }
    public Course Course { get; set; }
    public Guid InstructorId { get; set; }
    public Instructor Instructor { get; set; }
}