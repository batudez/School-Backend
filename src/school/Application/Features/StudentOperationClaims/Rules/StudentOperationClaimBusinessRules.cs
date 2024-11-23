using Application.Features.StudentOperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.StudentOperationClaims.Rules;
public class StudentOperationClaimBusinessRules : BaseBusinessRules
{
    private readonly IStudentOperationClaimRepository _studentOperationClaimRepository;
    private readonly ILocalizationService _localizationService;

    public StudentOperationClaimBusinessRules(
        IStudentOperationClaimRepository studentOperationClaimRepository,
        ILocalizationService localizationService
    )
    {
        _studentOperationClaimRepository = studentOperationClaimRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, StudentOperationClaimsMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task StudentOperationClaimShouldExistWhenSelected(StudentOperationClaim? studentOperationClaim)
    {
        if (studentOperationClaim == null)
            await throwBusinessException(StudentOperationClaimsMessages.StudentOperationClaimNotExists);
    }

    public async Task StudentOperationClaimIdShouldExistWhenSelected(Guid id)
    {
        bool doesExist = await _studentOperationClaimRepository.AnyAsync(predicate: b => b.Id == id);
        if (!doesExist)
            await throwBusinessException(StudentOperationClaimsMessages.StudentOperationClaimNotExists);
    }

    public async Task StudentOperationClaimShouldNotExistWhenSelected(StudentOperationClaim? studentOperationClaim)
    {
        if (studentOperationClaim != null)
            await throwBusinessException(StudentOperationClaimsMessages.StudentOperationClaimAlreadyExists);
    }

    public async Task StudentShouldNotHasOperationClaimAlreadyWhenInsert(Guid studentId, int operationClaimId)
    {
        bool doesExist = await _studentOperationClaimRepository.AnyAsync(u =>
            u.StudentId == studentId && u.OperationClaimId == operationClaimId
        );
        if (doesExist)
            await throwBusinessException(StudentOperationClaimsMessages.StudentOperationClaimAlreadyExists);
    }

    public async Task StudentShouldNotHasOperationClaimAlreadyWhenUpdated(Guid id, Guid studentId, int operationClaimId)
    {
        bool doesExist = await _studentOperationClaimRepository.AnyAsync(predicate: uoc =>
            uoc.Id == id && uoc.StudentId == studentId && uoc.OperationClaimId == operationClaimId
        );
        if (doesExist)
            await throwBusinessException(StudentOperationClaimsMessages.StudentOperationClaimAlreadyExists);
    }
}
