using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommand : IRequest<UpdatedStudentResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public required string NameSurname { get; set; }
    public required string Email { get; set; }
    public required string TelephoneNumber { get; set; }
    public required string Address { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirm { get; set; }
    public required string ImageUrl { get; set; }

    public string[] Roles => [Admin, Write, StudentsOperationClaims.Update];

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdatedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public UpdateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<UpdatedStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _studentBusinessRules.StudentShouldExistWhenSelected(student);
            student = _mapper.Map(request, student);

            await _studentRepository.UpdateAsync(student!);

            UpdatedStudentResponse response = _mapper.Map<UpdatedStudentResponse>(student);
            return response;
        }
    }
}