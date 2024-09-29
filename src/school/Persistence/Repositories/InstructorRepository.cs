using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class InstructorRepository : EfRepositoryBase<Instructor, Guid, SchoolDbContext>, IInstructorRepository
{
    public InstructorRepository(SchoolDbContext context) : base(context)
    {
    }
}