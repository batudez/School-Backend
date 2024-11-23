using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notes.Commands.Update;

public class UpdatedNoteResponse : IResponse
{
    public int Value { get; set; }
    public Guid StudentId { get; set; }
}