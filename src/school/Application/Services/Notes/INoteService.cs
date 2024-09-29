using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Notes;

public interface INoteService
{
    Task<Note?> GetAsync(
        Expression<Func<Note, bool>> predicate,
        Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Note>?> GetListAsync(
        Expression<Func<Note, bool>>? predicate = null,
        Func<IQueryable<Note>, IOrderedQueryable<Note>>? orderBy = null,
        Func<IQueryable<Note>, IIncludableQueryable<Note, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Note> AddAsync(Note note);
    Task<Note> UpdateAsync(Note note);
    Task<Note> DeleteAsync(Note note, bool permanent = false);
}
