using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class CourseRepository : EfRepositoryBase<Course, Guid, SchoolDbContext>, ICourseRepository
{
    public CourseRepository(SchoolDbContext context) : base(context)
    {
    }
}