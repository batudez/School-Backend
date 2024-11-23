using Application.Features.Notes.Queries.GetList;
using Application.Features.Notes.Queries.GetNotesByStudentId;
using Application.Features.Notes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Notes.Constants.NotesOperationClaims;

namespace Application.Features.Notes.Queries.GetNotesByCourseId;
public class GetNotesByCourseIdQuery : IRequest<GetListResponse<GetListNoteListItemDto>>, ISecuredRequest
{
    public Guid CourseId { get; set; }
    public string[] Roles => [Admin, Read];

    public class GetNotesByCourseIdQueryHandler : IRequestHandler<GetNotesByCourseIdQuery, GetListResponse<GetListNoteListItemDto>>
    {
        private readonly INoteRepository _noteRepository;
        private readonly IMapper _mapper;

        public GetNotesByCourseIdQueryHandler(INoteRepository noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListNoteListItemDto>> Handle(GetNotesByCourseIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Note> notes = await _noteRepository.GetListAsync(
                predicate: n => n.CourseId == request.CourseId,
                include: n => n.Include(i => i.Student),
                cancellationToken: cancellationToken
            ) ;

            //var course = _mapper.Map<CourseDto>(new Course());
            var student = _mapper.Map<StudentDto>(new Student());

            GetListResponse<GetListNoteListItemDto> response = _mapper.Map<GetListResponse<GetListNoteListItemDto>>(notes);
            return response;
        }
    }
}