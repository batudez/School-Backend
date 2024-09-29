using Application.Features.Notes.Constants;
using Application.Features.Notes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Notes.Constants.NotesOperationClaims;

namespace Application.Features.Notes.Commands.Create;

public class CreateNoteCommand : IRequest<CreatedNoteResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public required int Value { get; set; }
    public required Guid StudentId { get; set; }
    public required Guid CourseId { get; set; }
    public required Guid InstructorId { get; set; }

    public string[] Roles => [Admin, Write, NotesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetNotes"];

    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, CreatedNoteResponse>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly NoteBusinessRules _noteBusinessRules;

        public CreateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository,
                                         NoteBusinessRules noteBusinessRules)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _noteBusinessRules = noteBusinessRules;
        }

        public async Task<CreatedNoteResponse> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            Note note = _mapper.Map<Note>(request);

            await _noteRepository.AddAsync(note);

            CreatedNoteResponse response = _mapper.Map<CreatedNoteResponse>(note);
            return response;
        }
    }
}