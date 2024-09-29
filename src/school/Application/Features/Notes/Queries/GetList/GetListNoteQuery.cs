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

namespace Application.Features.Notes.Queries.GetList;

public class GetListNoteQuery : IRequest<GetListResponse<GetListNoteListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListNotes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetNotes";
    public TimeSpan? SlidingExpiration { get; }

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
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListNoteListItemDto> response = _mapper.Map<GetListResponse<GetListNoteListItemDto>>(notes);
            return response;
        }
    }
}