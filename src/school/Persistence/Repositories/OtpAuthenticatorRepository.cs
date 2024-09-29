using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class OtpAuthenticatorRepository : EfRepositoryBase<OtpAuthenticator, Guid, SchoolDbContext>, IOtpAuthenticatorRepository
{
    public OtpAuthenticatorRepository(SchoolDbContext context)
        : base(context) { }
}
