using Application.Features.StudentOperationClaims.Constants;
using Application.Features.StudentOperationClaims.Rules;
using Application.Features.UserOperationClaims.Commands.Create;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.StudentOperationClaims.Constants.StudentOperationClaimsOperationClaims;

namespace Application.Features.StudentOperationClaims.Commands.Create;
public class CreateStudentOperationClaimCommand : IRequest<CreatedStudentOperationClaimResponse>, ISecuredRequest
{
    public Guid StudentId { get; set; }
    public int OperationClaimId { get; set; }

    public string[] Roles => new[] { Admin, Write, StudentOperationClaimsOperationClaims.Create };

    public class CreateStudentOperationClaimCommandHandler
        : IRequestHandler<CreateStudentOperationClaimCommand, CreatedStudentOperationClaimResponse>
    {
        private readonly IStudentOperationClaimRepository _studentOperationClaimRepository;
        private readonly IMapper _mapper;
        private readonly StudentOperationClaimBusinessRules _studentOperationClaimBusinessRules;

        public CreateStudentOperationClaimCommandHandler(
            IStudentOperationClaimRepository studentOperationClaimRepository,
            IMapper mapper,
            StudentOperationClaimBusinessRules studentOperationClaimBusinessRules
        )
        {
            _studentOperationClaimRepository = studentOperationClaimRepository;
            _mapper = mapper;
            _studentOperationClaimBusinessRules = studentOperationClaimBusinessRules;
        }

        public async Task<CreatedStudentOperationClaimResponse> Handle(
            CreateStudentOperationClaimCommand request,
            CancellationToken cancellationToken
        )
        {
            await _studentOperationClaimBusinessRules.StudentShouldNotHasOperationClaimAlreadyWhenInsert(
                request.StudentId,
                request.OperationClaimId
            );
            StudentOperationClaim mappedStudentOperationClaim = _mapper.Map<StudentOperationClaim>(request);

            StudentOperationClaim createdStudentOperationClaim = await _studentOperationClaimRepository.AddAsync(mappedStudentOperationClaim);

            CreatedStudentOperationClaimResponse createdStudentOperationClaimDto = _mapper.Map<CreatedStudentOperationClaimResponse>(
                createdStudentOperationClaim
            );
            return createdStudentOperationClaimDto;
        }
    }
}
