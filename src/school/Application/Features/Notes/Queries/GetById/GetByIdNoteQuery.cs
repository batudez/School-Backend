using Application.Features.Notes.Constants;
using Application.Features.Notes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Notes.Constants.NotesOperationClaims;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Notes.Queries.GetById;

public class GetByIdNoteQuery : IRequest<GetByIdNoteResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdNoteQueryHandler : IRequestHandler<GetByIdNoteQuery, GetByIdNoteResponse>
    {
        private readonly IMapper _mapper;
        private readonly INoteRepository _noteRepository;
        private readonly NoteBusinessRules _noteBusinessRules;

        public GetByIdNoteQueryHandler(IMapper mapper, INoteRepository noteRepository, NoteBusinessRules noteBusinessRules)
        {
            _mapper = mapper;
            _noteRepository = noteRepository;
            _noteBusinessRules = noteBusinessRules;
        }

        public async Task<GetByIdNoteResponse> Handle(GetByIdNoteQuery request, CancellationToken cancellationToken)
        {
            Note? note = await _noteRepository.GetAsync(predicate: n => n.Id == request.Id, cancellationToken: cancellationToken,
                include: x => x.Include(i => i.Instructor)
                .Include(s => s.Student));
            await _noteBusinessRules.NoteShouldExistWhenSelected(note);

            GetByIdNoteResponse response = _mapper.Map<GetByIdNoteResponse>(note);
            return response;
        }
    }
}