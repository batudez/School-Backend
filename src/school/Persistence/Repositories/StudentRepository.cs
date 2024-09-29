using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class StudentRepository : EfRepositoryBase<Student, Guid, SchoolDbContext>, IStudentRepository
{
    public StudentRepository(SchoolDbContext context) : base(context)
    {
    }
}