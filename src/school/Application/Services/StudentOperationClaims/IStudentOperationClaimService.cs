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
public interface IStudentOperationClaimService
{
    Task<StudentOperationClaim?> GetAsync(
        Expression<Func<StudentOperationClaim, bool>> predicate,
        Func<IQueryable<StudentOperationClaim>, IIncludableQueryable<StudentOperationClaim, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<IPaginate<StudentOperationClaim>?> GetListAsync(
        Expression<Func<StudentOperationClaim, bool>>? predicate = null,
        Func<IQueryable<StudentOperationClaim>, IOrderedQueryable<StudentOperationClaim>>? orderBy = null,
        Func<IQueryable<StudentOperationClaim>, IIncludableQueryable<StudentOperationClaim, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );

    Task<StudentOperationClaim> AddAsync(StudentOperationClaim studentOperationClaim);
    Task<StudentOperationClaim> UpdateAsync(StudentOperationClaim studentOperationClaim);
    Task<StudentOperationClaim> DeleteAsync(StudentOperationClaim studentOperationClaim, bool permanent = false);
}