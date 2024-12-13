using Application.Features.Courses.Constants;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Courses.Constants.CoursesOperationClaims;

namespace Application.Features.Courses.Commands.Create;

public class CreateCourseCommand : IRequest<CreatedCourseResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public required Guid InstructorId { get; set; }
    public required string CourseName { get; set; }
    public required string CourseCode { get; set; }
    public required bool AttendanceObligation { get; set; }

    public string[] Roles => [Admin, Write, CoursesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCourses"];

    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CreatedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public CreateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<CreatedCourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            Course course = _mapper.Map<Course>(request);

            await _courseRepository.AddAsync(course);

            CreatedCourseResponse response = _mapper.Map<CreatedCourseResponse>(course);
            return response;
        }
    }
}