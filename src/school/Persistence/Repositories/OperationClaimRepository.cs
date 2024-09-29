using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OperationClaimRepository : EfRepositoryBase<OperationClaim, int, SchoolDbContext>, IOperationClaimRepository
{
    public OperationClaimRepository(SchoolDbContext context)
        : base(context) { }
}
