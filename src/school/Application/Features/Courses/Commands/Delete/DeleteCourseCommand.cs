using Application.Features.Courses.Constants;
using Application.Features.Courses.Constants;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Courses.Constants.CoursesOperationClaims;

namespace Application.Features.Courses.Commands.Delete;

public class DeleteCourseCommand : IRequest<DeletedCourseResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CoursesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCourses"];

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, DeletedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public DeleteCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<DeletedCourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _courseBusinessRules.CourseShouldExistWhenSelected(course);

            await _courseRepository.DeleteAsync(course!);

            DeletedCourseResponse response = _mapper.Map<DeletedCourseResponse>(course);
            return response;
        }
    }
}