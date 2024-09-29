using Application.Features.Notes.Constants;
using Application.Features.Notes.Constants;
using Application.Features.Notes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Notes.Constants.NotesOperationClaims;

namespace Application.Features.Notes.Commands.Delete;

public class DeleteNoteCommand : IRequest<DeletedNoteResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, NotesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetNotes"];

    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, DeletedNoteResponse>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly NoteBusinessRules _noteBusinessRules;

        public DeleteNoteCommandHandler(IMapper mapper, INoteRepository noteRepository,
                                         NoteBusinessRules noteBusinessRules)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _noteBusinessRules = noteBusinessRules;
        }

        public async Task<DeletedNoteResponse> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            Note? note = await _noteRepository.GetAsync(predicate: n => n.Id == request.Id, cancellationToken: cancellationToken);
            await _noteBusinessRules.NoteShouldExistWhenSelected(note);

            await _noteRepository.DeleteAsync(note!);

            DeletedNoteResponse response = _mapper.Map<DeletedNoteResponse>(note);
            return response;
        }
    }
}