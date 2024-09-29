using NArchitecture.Core.Application.Responses;

namespace Application.Features.Notes.Commands.Delete;

public class DeletedNoteResponse : IResponse
{
    public Guid Id { get; set; }
}