using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;

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

    public string[] Roles => [Admin, Write, StudentsOperationClaims.Create];

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreatedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public CreateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<CreatedStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = _mapper.Map<Student>(request);

            await _studentRepository.AddAsync(student);

            CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(student);
            return response;
        }
    }
}