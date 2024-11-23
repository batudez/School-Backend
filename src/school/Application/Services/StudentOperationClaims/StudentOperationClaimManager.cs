using Application.Features.StudentOperationClaims.Rules;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using Application.Services.UserOperationClaims;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.StudentOperationClaims;
public class StudentOperationClaimManager : IStudentOperationClaimService
{
    private readonly IStudentOperationClaimRepository _studentOperationClaimRepository;
    private readonly StudentOperationClaimBusinessRules _studentOperationClaimBusinessRules;

    public StudentOperationClaimManager(
        IStudentOperationClaimRepository studentOperationClaimRepository,
        StudentOperationClaimBusinessRules studentOperationClaimBusinessRules
    )
    {
        _studentOperationClaimRepository = studentOperationClaimRepository;
        _studentOperationClaimBusinessRules = studentOperationClaimBusinessRules;
    }

    public async Task<StudentOperationClaim?> GetAsync(
        Expression<Func<StudentOperationClaim, bool>> predicate,
        Func<IQueryable<StudentOperationClaim>, IIncludableQueryable<StudentOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        StudentOperationClaim? userUserOperationClaim = await _studentOperationClaimRepository.GetAsync(
            predicate,
            include,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaim;
    }

    public async Task<IPaginate<StudentOperationClaim>?> GetListAsync(
        Expression<Func<StudentOperationClaim, bool>>? predicate = null,
        Func<IQueryable<StudentOperationClaim>, IOrderedQueryable<StudentOperationClaim>>? orderBy = null,
        Func<IQueryable<StudentOperationClaim>, IIncludableQueryable<StudentOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<StudentOperationClaim> userUserOperationClaimList = await _studentOperationClaimRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userUserOperationClaimList;
    }

    public async Task<StudentOperationClaim> AddAsync(StudentOperationClaim studentOperationClaim)
    {
        await _studentOperationClaimBusinessRules.StudentShouldNotHasOperationClaimAlreadyWhenInsert(
            studentOperationClaim.StudentId,
            studentOperationClaim.OperationClaimId
        );

        StudentOperationClaim addedStudentOperationClaim = await _studentOperationClaimRepository.AddAsync(studentOperationClaim);

        return addedStudentOperationClaim;
    }

    public async Task<StudentOperationClaim> UpdateAsync(StudentOperationClaim studentOperationClaim)
    {
        await _studentOperationClaimBusinessRules.StudentShouldNotHasOperationClaimAlreadyWhenUpdated(
            studentOperationClaim.Id,
            studentOperationClaim.StudentId,
            studentOperationClaim.OperationClaimId
        );

        StudentOperationClaim updatedStudentOperationClaim = await _studentOperationClaimRepository.UpdateAsync(
            studentOperationClaim
        );

        return updatedStudentOperationClaim;
    }

    public async Task<StudentOperationClaim> DeleteAsync(StudentOperationClaim studentOperationClaim, bool permanent = false)
    {
        StudentOperationClaim deletedStudentOperationClaim = await _studentOperationClaimRepository.DeleteAsync(
            studentOperationClaim
        );

        return deletedStudentOperationClaim;
    }
}
