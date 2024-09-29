using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, SchoolDbContext>, IUserRepository
{
    public UserRepository(SchoolDbContext context)
        : base(context) { }
}
