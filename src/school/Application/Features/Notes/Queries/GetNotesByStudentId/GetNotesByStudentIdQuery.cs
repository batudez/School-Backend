using Application.Features.Notes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Notes.Queries.GetNotesByStudentId;

public class GetNotesByStudentIdQuery : IRequest<GetNotesByStudentIdResponse>
{
    public Guid StudentId { get; set; }

    public class GetNotesByStudentIdQueryHandler : IRequestHandler<GetNotesByStudentIdQuery, GetNotesByStudentIdResponse>
    {
        private readonly IMapper _mapper;
        private readonly NoteBusinessRules _noteBusinessRules;
        private readonly INoteRepository _noteRepository;

        public GetNotesByStudentIdQueryHandler(IMapper mapper, NoteBusinessRules noteBusinessRules, INoteRepository noteRepository)
        {
            _mapper = mapper;
            _noteBusinessRules = noteBusinessRules;
            _noteRepository = noteRepository;
        }

        public async Task<GetNotesByStudentIdResponse> Handle(GetNotesByStudentIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Note> notes = await _noteRepository.GetListAsync(
                predicate: n => n.StudentId == request.StudentId,
                cancellationToken: cancellationToken,
                include: x => x.Include(i => i.Course)
            );

            GetNotesByStudentIdResponse response = _mapper.Map<GetNotesByStudentIdResponse>(notes);
            return response;
        }
    }
}
