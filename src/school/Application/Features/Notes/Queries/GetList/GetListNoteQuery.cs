using Application.Features.Notes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Notes.Constants.NotesOperationClaims;
using Microsoft.EntityFrameworkCore;
using Application.Features.Notes.Queries.GetNotesByStudentId;

namespace Application.Features.Notes.Queries.GetList;

public class GetListNoteQuery : IRequest<GetListResponse<GetListNoteListItemDto>>, ISecuredRequest
{
   // public PageRequest PageRequest { get; set; }
    public Guid StudentId { get; set; }
    public string[] Roles => [Admin, Read];

    public class GetListNoteQueryHandler : IRequestHandler<GetListNoteQuery, GetListResponse<GetListNoteListItemDto>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public GetListNoteQueryHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListNoteListItemDto>> Handle(GetListNoteQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Note> notes = await _noteRepository.GetListAsync(
                predicate: n => n.StudentId == request.StudentId,
                include: n => n.Include(i => i.Course),
                cancellationToken: cancellationToken
            );

            var course = _mapper.Map<CourseDto>( new Course() );

            GetListResponse<GetListNoteListItemDto> response = _mapper.Map<GetListResponse<GetListNoteListItemDto>>(notes);
            return response;
        }
    }
}