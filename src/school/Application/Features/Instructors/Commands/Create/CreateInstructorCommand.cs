using Application.Features.Instructors.Constants;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;
using NArchitecture.Core.Security.Hashing;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommand : IRequest<CreatedInstructorResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public required string NameSurname { get; set; }
    public required string Email { get; set; }
    public required string Address { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirm { get; set; }
    public required string ImageUrl { get; set; }

    public string[] Roles => [Admin, Write, InstructorsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetInstructors"];

    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, CreatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;
        private readonly IUserRepository _userRepository;

        public CreateInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules, IUserRepository userRepository)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<CreatedInstructorResponse> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            Instructor instructor = _mapper.Map<Instructor>(request);
            User user = new User();


            CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(instructor);

            user.Id = response.Id;
            user.Email = response.Email;

            HashingHelper.CreatePasswordHash(
               request.Password,
               passwordHash: out byte[] passwordHash,
               passwordSalt: out byte[] passwordSalt
           );
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _userRepository.AddAsync(user);

            await _instructorRepository.AddAsync(instructor);

            
            return response;
        }
    }
}