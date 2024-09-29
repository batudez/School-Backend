using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface INoteRepository : IAsyncRepository<Note, Guid>, IRepository<Note, Guid>
{
}