using Application.Features.Instructors.Rules;
using Application.Features.Students.Queries.GetByEmailStudent;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Instructors.Constants.InstructorsOperationClaims;

namespace Application.Features.Instructors.Queries.GetByEmail;
public class GetByEmailInstructorQuery : IRequest<GetByEmailInstructorResponse>
{
    public string Email { get; set; }
    public string[] Roles => [Admin, Read];

    public class GetByEmailInstructorQueryHandler : IRequestHandler<GetByEmailInstructorQuery, GetByEmailInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly IInstructorRepository _instructorRepository;

        public GetByEmailInstructorQueryHandler(IMapper mapper, InstructorBusinessRules instructorBusinessRules, IInstructorRepository instructorRepository, StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentBusinessRules = studentBusinessRules;
            _instructorRepository = instructorRepository;
        }

        public async Task<GetByEmailInstructorResponse> Handle(GetByEmailInstructorQuery request, CancellationToken cancellationToken)
        {
            Instructor? instructor = await _instructorRepository.GetAsync(predicate: s => s.Email == request.Email, cancellationToken: cancellationToken);
            GetByEmailInstructorResponse response = _mapper.Map<GetByEmailInstructorResponse>(instructor);
            return response;
        }
    }
}
