using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories;
public class StudentOperationClaimRepository
    : EfRepositoryBase<StudentOperationClaim, Guid, SchoolDbContext>,
        IStudentOperationClaimRepository
{
    public StudentOperationClaimRepository(SchoolDbContext context)
        : base(context) { }

    public async Task<IList<OperationClaim>> GetOperationClaimsByStudentIdAsync(Guid studentId)
    {
        List<OperationClaim> operationClaims = await Query()
            .AsNoTracking()
            .Where(p => p.StudentId.Equals(studentId))
            .Select(p => new OperationClaim { Id = p.OperationClaimId, Name = p.OperationClaim.Name })
            .ToListAsync();
        return operationClaims;
    }
}