using Application.Features.Notes.Constants;
using Application.Features.Notes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Notes.Constants.NotesOperationClaims;

namespace Application.Features.Notes.Commands.Update;

public class UpdateNoteCommand : IRequest<UpdatedNoteResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public required int Value { get; set; }
    public required Student Student { get; set; }
    public required Guid StudentId { get; set; }
    public required Course Course { get; set; }
    public required Guid CourseId { get; set; }
    public required Instructor Instructor { get; set; }
    public required Guid InstructorId { get; set; }

    public string[] Roles => [Admin, Write, NotesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetNotes"];

    public class UpdateNoteCommandHandler : IRequestHandler<UpdateNoteCommand, UpdatedNoteResponse>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly NoteBusinessRules _noteBusinessRules;

        public UpdateNoteCommandHandler(IMapper mapper, INoteRepository noteRepository,
                                         NoteBusinessRules noteBusinessRules)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _noteBusinessRules = noteBusinessRules;
        }

        public async Task<UpdatedNoteResponse> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            Note? note = await _noteRepository.GetAsync(predicate: n => n.Id == request.Id, cancellationToken: cancellationToken);
            await _noteBusinessRules.NoteShouldExistWhenSelected(note);
            note = _mapper.Map(request, note);

            await _noteRepository.UpdateAsync(note!);

            UpdatedNoteResponse response = _mapper.Map<UpdatedNoteResponse>(note);
            return response;
        }
    }
}