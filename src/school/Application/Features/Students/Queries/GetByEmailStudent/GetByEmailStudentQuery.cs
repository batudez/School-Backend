using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using static Application.Features.Students.Constants.StudentsOperationClaims;

namespace Application.Features.Students.Queries.GetByEmailStudent;

public class GetByEmailStudentQuery : IRequest<GetByEmailStudentResponse>
{
    public  string Email { get; set; }
    public string[] Roles => [Admin, Read];

    public class GetByEmailStudentQueryHandler : IRequestHandler<GetByEmailStudentQuery, GetByEmailStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly IStudentRepository _studentRepository;

        public GetByEmailStudentQueryHandler(IMapper mapper, StudentBusinessRules studentBusinessRules, IStudentRepository studentRepository)
        {
            _mapper = mapper;
            _studentBusinessRules = studentBusinessRules;
            _studentRepository = studentRepository;
        }

        public async Task<GetByEmailStudentResponse> Handle(GetByEmailStudentQuery request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(predicate: s => s.Email == request.Email, cancellationToken: cancellationToken);
            GetByEmailStudentResponse response = _mapper.Map<GetByEmailStudentResponse>(student);
            return response;
        }
    }
}
