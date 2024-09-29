using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class AnnouncementRepository : EfRepositoryBase<Announcement, int, SchoolDbContext>, IAnnouncementRepository
{
    public AnnouncementRepository(SchoolDbContext context) : base(context)
    {
    }
}