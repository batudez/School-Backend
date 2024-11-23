using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;
using NArchitecture.Core.Security.Hashing;
using Application.Features.Users.Commands.Create;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommand : IRequest<CreatedStudentResponse>, ISecuredRequest
{
    public required string NameSurname { get; set; }
    public required string Email { get; set; }
    public required string TelephoneNumber { get; set; }
    public required string Address { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirm { get; set; }
    public required string ImageUrl { get; set; }
    public required Guid UserId { get; set; }

    public string[] Roles => [Admin, Write, StudentsOperationClaims.Create];

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreatedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly IUserRepository _userRepository;

        public CreateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules,
                                         IUserRepository userRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<CreatedStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = _mapper.Map<Student>(request);
            User user = new User();

            

            await _studentRepository.AddAsync(student);

            CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(student);

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


            return response;
        }
    }
}