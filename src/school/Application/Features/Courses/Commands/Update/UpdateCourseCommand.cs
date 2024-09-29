using Application.Features.Courses.Constants;
using Application.Features.Courses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Courses.Constants.CoursesOperationClaims;

namespace Application.Features.Courses.Commands.Update;

public class UpdateCourseCommand : IRequest<UpdatedCourseResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public required Instructor Instructor { get; set; }
    public required Guid InstructorId { get; set; }
    public required string CourseName { get; set; }
    public required string CourseCode { get; set; }
    public required bool AttendanceObligation { get; set; }

    public string[] Roles => [Admin, Write, CoursesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCourses"];

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, UpdatedCourseResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly CourseBusinessRules _courseBusinessRules;

        public UpdateCourseCommandHandler(IMapper mapper, ICourseRepository courseRepository,
                                         CourseBusinessRules courseBusinessRules)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _courseBusinessRules = courseBusinessRules;
        }

        public async Task<UpdatedCourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            Course? course = await _courseRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _courseBusinessRules.CourseShouldExistWhenSelected(course);
            course = _mapper.Map(request, course);

            await _courseRepository.UpdateAsync(course!);

            UpdatedCourseResponse response = _mapper.Map<UpdatedCourseResponse>(course);
            return response;
        }
    }
}