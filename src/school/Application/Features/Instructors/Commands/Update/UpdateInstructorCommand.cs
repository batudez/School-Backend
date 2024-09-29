using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;

namespace Application.Features.Instructors.Commands.Update;

public class UpdateInstructorCommand : IRequest<UpdatedInstructorResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public Guid Id { get; set; }
    public required string NameSurname { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirm { get; set; }
    public required string ImageUrl { get; set; }

    public string[] Roles => [Admin, Write, InstructorsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInstructors"];

    public class UpdateInstructorCommandHandler : IRequestHandler<UpdateInstructorCommand, UpdatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;

        public UpdateInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
        }

        public async Task<UpdatedInstructorResponse> Handle(UpdateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(predicate: i => i.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorBusinessRules.InstructorShouldExistWhenSelected(instructor);
            instructor = _mapper.Map(request, instructor);

            await _instructorRepository.UpdateAsync(instructor!);

            UpdatedInstructorResponse response = _mapper.Map<UpdatedInstructorResponse>(instructor);
            return response;
        }
    }
}