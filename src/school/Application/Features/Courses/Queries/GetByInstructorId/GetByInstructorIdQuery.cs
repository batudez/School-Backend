using Application.Features.Courses.Queries.GetById;
using Application.Features.Courses.Queries.GetList;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Courses.Constants.CoursesOperationClaims;

namespace Application.Features.Courses.Queries.GetByInstructorId;
public class GetByInstructorIdQuery : IRequest<GetListResponse<GetByInstructorIdItemDto>>, ISecuredRequest
{
    public Guid InstructorId { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByInstructorIdQueryHandler : IRequestHandler<GetByInstructorIdQuery, GetListResponse<GetByInstructorIdItemDto>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetByInstructorIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetByInstructorIdItemDto>> Handle(GetByInstructorIdQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Course> courses = await _courseRepository.GetListAsync(
                predicate: x => x.InstructorId == request.InstructorId,
                cancellationToken: cancellationToken
            );;

            GetListResponse<GetByInstructorIdItemDto> response = _mapper.Map<GetListResponse<GetByInstructorIdItemDto>>(courses);
            return response;
        }
    }
}