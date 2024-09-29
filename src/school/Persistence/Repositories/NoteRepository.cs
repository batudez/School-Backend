using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class NoteRepository : EfRepositoryBase<Note, Guid, SchoolDbContext>, INoteRepository
{
    public NoteRepository(SchoolDbContext context) : base(context)
    {
    }
}