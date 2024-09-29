using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class EmailAuthenticatorRepository
    : EfRepositoryBase<EmailAuthenticator, Guid, SchoolDbContext>,
        IEmailAuthenticatorRepository
{
    public EmailAuthenticatorRepository(SchoolDbContext context)
        : base(context) { }
}
